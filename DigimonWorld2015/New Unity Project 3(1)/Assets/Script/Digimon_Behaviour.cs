using UnityEngine;
using System.Collections;

public class Digimon_Behaviour : MonoBehaviour {


	 Transform _player;
	float walk_speed;
	
	NavMeshAgent nav;
	public GameObject player;
	float speed;

	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag("Player").transform;
		speed = player.GetComponent<player> ().runSpeed;

		//curr_speed = speed;
		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {



		if(Vector3.Distance(transform.position,_player.position)> nav.stoppingDistance )
		{
			animation.Play("Run");
			nav.SetDestination(_player.position);
		}
		else 
		{
			animation.Play("Idle");
		}


		//}


	}
}
