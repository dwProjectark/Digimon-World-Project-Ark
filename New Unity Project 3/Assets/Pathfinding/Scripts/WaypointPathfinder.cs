using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

[ExecuteInEditMode]
public class WaypointPathfinder : MonoBehaviour 
{
    public enum WaypointMethod
    {
        ExactPosition,
        ClosestWaypoint
    }
    
    //Singleton
    private static WaypointPathfinder instance;
    public static WaypointPathfinder Instance { get { return instance; } private set { } }

    //Variables
    public List<string> DisallowedTags;
    public WaypointNode[] Map = null;
    public WaypointMethod SearchMethod;

    //Can i walk to that spot
    private bool freeSpot = true;

    //Queue path finding to not bottleneck it + timers
    private List<QueuePath> queue = new List<QueuePath>();
    //FPS
    private float updateinterval = 1F;
    private int frames = 0;
    private float timeleft = 1F;
    private int FPS = 60;

    //Set singleton!
    void Awake()
    {
        instance = this;
    }

	void Start () 
    {
        GameObject[] M = GameObject.FindGameObjectsWithTag("Waypoint");
        Map = new WaypointNode[M.Length];
        for (int i = 0; i < M.Length; i++)
        {
            Map[i] = M[i].GetComponent<WaypointNode>();
            Map[i].ID = i;
        }

        openList = new WaypointListNode[Map.Length];
        closedList = new WaypointListNode[Map.Length];
	}

