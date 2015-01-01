using UnityEngine;
using System.Collections;

public class PickUpItem : MonoBehaviour {

	public int itemCap;
	// Use thi for initialization
	void Start () {
		//Amount = GameObject.FindGameObjectWithTag ("Slot").GetComponent<SlotScript> ().SlotNum;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter()
	{
		if (GameObject.FindGameObjectWithTag ("Player")) 
		{	
			if(gameObject.CompareTag("Hawk Radish")&&GameObject.FindGameObjectWithTag("Slot").GetComponent<SlotScript>().inventory.Items[0].amount<=itemCap)
			{
				Debug.Log (GameObject.FindGameObjectWithTag("Slot").GetComponent<SlotScript>().itemAmount);
				GameObject.FindGameObjectWithTag("Slot").GetComponent<SlotScript>().inventory.Items[0].amount += 1;
				Destroy(gameObject);
			}
			else if(gameObject.CompareTag("Meat"))
			{
				Debug.Log (GameObject.FindGameObjectWithTag("Slot").GetComponent<SlotScript>().itemAmount&&GameObject.FindGameObjectWithTag("Slot").GetComponent<SlotScript>().inventory.Items[0].amount<=itemCap);
				GameObject.FindGameObjectWithTag("Slot").GetComponent<SlotScript>().inventory.Items[1].amount += 1;
				Destroy(gameObject);
			}
		}
	}
}
