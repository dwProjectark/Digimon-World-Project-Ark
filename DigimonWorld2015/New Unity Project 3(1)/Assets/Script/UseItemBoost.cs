using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UseItemBoost : MonoBehaviour,IPointerDownHandler {


	public  int _Brains;
	public  int  _Defense;
	public  int  _Discipline;
	public  int  _Happiness;
	public  int  _MaxHp;
	public  int  _MaxMp;
	public  int  _Offense;
	public  int _Speed;
	public  int  _Weight;

	public int filling;

	public int SlotNumClone;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//SlotNumClone = GameObject.FindGameObjectWithTag ("Slot").GetComponent<SlotScript> ().SlotNum;
	}
	public void OnPointerDown(PointerEventData data)
	{
		Debug.Log (SlotNumClone);
		if (GameObject.FindGameObjectWithTag ("Slot").GetComponent<SlotScript> ().inventory.Items[0].amount > 0&&SlotNumClone == 0) 
		{
			GameObject.FindGameObjectWithTag ("Slot").GetComponent<SlotScript> ().inventory.Items[0].amount -= 1;
			GameObject.FindGameObjectWithTag("partner").GetComponent<Partner_Stats>().brain +=_Brains;
			GameObject.FindGameObjectWithTag("partner").GetComponent<Partner_Stats>().defense +=_Defense;
			GameObject.FindGameObjectWithTag("partner").GetComponent<Partner_Stats>().discipline +=_Discipline;
			GameObject.FindGameObjectWithTag("partner").GetComponent<Partner_Stats>().happiness +=_Happiness;
			GameObject.FindGameObjectWithTag("partner").GetComponent<Partner_Stats>().hpMax +=_MaxHp;
			GameObject.FindGameObjectWithTag("partner").GetComponent<Partner_Stats>().mpMax+=_MaxMp;
			GameObject.FindGameObjectWithTag("partner").GetComponent<Partner_Stats>().offence +=_Offense;
			GameObject.FindGameObjectWithTag("partner").GetComponent<Partner_Stats>().speed +=_Speed;
			GameObject.FindGameObjectWithTag("partner").GetComponent<Partner_Stats>().weight +=_Weight;

		}

		 if(GameObject.FindGameObjectWithTag ("Slot").GetComponent<SlotScript> ().inventory.Items[1].amount > 0&&SlotNumClone == 1)
		{
			if (GameObject.FindGameObjectWithTag ("Slot").GetComponent<SlotScript> ().inventory.Items[1].amount > 0) 
			{
				
				if(GameObject.FindGameObjectWithTag("partner").GetComponent<DigimonBase>().stomachSize !=0)
				{
					GameObject.FindGameObjectWithTag ("Slot").GetComponent<SlotScript> ().inventory.Items[1].amount -= 1;
					GameObject.FindGameObjectWithTag("partner").GetComponent<DigimonBase>().stomachSize -= filling;
					if(GameObject.FindGameObjectWithTag("partner").GetComponent<DigimonBase>().stomachSize <0)
					{
						GameObject.FindGameObjectWithTag("partner").GetComponent<DigimonBase>().stomachSize = 0;
					}
				}
				
			}
		}
	
	}
}
