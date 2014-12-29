using UnityEngine;
using System.Collections;

public class Digimon_Menu_Stats_Button : MonoBehaviour {

	public CanvasGroup Digimon_Menu_Stats;
	public CanvasGroup Main_Menu;
	public CanvasGroup Digimon_Menu;
	
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
		Digimon_Menu.alpha = 0;
		Digimon_Menu.interactable = false;
		Digimon_Menu_Stats.alpha = 1;
		Digimon_Menu_Stats.interactable = true;
	}
}

