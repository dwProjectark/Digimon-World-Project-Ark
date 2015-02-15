using UnityEngine;
using System.Collections;

public class Accessing_Menu : MonoBehaviour {
	bool isOpen;
	public CanvasGroup Main_Menu;
	public CanvasGroup Player_Menu;
	public CanvasGroup Player_Menu_Stats;
	public CanvasGroup Dgimon_Menu;
	public CanvasGroup Dgimon_Menu_Stats;
	public CanvasGroup inventory_Menu;
	public Canvas mainMenu;
	public Canvas playerMenu;
	public Canvas playerMenuStats;
	public Canvas digimonMenu;
	public Canvas digimonMenuStats;
	public Canvas inventoryMenu;
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
				mainMenu.sortingOrder = 1;
			}
			else 
			{
				Main_Menu.alpha = 0;
				Main_Menu.interactable = false;
				mainMenu.sortingOrder = 0;
				Player_Menu.alpha = 0;
				Player_Menu.interactable = false;
				playerMenu.sortingOrder =0;
				Player_Menu_Stats.alpha = 0;
				Player_Menu_Stats.interactable = false;
				playerMenuStats.sortingOrder = 0;
				Dgimon_Menu.alpha = 0;
				Dgimon_Menu.interactable = false;
				digimonMenu.sortingOrder = 0;
				Dgimon_Menu_Stats.alpha = 0;
				Dgimon_Menu_Stats.interactable = false;
				digimonMenuStats.sortingOrder = 0;
				inventory_Menu.alpha = 0;
				inventory_Menu.interactable = false;
				inventoryMenu.sortingOrder =0;
				isOpen = true;
			}
		}
	}
}
