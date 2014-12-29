using UnityEngine;
using System.Collections;

public class Player_Menu_Stats_Button : MonoBehaviour {


	public CanvasGroup Player_Menu_Stats;
	public CanvasGroup Main_Menu;
	public CanvasGroup Player_Menu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void call_Player_Menu()
	{
		Main_Menu.alpha = 0;
		Main_Menu.interactable = false;
		Player_Menu.alpha = 0;
		Player_Menu.interactable = false;
		Player_Menu_Stats.alpha = 1;
		Player_Menu_Stats.interactable = true;
	}
}
