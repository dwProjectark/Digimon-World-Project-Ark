using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	string name;
	 static int TamerLevel = 0;
	static int bits;
	int timeOfDay;
	int Items;
	string Medals;
	int timesTrained;
	
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		 
		 


		TamerLevel =  GameObject.FindGameObjectsWithTag ("Mega").Length;
	
		//Debug.Log (TamerLevel);
	}




}

