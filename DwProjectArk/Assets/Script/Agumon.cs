using UnityEngine;
using System.Collections;

public class Agumon : Pathfinding {

	public int distance;
	public float speed;
	float curr_speed;
	public int turning_speed;
	public int Stoping_distance;
	public float slowing;
	public Transform player;
	bool isTurning;
	public AnimationClip[] anim;
	 Animation animation;

	// Use this for initialization
	void Start () {
		animation = GetComponent<Animation> ();
		curr_speed = speed;

	}
	
	// Update is called once per frame
	void Update () {
		animation.CrossFade(anim[0].name);
		var targetRotation = Quaternion.LookRotation(player.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turning_speed * Time.deltaTime);
		if (Vector3.Distance (transform.position, player.position) <= distance && Vector3.Distance (transform.position, player.position)>Stoping_distance) 
		{
			curr_speed = speed;
			FindPath(transform.position, player.position);
			if (Path.Count >0)
			{


				isTurning = true;


				/*Debug.Log(Quaternion.identity);
				if(transform.rotation == Quaternion.identity)
				{
					transform.position = Vector3.MoveTowards(transform.position, Path[0], Time.deltaTime * speed);
				}*/

				if (Path.Count > 0)
				{
					isTurning = false;
					if (!isTurning)
					{
						transform.position = Vector3.MoveTowards(transform.position, Path[0], Time.deltaTime * curr_speed);
						animation.CrossFade(anim[1].name);
						animation[anim[1].name].speed = curr_speed ;
						
						
					}
				}

			}
		




		}
		if (Vector3.Distance(transform.position,player.position) < Stoping_distance)
		{
			while (curr_speed != 0)
			{
				curr_speed -= slowing;


				if (curr_speed < 0)
				{
					curr_speed = 0;
				}
				Debug.Log(curr_speed);
			}

		}
	}

}


