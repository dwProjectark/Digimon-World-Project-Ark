using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour
{
	public int movementSpeed;
	[HideInInspector]public bool ismoving;

	[HideInInspector] public enum Movment
	{
		walk,
		walkFast,
		WalkSlow,
		Run,
		EnemyRun,
		RunSlow,
		RunFast
			
	}



	Movement movement;
	// Use this for initialization
	void Start () 
	{
		if (movement == Movment.walk&& ismoving==true) 
		{
			movementSpeed=2;
			animation.Play("Walk");
			animation.wrapMode=WrapMode.Loop;
		}
		else
		{
			animation.Play("Idle");
			animation.wrapMode=WrapMode.Loop;
			movementSpeed=2;
		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("e"))
		{
			animation.Play("Walk");
		}
	}

	/* Variables to use for Rain
	 * 
	 * BASIC MOTOR Character Controller MOTOR
	 * 	speed
	 *  close enoguh Distance
	 * 
	 * 
}
