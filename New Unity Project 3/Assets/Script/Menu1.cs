using UnityEngine;
using System.Collections;




public class Menu1 : MonoBehaviour {
	public GUIStyle test;
	public GUIStyle test2;
	public GUIStyle test3;
	public GUIStyle test4;
	 bool isPressed;
	// Use this for initialization
	void Start () {
		isPressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (isPressed == false)
			{
				isPressed = true;
			}
			else if (isPressed)
			{
				isPressed = false;
			}
		}
	}

	void OnGUI() {

		if (isPressed == true) {
					GUI.Box(new Rect(0,20,Screen.width,100),"Main Menu",test);
					GUI.BeginGroup(new Rect(0,Screen.height/3,Screen.width/2,Screen.height/2),"",test2);
						GUI.BeginGroup(new Rect(30,20,Screen.width/2-60,50),"Year                                   Day",test3);
						GUI.EndGroup();
						GUI.BeginGroup(new Rect(30,100,Screen.width/2-60,100),"ITEM            DIGMON              PLAYER",test4);
						GUI.EndGroup();
						GUI.BeginGroup(new Rect(30,210,Screen.width/2-60,100),"Praise            SCOLD              SLEEP",test4);
						GUI.EndGroup();
					GUI.EndGroup();
				}
	}
}
