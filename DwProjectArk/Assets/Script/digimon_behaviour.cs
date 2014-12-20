using UnityEngine;
using System.Collections;

public class digimon_behaviour : MonoBehaviour {
	 static public int power =0;
	static public int speed = 0;
	static public int endurance = 0;
	static public int hp = 0;
	static public int mp = 0;
	static public int Inteligance = 0;
	public string digimon_name;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (digimon_name == "Agumon") 
		{
			power = 10;
			speed = 5;
			endurance = 5;
			hp =100;
			mp = 100;
			Inteligance = 10;
			Debug.Log(power+" "+speed+ " "+endurance+" " +hp+" "+mp+" "+Inteligance);
		}
	}
}
