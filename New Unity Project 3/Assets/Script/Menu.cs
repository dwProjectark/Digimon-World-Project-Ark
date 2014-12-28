using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public int	button_height = 15;
	public int button_width = 15;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (GUI.Button (new Rect (80, 200, button_width, button_height), "New Game"))
						
		{
			Application.LoadLevel(1);
		}
		GUI.Button (new Rect (400, 200, button_width, button_height),"Load Game");
	}
}
