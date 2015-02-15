using UnityEngine;
using System.Collections;

public class PickUpItem : MonoBehaviour {
	
	public int itemCap;
	int SlotNumCopy;
	bool found = false;
	// Use thi for initialization
	void Start () {
		//Amount = GameObject.FindGameObjectWithTag ("Slot").GetComponent<SlotScript> ().SlotNum;
	}
	
	// Update is called once per frame
	void Update () {
		SlotNumCopy = GameObject.FindGameObjectWithTag ("Slot").GetComponent<SlotScript> ().SlotNum;
	}
	void OnTriggerEnter()
	{

		if (GameObject.FindGameObjectWithTag ("Player")) 
		{	
			addItemToInventory("Hawk Radish",0);
			addItemToInventory("Meat",1);
//			
		}
	}

	void addItemToInventory(string itemName,int itemID)
	{
		if(gameObject.CompareTag(itemName))
		{
			for(int i = 0;i < GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory_Player>().Slots.Count;i++)
			{
				if (GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory_Player>().Items[i].name == itemName)
				{
					found = true;
					break;
				}
			}
			if(!found)
				GameObject.Find ("Inventory").GetComponent<Inventory_Player>().addItem(itemID);
			for(int i =0;i< GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory_Player>().Slots.Count;i++)
			{
				if(GameObject.Find ("Inventory").GetComponent<Inventory_Player>().Items[i].id == itemID)
				{
					GameObject.FindGameObjectWithTag("Slot").GetComponent<SlotScript>().inventory.Items[i].amount += 1;
					break;
				}
			}
			Destroy(gameObject);
			
			
		}
	}
}
