using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DigiTime : MonoBehaviour 
{


		// Keeps track of time doesnt reset

	Text tod;
	public Text hourText;
	public GameObject dayObjects;
	public GameObject nightObjects;
	public Color dayAmbience;
	public Color nightAmbience;
	public Color eveningAmbience;
	public Color morningAmbience;
	[HideInInspector]	public	int hour;

	[HideInInspector]	public	int day;
	[HideInInspector]   public	int year;
	public Material daySky;
	public Material nightSky;
		
		//Resets after reaching next time point
	[HideInInspector] public	int clockHour;
	[HideInInspector] public	int clockDay;
	[HideInInspector] public	int clockYear;

		
		
		//Used to help with sexy command and also with time ifstament
		float second;
		float start;
		
		
		// If time puase is false clock runs if true seconds equal seconds until false
		bool timepuase;
		float pauseSecond;

		
		// Used to seprate times of day
		enum TimeOfDay
		{
			Morning,
			Day,
			Evening,
			Night
		}
		
		// Used to call times of day
		TimeOfDay timeofday; 
		string timeOfDayString;



		//Acess information from partner states
		












		// Use this for initialization
		void Start ()
			// Timepuase is set to false while start is set to Zero
		{




		hourText.GetComponent<Text> ();
			timepuase = false;
			//
			start = 0.0f;
			
			pauseSecond = second;

		hour = 0;
		//for partner stuff


		}
		
		// Update is called once per frame
		void Update ()
			
		{

			//If the time puase is true seconds will equal seconds which will stop time
			

			if (timepuase == true) 
			{
				second = pauseSecond;
			}

			if (Input.GetKeyDown(KeyCode.P))
			{
			timepuase = true;
			}

			if (Input.GetKeyDown(KeyCode.Space)) 
			{
			timepuase = false;
			}
			
			// Seconds equal will equal time.time and 
		second +=  Time.deltaTime;
			if (second > 1.0f)
			{
				hour++;
				start=Time.deltaTime;
				clockHour++;
				second =0;
			}

			Debug.Log(hour);
			if(clockHour==24)
			{
				clockHour=0;
				day++;
				clockDay++;
				
			}
			if(clockDay == 30)
			{
				clockDay =0;
				clockYear++;
				year++;
			}
			
			
			
			
// Defines wht section of the day it is

			
			if(clockHour >=8 && clockHour <=15)
			{
				timeofday=TimeOfDay.Day;
			}
			
			if(clockHour >=16 && clockHour <=19)
			{
				timeofday=TimeOfDay.Evening;
			}
			
			if (clockHour >=20 || clockHour <=3)
			{
				timeofday=TimeOfDay.Night;
			}
			if(clockHour >= 4 && clockHour <= 7)
			{
				timeofday=TimeOfDay.Morning;
			}



	// Will hide the objects depending on time of day
		if(timeofday==TimeOfDay.Day || timeofday == TimeOfDay.Evening)
		{
			dayObjects.SetActive (true);
			nightObjects.SetActive (false);
			RenderSettings.skybox=daySky;
		}

		if(timeofday==TimeOfDay.Night || timeofday == TimeOfDay.Morning)
		{
			dayObjects.SetActive (false);
			nightObjects.SetActive (true);
			RenderSettings.skybox=nightSky;
		}

	// Change Ambient color of day and night time
		if (timeofday == TimeOfDay.Morning) 
		{
			RenderSettings.ambientLight =morningAmbience;
		}


		if (timeofday == TimeOfDay.Day) 
		{
			RenderSettings.ambientLight = dayAmbience;

		}

		if (timeofday == TimeOfDay.Night) 
		{
			RenderSettings.ambientLight =nightAmbience;
		}

		if (timeofday == TimeOfDay.Evening) 
		{
			RenderSettings.ambientLight =eveningAmbience;
		}




		hourText.text = "Hour " +clockHour.ToString();

		}
	}
