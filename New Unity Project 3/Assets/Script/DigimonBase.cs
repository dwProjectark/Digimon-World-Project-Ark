using UnityEngine;
using System.Collections;

public class DigimonBase : MonoBehaviour {

	public string Level;
	public string Atrribute;
	public string Element;
	public bool isHungry;
	public bool isPoop;
	public bool isSleep;
	public float[] time_Hunger;
	public float[] time_Unhngery;
	public float[]	time_Pooping;
	public float[] time _Unpooping;
	public float[] time_Sleep;
	public float[] time_Unsleep;
	public GameObject DayANight;
	public CanvasGroup canvas1;
	public CanvasGroup canvas2;
	public CanvasGroup canvas3;
	float hour;
	int counter_Is;
	int counter_IsNot;


	// Use this for initialization
	void Start () {
		isHungry = false;
		//time_Unhngery[time_Hunger];

		for (int i =0; i < time_Hunger.Length; i++)
		{
			time_Unhngery[i] = time_Hunger[i]+2f;
		}
		for (int i =0; i < time_Hunger.Length; i++)
		{
			time_Unhngery[i] = time_Hunger[i]+2f;
		}
		for (int i =0; i < time_Hunger.Length; i++)
		{
			time_Unhngery[i] = time_Hunger[i]+2f;
		}
		canvas.alpha = 0;
		counter_Is = 0;
		counter_IsNot = 0;

	}
	
	// Update is called once per frame
	void Update () {
		hour = DayANight.GetComponent <DayAndNight>().Hour;

		if (time_Hunger[counter_Is] <= hour&&time_Hunger[counter_Is]< time_Unhngery[counter_IsNot])
		{

			isHungry = true;
			if (isHungry)
			{
				canvas.alpha = 1;
				if (counter_Is+1 < time_Hunger.Length)
				{
					counter_Is ++;
				}
				else if (counter_Is+1 >= time_Hunger.Length)
				{
					counter_Is =0;
				}
			}




		}
		else if(time_Unhngery[counter_IsNot]<= hour)
		{
			isHungry = false;
			if(!isHungry)
			{
				canvas.alpha = 0;
				if (counter_IsNot < time_Hunger.Length)
				{
					counter_IsNot ++;
				}
				else if (counter_IsNot >= time_Hunger.Length)
				{
					counter_IsNot =0;
				}
			}
		}


	}
}
