using UnityEngine;
using System.Collections;

public class DayAndNight : MonoBehaviour {

	public float slider;
	public float slider2;
	public float hour;

	private float tod;
	public Light sun;
	public int speed;
	private float myTime;  










	void OnGUI () {

		myTime += 1;


		if(hour >= 23.0)
		{
			hour = 0;
		}

		hour = myTime;


		tod= hour;










			//it is getting Midday
			
		}
	}

