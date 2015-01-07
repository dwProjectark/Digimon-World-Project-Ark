using UnityEngine;
using System.Collections;

public class DigimonBase : MonoBehaviour {
	
	//Variables For Digmon Leve go Here
	private string digimonlevel;

	//Variables for Digimon Type
	private string digimonType;

	//Variables for Digimon Element go here
	private string digimonElement;

	// Declaring list for Digivolution Level
	public enum Level
	{
		Fresh,Intraining,Rookie,Champion,Ultimate,Mega,Armor,SuperMega
	}
	public Level level;
	
	// Declaring list for Elements
	public enum Element
	{
		Air,Battle,Darkness,Earth,Filth,Fire,Holy,Ice,Mech
	}
	public Element element;
	
	//Declaring List for Type
	public enum Type
	{
		Virus,Data,Vaccine
	}
	public Type type;




	public bool isHungry;
	public bool isPoop;
	public bool isSleep;
	public float[] time_Hunger;
	public float[] time_Unhngery;
	public float[]	time_Pooping;
	public float[] time_Unpooping;
	public float[] time_Sleep;
	public float[] time_Unsleep;
	public GameObject DayANight;
	public CanvasGroup canvas1;
	public CanvasGroup canvas2;
	public CanvasGroup canvas3;
	float hour;
	int counter_Is_Hunger;
	int counter_IsNot_Hunger;
	int counter_Is_Pooping;
	int counter_IsNot_Pooping;
	int counter_Is_Sleeping;
	int counter_IsNot_Sleeping;
	public int stomachSize;




	
	
	// Use this for initialization
	void Start () 
	{




		// Declares
		isHungry = false;
		isPoop = false;
		isSleep = false;
		//time_Unhngery[time_Hunger];
		
		for (int i =0; i < time_Hunger.Length; i++)
		{
			time_Unhngery[i] = time_Hunger[i]+2f;
		}
		for (int i =0; i < time_Pooping.Length; i++)
		{
			time_Unpooping[i] = time_Pooping[i]+2f;
		}
		for (int i =0; i < time_Sleep.Length; i++)
		{
			time_Unsleep[i] = time_Sleep[i]+2f;
		}
		canvas1.alpha = 0;
		canvas2.alpha = 0;
		canvas3.alpha = 0;
		counter_Is_Hunger = 0;
		counter_IsNot_Hunger = 0;
		counter_Is_Pooping = 0;
		counter_IsNot_Pooping = 0;
		counter_Is_Sleeping = 0;
		counter_IsNot_Sleeping = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		hour = DayANight.GetComponent <DayAndNight>().hour;
		
		if (time_Hunger[counter_Is_Hunger] <= hour&&time_Hunger[counter_Is_Hunger]< time_Unhngery[counter_IsNot_Hunger]&&hour < time_Hunger[time_Hunger.Length-1]+1&&stomachSize >0)
		{
			
			isHungry = true;
			if (isHungry)
			{
				canvas1.alpha = 1;
				
				if (counter_Is_Hunger+1 < time_Hunger.Length)
				{
					counter_Is_Hunger ++;
					
				}
				else if (counter_Is_Hunger+1 >= time_Hunger.Length)
				{
					counter_Is_Hunger =0;
					
				}
			}
			
			
			
			
		}
		else if(time_Unhngery[counter_IsNot_Hunger]<= hour&&hour <time_Unhngery[time_Unhngery.Length-1]+1||stomachSize ==0 )
		{
			isHungry = false;
			
			if(!isHungry)
			{
				canvas1.alpha = 0;
				if (counter_IsNot_Hunger+1 < time_Unhngery.Length)
				{
					counter_IsNot_Hunger ++;
				}
				else if (counter_IsNot_Hunger+1 >= time_Unhngery.Length)
				{
					counter_IsNot_Hunger =0;
					
				}
			}
		}
		
		if (time_Pooping[counter_Is_Pooping] <= hour&&time_Pooping[counter_Is_Pooping]< time_Unpooping[counter_IsNot_Pooping]&&hour < time_Pooping[time_Pooping.Length-1]+1)
		{
			
			isPoop = true;
			
			if (isPoop)
			{
				
				canvas2.alpha = 1;
				if (counter_Is_Pooping+1 < time_Pooping.Length)
				{
					counter_Is_Pooping ++;
				}
				else if (counter_Is_Pooping+1 >= time_Pooping.Length)
				{
					counter_Is_Pooping =0;
				}
			}
			
			
			
			
		}
		else if(time_Unpooping[counter_IsNot_Pooping]<= hour&&hour <time_Unpooping[time_Unpooping.Length-1]+1)
		{
			isPoop = false;
			if(!isPoop)
			{
				canvas2.alpha = 0;
				//Debug.Log("Partner is not pooping" + counter_IsNot_Pooping);
				if (counter_IsNot_Pooping+1 < time_Unpooping.Length)
				{
					counter_IsNot_Pooping ++;
				}
				else if (counter_IsNot_Pooping +1>= time_Unpooping.Length)
				{
					counter_IsNot_Pooping =0;
				}
			}
		}
		
		if (time_Sleep[counter_Is_Sleeping] <= hour&&time_Sleep[counter_Is_Sleeping]< time_Unsleep[counter_IsNot_Sleeping]&&hour <time_Sleep[time_Sleep.Length-1]+1)
		{
			
			isSleep = true;
			if (isSleep)
			{
				canvas3.alpha = 1;
				if (counter_Is_Sleeping+1 < time_Sleep.Length)
				{
					counter_Is_Sleeping ++;
				}
				else if (counter_Is_Pooping+1 >= time_Sleep.Length)
				{
					counter_Is_Sleeping =0;
				}
			}
			
			
			
			
		}
		else if(time_Unsleep[counter_IsNot_Sleeping]<= hour&&hour <time_Unsleep[time_Unsleep.Length-1]+1)
		{
			isSleep = false;
			if(!isSleep)
			{
				canvas3.alpha = 0;
				if (counter_IsNot_Sleeping+1 < time_Sleep.Length)
				{
					counter_IsNot_Sleeping ++;
				}
				else if (counter_IsNot_Sleeping+1 >= time_Sleep.Length)
				{
					counter_IsNot_Sleeping =0;
				}
			}
		}
		
	}
}
