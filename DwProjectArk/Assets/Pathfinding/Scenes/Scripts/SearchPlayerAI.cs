using UnityEngine;
using System.Collections;

public class SearchPlayerAI : Pathfinding
{
    public int SearchesPerSecond;
    public float MinDistanceToPlayer = 2.0f;
    public float AISpeed = 20.0f;
    public float AIPivotPointYValueOverGround = 0.0f;

    private Transform _player;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            _player = player.transform;
            StartCoroutine(FindPathTimer());
        }
        else
            Debug.Log("Error: No gameobject found with the tag Player!");
    }

    void FixedUpdate()
    {
        if (Path.Count > 0)
        {
            MoveSearchingAI();
        }
    }

    //A test move function, can easily be replaced
    public void MoveSearchingAI()
    {
        if (Vector3.Distance(transform.position, _player.position) > MinDistanceToPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, Path[0] + new Vector3(0, AIPivotPointYValueOverGround, 0), Time.deltaTime * AISpeed);
            if (Vector3.Distance(transform.position, Path[0]) < 0.4F)
            {
                Path.RemoveAt(0);
            }
        }
    }

    IEnumerator FindPathTimer()
    {
        FindPath(transform.position, _player.position);
        yield return new WaitForSeconds((float)(1.0f / SearchesPerSecond));
        StartCoroutine(FindPathTimer());
    }
}
