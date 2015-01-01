using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UseItemFood : MonoBehaviour,IPointerDownHandler {
	
	public int filling;


	public CanvasGroup foodOption;
	public CanvasGroup boostOption;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnPointerDown(PointerEventData data)
	{
		Debug.Log ("hello");
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