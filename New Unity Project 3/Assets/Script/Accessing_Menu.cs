using UnityEngine;
using System.Collections;

public class Accessing_Menu : MonoBehaviour {
	bool isOpen;
	public CanvasGroup Main_Menu;
	public CanvasGroup Player_Menu;
	public CanvasGroup Player_Menu_Stats;
	public CanvasGroup Dgimon_Menu;
	public CanvasGroup Dgimon_Menu_Stats;
	public CanvasGroup inventoryMenu;
	public Canvas sortingMenu;
	public Canvas sortingInventory;
	// Use this for initialization
	void Start () {
		isOpen = false;
		Main_Menu.alpha = 0;
		Main_Menu.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (isOpen)
			{
				Main_Menu.alpha = 1;
				Main_Menu.interactable = true;
				isOpen = false;
				sortingMenu.sortingOrder = 1;
			}
			else 
			{
				Main_Menu.alpha = 0;
				Main_Menu.interactable = false;
				Player_Menu.alpha = 0;
				Player_Menu.interactable = false;
				Player_Menu_Stats.alpha = 0;
				Player_Menu_Stats.interactable = false;
				Dgimon_Menu.alpha = 0;
				Dgimon_Menu.interactable = false;
				Dgimon_Menu_Stats.alpha = 0;
				Dgimon_Menu_Stats.interactable = false;
				inventoryMenu.alpha = 0;
				inventoryMenu.interactable = false;
				sortingInventory.sortingOrder = 0;
				isOpen = true;
			}
		}
	}
}
