using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hour : MonoBehaviour {
	 Text text1;
	public GameObject dayANight;
	float hour;
	float curr_hour;

	// Use this for initialization
	void Start () {
		text1 = GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		hour = dayANight.GetComponent<DayAndNight> ().Hour;
		text1.text = hour.ToString("n0");

	}


}
