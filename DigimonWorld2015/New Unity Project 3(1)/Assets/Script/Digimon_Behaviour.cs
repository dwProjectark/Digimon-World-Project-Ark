using UnityEngine;
using System.Collections;

public class Digimon_Behaviour : MonoBehaviour {


	 Transform _player;
	float walk_speed;
	public AnimationClip[] anim;
	 Animation _animation;
	NavMeshAgent nav;
	public GameObject player;
	float speed;

	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag("Player").transform;
		speed = player.GetComponent<player> ().walkSpeed;

		_animation = GetComponent<Animation> ();
		//curr_speed = speed;
		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {



		if(Vector3.Distance(transform.position,_player.position)> nav.stoppingDistance )
		{
			_animation[anim[1].name].speed = speed;
			_animation.CrossFade(anim[1].name);
			nav.SetDestination(_player.position);
		}
		else 
		{
			_animation.CrossFade(anim[0].name);
		}


		//}


	}
}
