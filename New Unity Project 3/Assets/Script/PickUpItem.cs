using UnityEngine;
using System.Collections;

public class PickUpItem : MonoBehaviour {

	// Use thi for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter()
	{
		if (GameObject.FindGameObjectWithTag ("Player")) 
		{	
			if(gameObject.CompareTag("Hawk Radish"))
			{
				Debug.Log (GameObject.FindGameObjectWithTag("Slot").GetComponent<SlotScript>().itemAmount);
				GameObject.FindGameObjectWithTag("Slot").GetComponent<SlotScript>().Amount += 1;
				Destroy(gameObject);
			}
		}
	}
}
