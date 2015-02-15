using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SlotScript : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler{
	
	public Item item;
	Image itemImage;
	public Text itemName;
	public Text itemAmount;
	Text itemDesc;
	public int SlotNum;
	//public int Amount;
	public CanvasGroup option;
	public Inventory_Player inventory;

	
	
	// Use this for initialization
	void Start () {
		//itemDesc.text = "H";
		//Amount = 0;
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory_Player> ();
		itemImage = gameObject.transform.GetChild (0).GetComponent<Image> ();
		itemName = gameObject.transform.GetChild (1).GetComponent<Text> ();
		itemAmount = gameObject.transform.GetChild (2).GetComponent<Text> ();
		itemDesc = GameObject.FindGameObjectWithTag ("Description").GetComponent<Text>();
		itemDesc.enabled = false;
		option = GameObject.FindGameObjectWithTag ("Option").GetComponent<CanvasGroup> ();
		option.alpha = 0;
		option.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {

		//inventory.Items [SlotNum].amount = Amount;
		if (inventory.Items[SlotNum].name != null&&inventory.Items[SlotNum].amount !=0) {
			itemImage.enabled = true;
			itemName.enabled =  true;
			itemAmount.enabled = true;
			itemImage.sprite = inventory.Items[SlotNum].icon;
			itemName.text = inventory.Items[SlotNum].name;
			itemAmount.text = inventory.Items[SlotNum].amount.ToString();
			
			
		} 
		else 
		{
			itemImage.enabled = false;
			itemName.enabled = false;
			itemAmount.enabled = false;
		}
		
		
	}
	
	public void OnPointerEnter(PointerEventData data)
	{
		itemDesc.enabled = true;
		if (inventory.Items [SlotNum].amount != 0) {
						itemDesc.enabled = true;

				}
		else {
			itemDesc.enabled = false;
			}
		itemDesc.text = inventory.Items[SlotNum].Description;
		Debug.Log (SlotNum);


		
	}
	
	public void OnPointerExit(PointerEventData data)
	{
		itemDesc.enabled = false;
	}
	
	public void OnPointerDown(PointerEventData data)
	{
		if (inventory.Items [SlotNum].amount != 0) 
		{
			option.alpha =1;
			option.interactable = false;
		}
		GameObject.FindGameObjectWithTag ("Option").transform.GetChild(0).GetComponent<UseItemBoost>().SlotNumClone = SlotNum;
	}
	
	
	
	
}
