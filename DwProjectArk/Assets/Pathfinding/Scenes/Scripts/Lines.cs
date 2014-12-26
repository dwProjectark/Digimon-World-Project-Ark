using UnityEngine;
using System.Collections;

public class Lines : MonoBehaviour 
{
    private LineRenderer lineRenderer;
    private GridPlayer playerScript;

	void Start () 
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<GridPlayer>();
	}
	
	void Update () 
    {
        DrawPath();
	}

    private void DrawPath()
    {
        if (playerScript.Path.Count > 0)
        {
            lineRenderer.SetVertexCount(playerScript.Path.Count);

            for (int i = 0; i < playerScript.Path.Count; i++)
            {
                lineRenderer.SetPosition(i, playerScript.Path[i] + Vector3.up);
            }
        }
        else
        {
            lineRenderer.SetVertexCount(0);
        }
    }
}
