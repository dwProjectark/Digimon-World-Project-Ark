using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hour : MonoBehaviour {
	Text textHour;
	Text textDay;
	Text textYear;
	public GameObject dayANight;

	float curr_hour;
	bool increased;
	 float hour;
	public float day;
	 float year;
	 int counter;

	// Use this for initialization
	void Start () 
	
	{
		textHour = GetComponent<Text> ();

		increased = false;
		day = 0;
		textDay = GetComponent<Text> ();

		year = 0;
		counter = 1;
		textYear = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

		//Day Counter
		hour = dayANight.GetComponent<DayAndNight> ().hour;
		textHour.text = hour.ToString("n0");



		// Day Stuff
		if (hour >0 && hour <0.1)
		{
			if (increased == true)
			{
				day +=1;
				increased = false;
			}	
			
		}
		if (hour > 0.1) 
		{
			increased = true;
		}
		textDay.text = day.ToString();



		// Year stuff
		if (day == 30*counter) 
		{
			if (increased == true)
			{
				year +=1;
				
				counter++;
				
			}
		}
		increased = true;

		textYear.text = year.ToString ();
	
	
	
	
	
	
	}


}
