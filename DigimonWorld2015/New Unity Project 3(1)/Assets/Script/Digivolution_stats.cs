using UnityEngine;
using System.Collections;

public class Digivolution_stats : MonoBehaviour {
	public int AgeInDay;
	public int AgeInHour;
	public int EvoChanceToDigivoulve;
	public float EvoCareMistakes;
	
	//these are target digimon stats? (the digimon being digivolved into)
	public float EvoBrains;
	public float EvoDefense;
	public float EvoDiscipline;
	public float EvoHappiness;
	public float EvoMaxHP;
	public float EvoMaxMP;
	public float EvoOffense;
	public float EvoPoopCareMistakes;
	public float EvoSpeed;
	public float EvoWeight;
	
	bool evolving = false;
	public float rotation_speed;
	public GameObject digivoulve; //change this to targ_digimon as it is the target digimon to become and it matches the format of curr_digimon
	public GameObject curr_digimon;
	
	float counter = 0 ;
	
	int i =0; 
	
	GameObject[] otherCamera;
	public Camera digimonCamera;
	GameObject player_cam;
	
	Digimon_Behaviour script; ///maybe call this scr_Behavior or digimon_Behavior to be more descriptive
	public GameObject Aura;
	Object clone;
	
	NavMeshAgent nav;
	Animation animation;
	public AnimationClip[] _anim;
	
	public GameObject partner;

	public GameObject _Day;
	
	///these are partner stats?
	float ParBrains;
	float ParCareMistakes;
	float ParDefense;
	float ParDiscipline;
	float ParHappiness;
	float ParMaxHP;
	float ParMaxMP;
	float ParOffence;
	float ParPoopCareMistakes;
	float ParSpeed;
	float ParWeight;
	float hour;
	float day;
	
	//additional needed variables
	DayAndNight script_dayAndNight; ///this can most likely replay gameObject dayAndNight at some point.
	Partner_Stats partner_Stats;
	Hour scr_Hour;
	
	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		otherCamera = GameObject.FindGameObjectsWithTag("MainCamera");
		script = GetComponent<Digimon_Behaviour> ();
		evolving = true;
		animation = GetComponent<Animation> ();
		
		//to reduce the GetComponent calls we use the new references created to hold the values

		partner_Stats = partner.GetComponent<Partner_Stats>();
		scr_Hour = _Day.GetComponent<Hour>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//the getComponent sections here can now be replaced with their respective references.
		hour = 1; //filler//hour = script_dayAndNight.hour;
		ParBrains = partner_Stats.Brains;
		ParCareMistakes = partner_Stats.CareMistakes;
		ParDefense = partner_Stats.Defense;
		ParDiscipline = partner_Stats.Discipline;
		ParHappiness = partner_Stats.Happiness;
		ParMaxHP = partner_Stats.MaxHp;
		ParMaxMP = partner_Stats.MaxMp;
		ParOffence = partner_Stats.Offense;
		ParSpeed = partner_Stats.Speed;
		ParWeight = partner_Stats.Weight;
		day = 1;//day = scr_Hour.day;
		
		if(AgeInDay<=day&&AgeInHour<=hour&&ParBrains >=EvoBrains && ParCareMistakes >=EvoCareMistakes&&ParDefense>=EvoDefense&& ParDiscipline>=EvoDiscipline
		   &&ParHappiness>=EvoHappiness&&ParMaxHP>=EvoMaxHP&&ParMaxMP>=EvoMaxMP&&ParOffence>=EvoOffense&&ParSpeed>=EvoSpeed&&ParWeight>=EvoWeight)
		{
			Destroy(script);
			nav.speed = 0;
			animation.CrossFade(_anim[0].name);
			digimonCamera.enabled = true;
			
			if (evolving)
			{
				clone = Instantiate(Aura,transform.position,transform.rotation);
				evolving =false;
			}
			if (otherCamera[0+i].camera.enabled == true)
			{
				player_cam = otherCamera[0+i];
			}
			else
				i ++;
			//Destroy (clone);
			transform.Rotate(0, rotation_speed * Time.deltaTime,0); 
			digimonCamera.enabled = true;
			counter += 1*Time.deltaTime*rotation_speed/360;
			
			
		}
		//evolving = false;
		if (counter > 5)
		{
			
			Destroy(clone);
			digimonCamera.enabled = false;
			player_cam.camera.enabled = true;
			//Debug.Log (digimonCamera.enabled);
			//Debug.Log (player_cam.camera.enabled);
			Instantiate(digivoulve,transform.position,transform.rotation);
			Destroy(curr_digimon);
			
			
		}
	}
	void OnGUI() {
		//Brains = GUI.HorizontalSlider(new Rect(25, 50f, 100f, 30f), Brains, 0.0F, 100.0F);
		//CareMistakes = GUI.HorizontalSlider(new Rect(25, 75f, 100f, 30f), CareMistakes, 0.0F, 10.0F);
		//Defense = GUI.HorizontalSlider(new Rect(25, 100f, 100f, 30f), Defense, 0.0F, 100.0F);
		//MaxHP = GUI.HorizontalSlider(new Rect(25, 125f, 250, 30f), MaxHP, 0.0F, 1000.0F);
		
	}
	
}