using UnityEngine;
using System.Collections;

public class Digivolution_stats : MonoBehaviour {
	public int AgeInDay;
	public int AgeInHour;
	public float EvoBrains;
	public float EvoCareMistakes;
	public int EvoChanceToDigivoulve;
	public float EvoDefense;
	public float EvoDiscipline;
	public float EvoHappiness;
	public float EvoMaxHP;
	public float EvoMaxMP;
	public float EvoOffense;
	public float EvoPoopCareMistakes;
	public float EvoSpeed;
	public float EvoWeight;
	bool evolving;
	public float rotation_speed;
	public GameObject digivoulve;
	public GameObject curr_digimon;
	float counter = 0 ;
	int i =0;
	GameObject[] otherCamera;
	public Camera digimonCamera;
	GameObject player_cam;
	Digimon_Behaviour script;
	public GameObject Aura;
	Object clone;
	NavMeshAgent nav;
	Animation animation;
	public AnimationClip[] _anim;
	public GameObject partner;
	public GameObject dayANight;
	public GameObject _Day;
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
	int day;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		otherCamera = GameObject.FindGameObjectsWithTag("MainCamera");
		script = GetComponent<Digimon_Behaviour> ();
		evolving = true;
		animation = GetComponent<Animation> ();


	}
	
	// Update is called once per frame
	void Update () {

		hour = dayANight.GetComponent<DayAndNight> ().Hour;
		ParBrains = partner.GetComponent<Partner_Stats> ().Brains;
		ParCareMistakes = partner.GetComponent<Partner_Stats> ().CareMistakes;
		ParDefense = partner.GetComponent<Partner_Stats> ().Defense;
		ParDiscipline = partner.GetComponent<Partner_Stats> ().Discipline;
		ParHappiness = partner.GetComponent<Partner_Stats> ().Happiness;
		ParMaxHP = partner.GetComponent<Partner_Stats> ().MaxHp;
		ParMaxMP = partner.GetComponent<Partner_Stats> ().MaxMp;
		ParOffence = partner.GetComponent<Partner_Stats> ().Offense;
		ParSpeed = partner.GetComponent<Partner_Stats> ().Speed;
		ParWeight = partner.GetComponent<Partner_Stats> ().Weight;
		day = _Day.GetComponent<DAY> ().Day;

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
