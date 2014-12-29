using UnityEngine;
using System.Collections;

public class Digimon_Button : MonoBehaviour {

	public CanvasGroup Digimon_Menu;
	public Canvas Digimon_Sort;
	public Canvas Player_Sort;
	public CanvasGroup Player_Menu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void call_Player_Menu()
	{
		Digimon_Menu.alpha = 1;
		Digimon_Menu.interactable = true;
		Digimon_Sort.sortingOrder = 1;


		Player_Sort.sortingOrder = 0;
		Player_Menu.alpha = 0;
		Player_Menu.interactable = false;



	}
}
