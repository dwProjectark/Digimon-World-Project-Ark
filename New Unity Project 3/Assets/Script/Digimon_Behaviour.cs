using UnityEngine;
using System.Collections;

public class Digimon_Behaviour : MonoBehaviour {


	 Transform _player;
	public Transform brainTraning;
	public Transform defenceTraning;
	public Transform maxHpTraning;
	public Transform maxMpTraning;
	public Transform powerTraning;
	public Transform speedTraning;
	float walk_speed;
	public AnimationClip[] anim;
	 Animation _animation;
	NavMeshAgent nav;
	public GameObject player;
	float speed;
	public bool isBrains;
	public bool isDefence;
	public bool isMaxhp;
	public bool isMaxmp;
	public bool isPower;
	public bool isSpeed;

	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag("Player").transform;
		speed = player.GetComponent<player> ().walkSpeed;

		_animation = GetComponent<Animation> ();
		//curr_speed = speed;
		nav = GetComponent<NavMeshAgent> ();
		isBrains = false;
		isDefence = false;
		isMaxhp = false;
		isMaxmp = false;
		isPower = false;
		isSpeed = false;
	}
	
	// Update is called once per frame
	void Update () {


		Debug.Log (isBrains == true&&Vector3.Distance(transform.position,brainTraning.position)> nav.stoppingDistance);
		if(Vector3.Distance(transform.position,_player.position)> nav.stoppingDistance&&!isBrains&& !isDefence&&!isMaxhp&&!isMaxmp&&!isPower&&!isSpeed)
		{
			_animation[anim[1].name].speed = speed;
			_animation.CrossFade(anim[1].name);
			Debug.Log(anim[1].name);
			nav.SetDestination(_player.position);
		}

		else if (isBrains == true&&Vector3.Distance(transform.position,brainTraning.position)> nav.stoppingDistance) 
		{
			_animation[anim[1].name].speed = speed;
			_animation.Play(anim[1].name);
			nav.SetDestination(brainTraning.position);
		}
		else 
		{
			_animation.CrossFade(anim[0].name);
		}
		/*if (isDefence == true&&Vector3.Distance(transform.position,defenceTraning.position)> nav.stoppingDistance)
		{

			nav.SetDestination(defenceTraning.position);
		}
		else
			_animation.CrossFade(anim[0].name);
		if (isMaxhp == true&&Vector3.Distance(transform.position,maxHpTraning.position)> nav.stoppingDistance)
		{

			nav.SetDestination(maxHpTraning.position);
		}
		else
			_animation.CrossFade(anim[0].name);
		if (isMaxmp == true&&Vector3.Distance(transform.position,maxMpTraning.position)> nav.stoppingDistance)
		{
			nav.SetDestination(maxMpTraning.position);
		}
		else
			_animation.CrossFade(anim[0].name);
		if (isPower == true&&Vector3.Distance(transform.position,powerTraning.position)> nav.stoppingDistance)
		{

			nav.SetDestination(powerTraning.position);
		}
		else
			_animation.CrossFade(anim[0].name);
		if (isSpeed == true&&Vector3.Distance(transform.position,speedTraning.position)> nav.stoppingDistance)
		{
		
			nav.SetDestination(speedTraning.position);
		}
		else
			_animation.CrossFade(anim[0].name);*/



		//}


	}
}
