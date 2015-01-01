using UnityEngine;
using System.Collections;

public class PLAYER_BUTTON : MonoBehaviour {

	public CanvasGroup Player_Menu;
	public Canvas Player_Sort;
	public Canvas Digimon_Sort;
	public CanvasGroup Digimon_Menu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void call_Player_Menu()
	{
		Player_Menu.alpha = 1;
		Player_Menu.interactable = true;
		Player_Sort.sortingOrder = 1;
		Digimon_Menu.alpha = 0;
		Digimon_Menu.interactable = false;
		Digimon_Sort.sortingOrder = 0;
	}
}
