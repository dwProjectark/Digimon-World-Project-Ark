using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SlotScript : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler{

	public Item item;
	Image itemImage;
	 Text itemName;
	public Text itemAmount;
	 Text itemDesc;
	public int SlotNum;

	public CanvasGroup option;
	public CanvasGroup option2;
	public Canvas sortingOption;
	public Canvas sortingOption2;


	public Inventory_Player inventory;


	// Use this for initialization
	void Start () {
		//itemDesc.text = "H";

		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory_Player> ();
		itemImage = gameObject.transform.GetChild (0).GetComponent<Image> ();
		itemName = gameObject.transform.GetChild (1).GetComponent<Text> ();
		itemAmount = gameObject.transform.GetChild (2).GetComponent<Text> ();
		itemDesc = GameObject.FindGameObjectWithTag ("Description").GetComponent<Text>();
		itemDesc.enabled = false;
		option = GameObject.FindGameObjectWithTag ("Option").GetComponent<CanvasGroup>();
		option2 = GameObject.FindGameObjectWithTag ("Option2").GetComponent<CanvasGroup>();
		sortingOption = GameObject.FindGameObjectWithTag ("Option").GetComponent<Canvas>();
		sortingOption2 = GameObject.FindGameObjectWithTag ("Option2").GetComponent<Canvas>();

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (itemDesc);
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
		if (inventory.Items [SlotNum].amount != 0) {
						itemDesc.enabled = true;
				}
			itemDesc.text = inventory.Items[SlotNum].Description;
		
	}

	public void OnPointerExit(PointerEventData data)
	{
		itemDesc.enabled = false;
	}

	public void OnPointerDown(PointerEventData data)
	{
		if (SlotNum ==0&&inventory.Items [SlotNum].amount != 0) 
		{
			option.alpha = 1;
				option.interactable = true;
			sortingOption.sortingOrder = 2;
			option2.alpha = 0;
			option2.interactable = false;
			sortingOption2.sortingOrder = 0;
		

		}
		if (SlotNum == 1&&inventory.Items [SlotNum].amount != 0)
		{
			option.alpha = 0;
				option.interactable = false;
			sortingOption.sortingOrder = 0;
			option2.alpha = 1;
			option2.interactable = true;
			sortingOption2.sortingOrder = 2;
	

		}
	}





}
