using UnityEngine;
using System.Collections;

public class Traning : MonoBehaviour {
	public int brains;
	public int defense;
	public int maxHp;
	public int maxMp;
	public int offence;
	public int speed;
	public GameObject DayANight;
	public GameObject player;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay()
	{
		if (GameObject.FindGameObjectWithTag ("Player"))
		{
			if(Input.GetKeyDown(KeyCode.E))
			{	
				if(GameObject.FindGameObjectWithTag ("partner").GetComponent<DigimonBase> ().tirdeness == 100)
				{
					if(brains > 1)
					{
						brains = 1;
					}
					if(defense > 1)
					{
						defense = 1;
					}
					if(maxHp > 1)
					{
						maxHp = 1;
					}
					if(maxMp > 1)
					{
						maxMp = 1;
					}
					if(offence > 1)
					{
						offence = 1;
					}
					if(speed > 1)
					{
						speed = 1;
					}
				}
				GameObject.FindGameObjectWithTag("partner").GetComponent<Digimon_Behaviour>().isBrains = true;
				GameObject.FindGameObjectWithTag ("partner").GetComponent<Partner_Stats> ().Brains += brains;
				GameObject.FindGameObjectWithTag ("partner").GetComponent<Partner_Stats> ().Defense += defense;
				GameObject.FindGameObjectWithTag ("partner").GetComponent<Partner_Stats> ().MaxHp += maxHp;
				GameObject.FindGameObjectWithTag ("partner").GetComponent<Partner_Stats> ().MaxMp += maxMp;
				GameObject.FindGameObjectWithTag ("partner").GetComponent<Partner_Stats> ().Offense += offence;
				GameObject.FindGameObjectWithTag ("partner").GetComponent<Partner_Stats> ().Speed += speed;
				GameObject.FindGameObjectWithTag ("partner").GetComponent<DigimonBase> ().tirdeness += 5;
				DayANight.GetComponent<DayAndNight>().slider += 0.042f;
				player.GetComponent<player>().enabled = false;
				player.GetComponent<LookAt>().enabled = true;

			}
			if(Input.GetKeyDown(KeyCode.Space))
			{
				player.GetComponent<player>().enabled = true;
				player.GetComponent<LookAt>().enabled = false;
				GameObject.FindGameObjectWithTag("partner").GetComponent<Digimon_Behaviour>().isBrains = false;
			}
		}
	}
}
