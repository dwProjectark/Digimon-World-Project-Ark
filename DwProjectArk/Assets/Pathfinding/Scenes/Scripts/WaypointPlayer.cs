using UnityEngine;
using System.Collections;

public class WaypointPlayer : Pathfinding {

    private CharacterController controller;
    private LineRenderer lineRenderer;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {
        FindPath();
        if (Path.Count > 0)
        {
            MoveMethod();
        }
        //DrawPath();
    }

    private void FindPath()
    {

     if (Input.GetButtonDown("Fire1"))
        {
            //Call minimap
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                FindPath(transform.position, hit.point);
            }
        }
    }

    private void MoveMethod()
    {
        if (Path.Count > 0)
        {
            Vector3 direction = (Path[0] - transform.position).normalized;

            controller.SimpleMove(direction * 10F);
            if (Vector3.Distance(transform.position - Vector3.up, Path[0]) < 1F)
            {
                Path.RemoveAt(0);
            }
        }
    }

    private void DrawPath()
    {
        if (Path.Count > 0)
        {
            lineRenderer.SetVertexCount(Path.Count);

            for (int i = 0; i < Path.Count; i++)
            {
                lineRenderer.SetPosition(i, Path[i] + Vector3.up);
            }
        }
        else
        {
            lineRenderer.SetVertexCount(0);
        }
    }
}
