using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UseItemBoost : MonoBehaviour,IPointerDownHandler {


	public  float _Brains;
	public  float  _Defense;
	public  float  _Discipline;
	public  float  _Happiness;
	public  float  _MaxHp;
	public  float  _MaxMp;
	public  float  _Offense;
	public  float  _Speed;
	public  float  _Weight;

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
			GameObject.FindGameObjectWithTag("partner").GetComponent<Partner_Stats>().Brains +=_Brains;
			GameObject.FindGameObjectWithTag("partner").GetComponent<Partner_Stats>().Defense +=_Defense;
			GameObject.FindGameObjectWithTag("partner").GetComponent<Partner_Stats>().Discipline +=_Discipline;
			GameObject.FindGameObjectWithTag("partner").GetComponent<Partner_Stats>().Happiness +=_Happiness;
			GameObject.FindGameObjectWithTag("partner").GetComponent<Partner_Stats>().MaxHp +=_MaxHp;
			GameObject.FindGameObjectWithTag("partner").GetComponent<Partner_Stats>().MaxMp +=_MaxMp;
			GameObject.FindGameObjectWithTag("partner").GetComponent<Partner_Stats>().Offense +=_Offense;
			GameObject.FindGameObjectWithTag("partner").GetComponent<Partner_Stats>().Speed +=_Speed;
			GameObject.FindGameObjectWithTag("partner").GetComponent<Partner_Stats>().Weight +=_Weight;

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