    void Update() 
    {
        timeleft -= Time.deltaTime;
        frames++;

        if (timeleft <= 0F)
        {
            FPS = frames;
            timeleft = updateinterval;
            frames = 0;
        }

        float timer = 0F;
        float maxtime = 1000 / FPS;
        //Bottleneck prevention
        while (queue.Count > 0 && timer < maxtime)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            queue[0].storeRef.Invoke(FindPath(queue[0].startPos, queue[0].endPos));
            queue.RemoveAt(0);
            sw.Stop();
            //print("Timer: " + sw.ElapsedMilliseconds);
            timer += sw.ElapsedMilliseconds;
        }
	}


    //---------------------------------------SETUP PATH QUEUE---------------------------------------//

    public void InsertInQueue(Vector3 startPos, Vector3 endPos, Action<List<Vector3>> listMethod)
    {
        QueuePath q = new QueuePath(startPos, endPos, listMethod);
        queue.Add(q);
    }


    #region astar
    //---------------------------------------FIND PATH: A*------------------------------------------//

    private WaypointListNode[] openList;
    private WaypointListNode[] closedList;
    private WaypointListNode startNode;
    private WaypointListNode endNode;
    private WaypointListNode currentNode;
    //Use it with KEY: F-value, VALUE: ID. ID's might be looked up in open and closed list then
    private List<NodeSearch> sortedOpenList = new List<NodeSearch>();

    public List<Vector3> FindPath(Vector3 startPos, Vector3 endPos)
    {
        //The list we returns when path is found
        List<Vector3> returnPath = new List<Vector3>();

        //Find start and end nodes, if we cant return null and stop!
        SetStartAndEndNode(startPos, endPos);
        CheckEndPosition(endPos);

        if (startNode != null && endNode != null)
        {
            //Clear lists if they are filled
            Array.Clear(openList, 0, openList.Length);
            Array.Clear(closedList, 0, openList.Length);
            if (sortedOpenList.Count > 0) { sortedOpenList.Clear(); }

            //Insert start node
            openList[startNode.ID] = startNode;
            //sortedOpenList.Add(new NodeSearch(startNode.ID, startNode.F));
            BHInsertNode(new NodeSearch(startNode.ID, startNode.F));

            bool endLoop = false;

            while (!endLoop)
            {
                //If we have no nodes on the open list AND we are not at the end, then we got stucked! return empty list then.
                if (sortedOpenList.Count == 0)
                {
                    print("Empty Openlist, closedList");
                    return new List<Vector3>();
                }

                //Get lowest node and insert it into the closed list
                int id = BHGetLowest();
                //sortedOpenList.Sort(sort);
                //int id = sortedOpenList[0].ID;
                currentNode = openList[id];
                closedList[currentNode.ID] = currentNode;
                openList[id] = null;
                //sortedOpenList.RemoveAt(0);

                if (currentNode.ID == endNode.ID)
                {
                    endLoop = true;
                    continue;
                }
                //Now look at neighbours, check for unwalkable tiles, bounderies, open and closed listed nodes.

                NeighbourCheck();
            }


            while (true)
            {
                returnPath.Add(currentNode.position);
                if (currentNode.parent != null)
                {
                    currentNode = currentNode.parent;
                }
                else
                {
                    break;
                }
            }

            returnPath.Reverse();

            //Now make sure we do not go backwards or go to long
            if (freeSpot && SearchMethod == WaypointMethod.ExactPosition)
            {
                returnPath.Add(endPos);

                if (returnPath.Count > 2)
                {
                    if (Vector3.Distance(returnPath[returnPath.Count - 1], returnPath[returnPath.Count - 3]) < Vector3.Distance(returnPath[returnPath.Count - 3], returnPath[returnPath.Count - 2]) && freeSpot)
                    {
                        returnPath.RemoveAt(returnPath.Count - 2);
                    }
                }
            }

            //Check if start pos i closer to second waypoint
            if (returnPath.Count > 1)
            {
                if (Vector3.Distance(returnPath[1], startPos) < Vector3.Distance(returnPath[0], returnPath[1]))
                {
                    returnPath.RemoveAt(0);
                }
            }

            return returnPath;

        }
        else
        {
            return null;
        }
    }

    private void CheckEndPosition(Vector3 end)
    {
        RaycastHit[] hit = Physics.SphereCastAll(end + Vector3.up, 0.5F, Vector3.down, 1.5F);

        foreach (RaycastHit h in hit)
        {
            foreach (String s in DisallowedTags)
            {
                if (h.transform.tag == s)
                {
                    freeSpot = false;
                    return;
                }
            }
        }
        freeSpot = true;
    }

    // Find start and end Node
    private void SetStartAndEndNode(Vector3 start, Vector3 end)
    {
        startNode = FindClosestNode(start);
        endNode = FindClosestNode(end);
    }

    private WaypointListNode FindClosestNode(Vector3 pos)
    {
        Stopwatch a = new Stopwatch();
        a.Start();
        
        int ID = -1;
        float lowestDist = Mathf.Infinity;
        
        foreach (WaypointNode m in Map)
        {
            float d = Vector3.Distance(m.position, pos);
            if (d < lowestDist)
            {
                ID = m.ID;
                lowestDist = d;
            }
        }

        if (ID > -1)
        {
            WaypointListNode wp = new WaypointListNode(Map[ID].position, Map[ID].ID, null, Map[ID].neighbors);
            return wp;
        }
        else
        {
            return null;
        }
    }

    private void NeighbourCheck()
    {

        foreach (WaypointNode wp in currentNode.neighbors)
        {
            if (wp != null)
            {
                if (!OnClosedList(wp.ID))
                {
                    //If it is not on the open list then add it to
                    if (!OnOpenList(wp.ID))
                    {
                        WaypointListNode addNode = new WaypointListNode(wp.position, wp.ID, currentNode, wp.neighbors);
                        addNode.H = GetHeuristics(endNode.position, wp.position);
                        addNode.G = GetMovementCost(currentNode.position, wp.position) + currentNode.G;
                        addNode.F = addNode.H + addNode.G;
                        //Insert on open list
                        openList[addNode.ID] = addNode;
                        //Insert on sorted list
                        BHInsertNode(new NodeSearch(addNode.ID, addNode.F));
                        //sortedOpenList.Add(new NodeSearch(addNode.ID, addNode.F));
                    }
                    else
                    {
                        ///If it is on openlist then check if the new paths movement cost is lower
                        WaypointListNode n = GetNodeFromOpenList(wp.ID);

                        if (currentNode.G + GetMovementCost(currentNode.position, wp.position) < openList[wp.ID].G)
                        {
                            n.parent = currentNode;
                            n.G = currentNode.G + GetMovementCost(currentNode.position, wp.position);
                            n.F = n.G + n.H;
                            BHSortNode(n.ID, n.F);
                            //ChangeFValue(n.ID, n.F);
                        }
                    }
                }
            }
        }
     }

    private void ChangeFValue(int id, int F)
    {
        foreach (NodeSearch ns in sortedOpenList)
        {
            if (ns.ID == id)
            {
                ns.F = F;
            }
        }
    }

    //Check if a Node is already on the openList
    private bool OnOpenList(int id)
    {
        return (openList[id] != null) ? true : false;
    }

    //Check if a Node is already on the closedList
    private bool OnClosedList(int id)
    {
        return (closedList[id] != null) ? true : false;
    }

    private float GetHeuristics(Vector3 p1, Vector3 p2)
    {
        return Vector3.Distance(p1, p2);
    }

    private float GetMovementCost(Vector3 p1, Vector3 p2)
    {
        return Vector3.Distance(p1, p2);
    }

    private WaypointListNode GetNodeFromOpenList(int id)
    {
        return (openList[id] != null) ? openList[id] : null;
    }

    #region Binary_Heap (min)

    private void BHInsertNode(NodeSearch ns)
    {
        //We use index 0 as the root!
        if (sortedOpenList.Count == 0)
        {
            sortedOpenList.Add(ns);
            openList[ns.ID].sortedIndex = 0;
            return;
        }

        sortedOpenList.Add(ns);
        bool canMoveFurther = true;
        int index = sortedOpenList.Count - 1;
        openList[ns.ID].sortedIndex = index;

        while (canMoveFurther)
        {
            int parent = Mathf.FloorToInt((index - 1) / 2);

            if (index == 0) //We are the root
            {
                openList[sortedOpenList[index].ID].sortedIndex = 0;
                canMoveFurther = false;
            }
            else
            {
                if (sortedOpenList[index].Fv < sortedOpenList[parent].Fv)
                {
                    NodeSearch s = sortedOpenList[parent];
                    sortedOpenList[parent] = sortedOpenList[index];
                    sortedOpenList[index] = s;

                    //Save sortedlist index's for faster look up
                    openList[sortedOpenList[index].ID].sortedIndex = index;
                    openList[sortedOpenList[parent].ID].sortedIndex = parent;

                    //Reset index to parent ID
                    index = parent;
                }
                else
                {
                    canMoveFurther = false;
                }
            }
        }
    }

    private void BHSortNode(int id, float F)
    {
        bool canMoveFurther = true;
        int index = openList[id].sortedIndex;
        sortedOpenList[index].Fv = F;

        while (canMoveFurther)
        {
            int parent = Mathf.FloorToInt((index - 1) / 2);

            if (index == 0) //We are the root
            {
                canMoveFurther = false;
                openList[sortedOpenList[index].ID].sortedIndex = 0;
            }
            else
            {
                if (sortedOpenList[index].Fv < sortedOpenList[parent].Fv)
                {
                    NodeSearch s = sortedOpenList[parent];
                    sortedOpenList[parent] = sortedOpenList[index];
                    sortedOpenList[index] = s;

                    //Save sortedlist index's for faster look up
                    openList[sortedOpenList[index].ID].sortedIndex = index;
                    openList[sortedOpenList[parent].ID].sortedIndex = parent;

                    //Reset index to parent ID
                    index = parent;
                }
                else
                {
                    canMoveFurther = false;
                }
            }
        }
    }

    private int BHGetLowest()
    {

        if (sortedOpenList.Count == 1) //Remember 1 is our root
        {
            int ID = sortedOpenList[0].ID;
            sortedOpenList.RemoveAt(0);
            return ID;
        }
        else if (sortedOpenList.Count > 1)
        {
            //save lowest not, take our leaf as root, and remove it! Then switch through children to find right place.
            int ID = sortedOpenList[0].ID;
            sortedOpenList[0] = sortedOpenList[sortedOpenList.Count - 1];
            sortedOpenList.RemoveAt(sortedOpenList.Count - 1);
            openList[sortedOpenList[0].ID].sortedIndex = 0;

            int index = 0;
            bool canMoveFurther = true;
            //Sort the list before returning the ID
            while (canMoveFurther)
            {
                int child1 = (index * 2) + 1;
                int child2 = (index * 2) + 2;
                int switchIndex = -1;

                if (child1 < sortedOpenList.Count)
                {
                    switchIndex = child1;
                }
                else
                {
                    break;
                }
                if (child2 < sortedOpenList.Count)
                {
                    if (sortedOpenList[child2].Fv < sortedOpenList[child1].Fv)
                    {
                        switchIndex = child2;
                    }
                }
                if (sortedOpenList[index].Fv > sortedOpenList[switchIndex].Fv)
                {
                    NodeSearch ns = sortedOpenList[index];
                    sortedOpenList[index] = sortedOpenList[switchIndex];
                    sortedOpenList[switchIndex] = ns;

                    //Save sortedlist index's for faster look up
                    openList[sortedOpenList[index].ID].sortedIndex = index;
                    openList[sortedOpenList[switchIndex].ID].sortedIndex = switchIndex;

                    //Switch around idnex
                    index = switchIndex;
                }
                else
                {
                    break;
                }
            }

            return ID;

        }
        else
        {
            return -1;
        }
    }
    #endregion //end BH sort
    #endregion //End astar region!
}