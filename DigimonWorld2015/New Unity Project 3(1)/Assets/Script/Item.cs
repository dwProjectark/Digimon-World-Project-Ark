using UnityEngine;
using System.Collections;


public class Item  {

	public string name;
	public int id;
	public string Description;
	public  int amount;
	public Sprite icon;
	public GameObject itemModel;
	public int price;
	public TypeItem type; 



	public enum TypeItem
	{
		Food,
		StatType,
		DigivoultionItem
	}

	public Item(string _name,int _id,string desc,int _amount,int _price,TypeItem _type)
	{
		name = _name;
		id = _id;
		Description = desc;
		amount = _amount;
		icon = Resources.Load<Sprite>(""+name);
		price = _price;
		type = _type;

	}
	public Item()
	{

	}

}
