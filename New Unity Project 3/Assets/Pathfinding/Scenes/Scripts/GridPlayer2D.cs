using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridPlayer2D : Pathfinding2D
{
    void Update()
    {
        FindPath();
        if (Path.Count > 0)
        {
            Move();
        }
    }

    private void FindPath()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                FindPath(transform.position, hit.point);
            }
        }
    }
}
