using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DAY : MonoBehaviour {
	Text text1;
	public GameObject dayANight;
	float hour;
	public int Day;
	bool increased;
	// Use this for initialization
	void Start () {
		increased = false;
		Day = 0;
		text1 = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		hour = dayANight.GetComponent<DayAndNight> ().Hour;
		if (hour >0 && hour <0.1)
		{
			if (increased == true)
			{
				Day +=1;
				increased = false;
			}


		}
		if (hour > 0.1) 
		{
			increased = true;
		}
		text1.text = Day.ToString();
	}
}
