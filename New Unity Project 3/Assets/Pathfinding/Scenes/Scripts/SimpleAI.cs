using UnityEngine;
using System.Collections;

public class SimpleAI : Pathfinding 
{
    public GameObject player;

	void Start () 
    {
        StartCoroutine(FindPlayer());
	}

	void Update () 
    {
	    Move();
	}

    IEnumerator FindPlayer()
    {
        if (player != null)
        {
            FindPath(transform.position, player.transform.position);
        }
        yield return new WaitForSeconds(1F);
        StartCoroutine(FindPlayer());       
    }
}
