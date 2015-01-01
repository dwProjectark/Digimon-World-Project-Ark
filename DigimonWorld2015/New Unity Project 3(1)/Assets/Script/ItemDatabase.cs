using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item>_items = new List<Item>();
	// Use this for initialization
	void Start () {
		_items.Add (new Item ("Hawk Radish", 0, "Like a hawk your stats will rise",1, 200, Item.TypeItem.StatType));
		_items.Add (new Item ("Meat", 1, "gjfapihjhriea;o",1, 200, Item.TypeItem.Food));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
