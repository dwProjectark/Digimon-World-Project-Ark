using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaypointListNode  
{
	public Vector3 position;
    public int ID = 0;
    public WaypointListNode parent = null;

    public float F = 0;
    public float H = 0;
    public float G = 0;

    public List<WaypointNode> neighbors = null;

    //for the editor
    public bool active = false;

    //Use for faster look ups
    public int sortedIndex = -1;

    void Start()
    {

    }

    public WaypointListNode()
    {
        //Empty node
    }

    public WaypointListNode(Vector3 p, int id, WaypointListNode wpParent = null, List<WaypointNode> n = null, float f = 0, float g = 0, float h = 0)
    {
        position = p;
        ID = id;
        parent = wpParent;
        neighbors = n;
        F = f;
        G = g;
        H = h;
    }
}
