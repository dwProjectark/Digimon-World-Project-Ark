using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TDManager : MonoBehaviour 
{
    public GameObject start;
    public GameObject end;
    public GameObject tower;
    public GameObject ghostTower;
    public GameObject enemy;

    private List<GameObject> towers = new List<GameObject>();

    void Start()
    {
       StartCoroutine(SpawnEnemy());
    }
	
	void Update () 
    {
        StartCoroutine(PlaceTowers());
	}

    private RaycastHit CheckPosition()
    {
        Ray ray = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Make sure to set towers in a grid, by rounding position to an int
            Vector3 newPos = hit.point;
            newPos.Set(Mathf.RoundToInt(newPos.x) - 0.5F, 0.4F, Mathf.RoundToInt(newPos.z) + 0.5F);
            ghostTower.transform.position = newPos;

            //Set color of "show" tower based on the spot being available
            if (hit.transform.tag == "Ground")
            {
                ghostTower.renderer.material.color = Color.green;
            }
            else
            {
                ghostTower.renderer.material.color = Color.red;
            }
        }
        else
        {
            ghostTower.renderer.material.color = Color.red;
        }

        //Return all hit information which we use later
        return hit;
    }

    private IEnumerator PlaceTowers()
    {
        RaycastHit hit = CheckPosition();
        bool canPlace = false;
        //Make sure that we did hit something
        if (hit.transform != null)
        {
            canPlace = (hit.transform.tag == "Ground") ? true : false;
        }

        if (Input.GetButtonDown("Fire1") && canPlace)
        {
            GameObject newTower = Instantiate(tower, new Vector3(Mathf.RoundToInt(hit.point.x) - 0.5F, 0.3F, Mathf.RoundToInt(hit.point.z) + 0.5F), Quaternion.identity) as GameObject;
            towers.Add(newTower);
            yield return new WaitForEndOfFrame();
            Pathfinder.Instance.InsertInQueue(start.transform.position, end.transform.position, CheckRoute);
        }      
    }

    private void CheckRoute(List<Vector3> list)
    {     
        //If we get a list that is empty there is no path, and we blocked the road
        //Then remove the last added tower!
        if (list.Count < 1 || list == null)
        {
            if (towers.Count > 0)
            {
                GameObject g = towers[towers.Count - 1];
                towers.RemoveAt(towers.Count - 1);
                Destroy(g);
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1.5F);
        GameObject e = Instantiate(enemy, start.transform.position, Quaternion.identity) as GameObject;
        e.GetComponent<TDEnemy>().start = start.transform.position;
        e.GetComponent<TDEnemy>().end = end.transform.position;
        StartCoroutine(SpawnEnemy());
    }
}
