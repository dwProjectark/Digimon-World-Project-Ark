using UnityEngine;
using System.Collections;
using Pathfinding;

public class AIPather : MonoBehaviour {
	public Transform target;

	Seeker seeker;
	Path path;
	int currentWayPoint;

	float speed = 10;

	CharacterController characterController;

	float maxWayPointDistance = 2f;

	// Use this for initialization
	void Start () {
		seeker = GetComponent<Seeker>();
		seeker.StartPath (transform.position, target.position, OnPathComplete);
		characterController = GetComponent<CharacterController> ();
	}

	public void OnPathComplete(Path p)
	{
		if (!p.error) {
						path = p;
						currentWayPoint = 0;
				}
		else {
			Debug.Log(p.error);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		if (path == null) {
					return;
				}
		if (currentWayPoint >= path.vectorPath.Count) {
					return;
				}
		Vector3 dir = (path.vectorPath [currentWayPoint] - transform.position).normalized * speed;
		characterController.SimpleMove (dir);
		if (Vector3.Distance (transform.position, path.vectorPath [currentWayPoint]) < maxWayPointDistance) {

						currentWayPoint++;
				}
	}
}
