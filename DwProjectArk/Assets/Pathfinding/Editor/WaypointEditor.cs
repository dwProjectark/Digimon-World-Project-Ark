using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class WaypointEditor : EditorWindow 
{
    WaypointNode activeNode = null;
    private GameObject waypointPrefab = null;
    private bool canPlaceNewWaypoint = true;
    private bool itsActive = true;

    
    [MenuItem("Window/Pathfinding/WaypointEditor")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(WaypointEditor));
    }

    void OnGUI()
    {
        if (waypointPrefab == null)
        {
            waypointPrefab = (GameObject)Resources.Load("Prefabs/Waypoint");
        }
        else
        {
            canPlaceNewWaypoint = true;
        }

        GUILayout.Label("1. Right click: to place a new waypoint at the postion \n");
        GUILayout.Label("1. Right click: on one of the existing waypoint to make it current active waypoint \n");
        GUILayout.Label("3. Right click + CTRL: neighbor two waypoint, the active and the clicked one \n");
        GUILayout.Label("4. Right click + CTRL + ALT: delete the clicked on waypoint \n");
        GUILayout.Label("5. Left click + Alt: disconnect the active waypoint from the clicked on waypoint \n");
        GUILayout.Label("6. Left click + CTRL + ALT: disconnect both waypoints in both directions \n");
        GUILayout.Label("Active = " + itsActive + "\n");

        if(GUILayout.Button("Activate/Deactivate"))
        {
            itsActive = (itsActive) ? false : true;
        }

        //Used for the editor window
        if (SceneView.onSceneGUIDelegate != this.OnSceneGUI)
        {
            SceneView.onSceneGUIDelegate += this.OnSceneGUI;
        }
    }

    void OnSceneGUI(SceneView view)
    {
        if (itsActive)
        {
            if (!Event.current.control && !Event.current.alt && Event.current.type == EventType.MouseUp && Event.current.button == 1)
            {
                Event e = Event.current;
                RaycastHit hit;
                Vector3 mousePos = new Vector3(e.mousePosition.x, -e.mousePosition.y + SceneView.lastActiveSceneView.camera.pixelHeight);
                Ray ray = SceneView.lastActiveSceneView.camera.ScreenPointToRay(mousePos);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (waypointPrefab != null && canPlaceNewWaypoint && hit.transform.name != "Waypoint")
                    {
                        GameObject newWaypoint = (GameObject)PrefabUtility.InstantiatePrefab(waypointPrefab);
                        newWaypoint.transform.position = hit.point;

                        if (activeNode != null)
                        {
                            activeNode.isActive = false;
                        }

                        activeNode = newWaypoint.GetComponent<WaypointNode>();
                        activeNode.position = hit.point;
                        activeNode.isActive = true;
                        GameObject pFinder = GameObject.FindGameObjectWithTag("WPPathfinder");
                        newWaypoint.transform.parent = pFinder.transform;
                        canPlaceNewWaypoint = false;
                        EditorUtility.SetDirty(activeNode);
                    }
                    else if (hit.transform.name == "Waypoint")
                    {
                        if (activeNode != null)
                        {
                            activeNode.isActive = false;
                            EditorUtility.SetDirty(activeNode);
                        }

                        activeNode = hit.transform.GetComponent<WaypointNode>();
                        activeNode.isActive = true;
                        EditorUtility.SetDirty(activeNode);
                    }
                }
            }
            else if (Event.current.control && !Event.current.alt && Event.current.type == EventType.MouseUp && Event.current.button == 1)
            {
                Event e = Event.current;
                RaycastHit hit;
                Vector3 mousePos = new Vector3(e.mousePosition.x, -e.mousePosition.y + SceneView.lastActiveSceneView.camera.pixelHeight);
                Ray ray = SceneView.lastActiveSceneView.camera.ScreenPointToRay(mousePos);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.transform.name == "Waypoint")
                    {
                        WaypointNode node = hit.transform.GetComponent<WaypointNode>();

                        if (node != activeNode && !NodesAlreadyConnected(node, activeNode))
                        {
                            activeNode.neighbors.Add(node);
                            node.neighbors.Add(activeNode);
                            EditorUtility.SetDirty(activeNode);
                            EditorUtility.SetDirty(node);
                        }
                    }
                }
            }
            else if (Event.current.alt && !Event.current.control && Event.current.type == EventType.MouseUp && Event.current.button == 0)
            {
                Event e = Event.current;
                RaycastHit hit;
                Vector3 mousePos = new Vector3(e.mousePosition.x, -e.mousePosition.y + SceneView.lastActiveSceneView.camera.pixelHeight);
                Ray ray = SceneView.lastActiveSceneView.camera.ScreenPointToRay(mousePos);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.transform.name == "Waypoint")
                    {
                        WaypointNode node = hit.transform.GetComponent<WaypointNode>();

                        if (node != activeNode && NodesAlreadyConnected(node, activeNode))
                        {
                            activeNode.neighbors.Remove(node);
                            EditorUtility.SetDirty(activeNode);
                        }
                    }
                }
            }
            else if (Event.current.control && Event.current.alt && Event.current.type == EventType.MouseUp && Event.current.button == 1)
            {
                Event e = Event.current;
                RaycastHit hit;
                Vector3 mousePos = new Vector3(e.mousePosition.x, -e.mousePosition.y + SceneView.lastActiveSceneView.camera.pixelHeight);
                Ray ray = SceneView.lastActiveSceneView.camera.ScreenPointToRay(mousePos);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.transform.name == "Waypoint")
                    {
                        WaypointNode node = hit.transform.GetComponent<WaypointNode>();
                        GameObject[] wpList = GameObject.FindGameObjectsWithTag("Waypoint");

                        foreach (GameObject g in wpList)
                        {
                            if (g.GetComponent<WaypointNode>().neighbors.Contains(node))
                            {
                                g.GetComponent<WaypointNode>().neighbors.Remove(node);
                            }
                        }
                        GameObject.DestroyImmediate(hit.transform.gameObject);
                    }
                }
            }
            else if (Event.current.alt && Event.current.control && Event.current.type == EventType.MouseUp && Event.current.button == 0)
            {
                Event e = Event.current;
                RaycastHit hit;
                Vector3 mousePos = new Vector3(e.mousePosition.x, -e.mousePosition.y + SceneView.lastActiveSceneView.camera.pixelHeight);
                Ray ray = SceneView.lastActiveSceneView.camera.ScreenPointToRay(mousePos);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.transform.name == "Waypoint")
                    {
                        WaypointNode node = hit.transform.GetComponent<WaypointNode>();

                        if (node != activeNode && NodesAlreadyConnected(node, activeNode) && NodesAlreadyConnected(activeNode, node))
                        {
                            activeNode.neighbors.Remove(node);
                            node.neighbors.Remove(activeNode);
                            EditorUtility.SetDirty(activeNode);
                            EditorUtility.SetDirty(node);
                        }
                    }
                }
            }

            canPlaceNewWaypoint = true;
        }
    }

    private bool NodesAlreadyConnected(WaypointNode n, WaypointNode a)
    {
        foreach (WaypointNode wpn in a.neighbors)
        {
            if (wpn == n)
            {
                return true;
            }
        }
        return false;
    }
}
