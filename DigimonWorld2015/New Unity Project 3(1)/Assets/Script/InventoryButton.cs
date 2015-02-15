using UnityEngine;
using System.Collections;

public class InventoryButton : MonoBehaviour {
	public CanvasGroup playerMenu;
	public CanvasGroup digimonMenu;
	public CanvasGroup mainMenu;
	public CanvasGroup inventoryMenu;
	public Canvas inventory;
	public Canvas Main_Menu;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void call_Inventory_menu()
	{
		playerMenu.alpha = 0;
		playerMenu.interactable = false;
		digimonMenu.alpha = 0;
		digimonMenu.interactable = false;
		mainMenu.alpha = 0;
		mainMenu.interactable = false;
		Main_Menu.sortingOrder = 0;
		inventoryMenu.alpha = 1;
		inventoryMenu.interactable = true;
		inventory.sortingOrder = 1;

	}
}
