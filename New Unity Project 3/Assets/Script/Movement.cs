using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


	public   float intial_Walk_Speed ;
	public  float intial_Run_Speed ;
	public static float Walk_Speed;
	public static float Run_Speed;

	// Use this for initialization
	void Start () {
		Walk_Speed = intial_Walk_Speed;
		Run_Speed = intial_Run_Speed;
		Debug.Log (Walk_Speed);
		Debug.Log (Run_Speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
