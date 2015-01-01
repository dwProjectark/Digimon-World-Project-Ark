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
	

	public CanvasGroup foodOptionButton;
	public CanvasGroup boostOptionButton;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnPointerDown(PointerEventData data)
	{	

	
	

		Debug.Log ("hello");
	

			

		Debug.Log ("hello");
		if (GameObject.FindGameObjectWithTag ("Slot").GetComponent<SlotScript> ().inventory.Items[0].amount > 0) {
			GameObject.FindGameObjectWithTag ("Slot").GetComponent<SlotScript> ().inventory.Items[0].amount -= 1;
			GameObject.FindGameObjectWithTag ("partner").GetComponent<Partner_Stats> ().Brains += _Brains;
			GameObject.FindGameObjectWithTag ("partner").GetComponent<Partner_Stats> ().Defense += _Defense;
			GameObject.FindGameObjectWithTag ("partner").GetComponent<Partner_Stats> ().Discipline += _Discipline;
			GameObject.FindGameObjectWithTag ("partner").GetComponent<Partner_Stats> ().Happiness += _Happiness;
			GameObject.FindGameObjectWithTag ("partner").GetComponent<Partner_Stats> ().MaxHp += _MaxHp;
			GameObject.FindGameObjectWithTag ("partner").GetComponent<Partner_Stats> ().MaxMp += _MaxMp;
			GameObject.FindGameObjectWithTag ("partner").GetComponent<Partner_Stats> ().Offense += _Offense;
			GameObject.FindGameObjectWithTag ("partner").GetComponent<Partner_Stats> ().Speed += _Speed;
			GameObject.FindGameObjectWithTag ("partner").GetComponent<Partner_Stats> ().Weight += _Weight;
			
		}
	
}
}