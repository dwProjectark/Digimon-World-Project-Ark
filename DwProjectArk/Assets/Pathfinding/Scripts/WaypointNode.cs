using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class WaypointNode : MonoBehaviour
{
    public Vector3 position;
    public int ID = 0;
    public WaypointNode parent = null;

    public float F = 0;
    public float H = 0;
    public float G = 0;

    public List<WaypointNode> neighbors = null;

    //for the editor
    public bool isActive = false;

    void Start()
    {
        if(Application.isPlaying)
        {
            gameObject.collider.enabled = false;
        }
    }

    public WaypointNode()
    {
        //Empty node
    }

    public WaypointNode(Vector3 p, int id, WaypointNode wpParent = null, List<WaypointNode> n = null, float f = 0, float g = 0, float h = 0)
    {
        position = p;
        ID = id;
        parent = wpParent;
        neighbors = n;
        F = f;
        G = g;
        H = h;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = (isActive) ? Color.yellow : Color.red;
        Gizmos.DrawCube(position, new Vector3(1, 1, 1));

        foreach (WaypointNode n in neighbors)
        {
            if (n != null)
            {
                Gizmos.color = (isActive) ? Color.yellow : Color.red;
                Gizmos.DrawLine(position + Vector3.up * 0.5F, n.position + Vector3.up * 0.5F);
            }
        }
    }
}
