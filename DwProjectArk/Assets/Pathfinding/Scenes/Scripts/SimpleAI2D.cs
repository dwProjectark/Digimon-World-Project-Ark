using UnityEngine;
using System.Collections;

public class SimpleAI2D : Pathfinding2D 
{
    public uint SearchPerSecond = 5;
    public Transform Player;
    public float SearchDistance = 20F;
    public float Speed = 20F;

    private bool search = true;
    private float tempDistance = 0F;

	void Start () 
    {
        //Make sure that we dont dividde by 0 in our search timer coroutine
        if (SearchPerSecond == 0)
            SearchPerSecond = 1;

        //We do not want a negative distance
        if (SearchDistance < 0)
            SearchDistance = 0;
	}
	
	void Update () 
    {
        //Make sure we set a player in the inspector!
        if (Player != null)
        {
            //save distance so we do not have to call it multiple times
            tempDistance = Vector3.Distance(transform.position, Player.position);

            //Check if we are able to search
            if (search == true)
            {
                //Start the time
                StartCoroutine(SearchTimer());

                //Now check the distance to the player, if it is within the distance it will search for a new path
                if (tempDistance < SearchDistance)
                {
                    FindPath(transform.position, Player.position);
                }
            }

            //Make sure that we actually got a path! then call the new movement method
            if (Path.Count > 0)
            {
                MoveAI();
            }
        }
        else
        {
            Debug.Log("No player set in the inspector!");
        }
	}

    IEnumerator SearchTimer()
    {
        //Set search to false for an amount of time, and then true again.
        search = false;
        yield return new WaitForSeconds(1 / SearchPerSecond);
        search = true;
    }

    private void MoveAI()
    {
        //Make sure we are within distance + 1 added so we dont get stuck at exactly the search distance
        if (tempDistance < SearchDistance + 1)
        {       
            //if we get close enough or we are closer then the indexed position, then remove the position from our path list, 
            if (Vector3.Distance(transform.position, Path[0]) < 0.2F || tempDistance < Vector3.Distance(Path[0], Player.position)) 
            {
                Path.RemoveAt(0);
            }   

            if(Path.Count < 1)
                return;

            //First we will create a new vector ignoreing the depth (z-axiz).
            Vector3 ignoreZ = new Vector3(Path[0].x, Path[0].y, transform.position.z);
            
            //now move towards the newly created position
            transform.position = Vector3.MoveTowards(transform.position, ignoreZ, Time.deltaTime * Speed);  
        }
    }
}
