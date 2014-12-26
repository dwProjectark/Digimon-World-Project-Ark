using UnityEngine;
using System.Collections;

public class Greymon : Pathfinding {
	
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
	Transform pre_digimon;
	
	// Use this for initialization
	void Start () {

		animation = GetComponent<Animation> ();
		curr_speed = speed;
		player = GameObject.Find ("HUman").transform;
	
		
	}
	
	// Update is called once per frame
	void Update () {
		animation.CrossFade(anim[0].name);
		if (Vector3.Distance (transform.position, player.position) <= distance && Vector3.Distance (transform.position, player.position)>Stoping_distance+3) 
		{
			FindPath(transform.position, player.position);
			if (Path.Count >0)
			{
				curr_speed = speed;
				isTurning = true;
				var targetRotation = Quaternion.LookRotation(player.position - transform.position);
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turning_speed * Time.deltaTime);
				
				/*Debug.Log(Quaternion.identity);
				if(transform.rotation == Quaternion.identity)
				{
					transform.position = Vector3.MoveTowards(transform.position, Path[0], Time.deltaTime * speed);
				}*/
				
			}
			
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
		if (Vector3.Distance(transform.position,player.position) <= Stoping_distance)
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
