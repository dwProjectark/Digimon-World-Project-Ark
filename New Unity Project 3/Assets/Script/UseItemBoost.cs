using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UseItemBoost : MonoBehaviour,IPointerDownHandler {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnPointerDown(PointerEventData data)
	{
		if (GameObject.FindGameObjectWithTag ("Slot").GetComponent<SlotScript> ().Amount > 0) 
		{
			GameObject.FindGameObjectWithTag ("Slot").GetComponent<SlotScript> ().Amount -= 1;
		}
	}
}
