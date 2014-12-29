using UnityEngine;
using System.Collections;




public class Menu1 : MonoBehaviour {
	public GUIStyle test;
	public GUIStyle test2;
	public GUIStyle test3;
	public GUIStyle test4;
	public GUIStyle Inventory_Icon;
	public GUIStyle Digimon_Icon;
	public GUIStyle Player_Icon;
	public GUIStyle Praise_Icon;
	public GUIStyle Scold_Icon;
	public GUIStyle Sleep_Icon;
	public GUIStyle test6;
	public GUIStyle test7;
	 bool isPressed;
	bool IsSlider;
	// Use this for initialization
	void Start () {
		isPressed = false;
		IsSlider = false;
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
							if(GUI.Button(new Rect(170,5,50,50),"",Inventory_Icon))
							{
								
								isPressed = false;
								IsSlider = true;
								
							}
							if(GUI.Button(new Rect(340,5,50,50),"",Digimon_Icon))
							{
								
								
								
							}
							if(GUI.Button(new Rect(500,5,50,50),"",Player_Icon))
							{
								
								
								
							}
						GUI.EndGroup();
						GUI.BeginGroup(new Rect(30,210,Screen.width/2-60,100),"Praise            SCOLD              SLEEP",test4);
							if(GUI.Button(new Rect(170,5,50,50),"",Praise_Icon))
							{
								
							}
							if(GUI.Button(new Rect(340,5,50,50),"",Scold_Icon))
							{

							}
							if(GUI.Button(new Rect(500,5,50,50),"",Sleep_Icon))
							{

							}
						GUI.EndGroup();
					GUI.EndGroup();
				}

		if (IsSlider) 
		{
			GUI.BeginScrollView(new Rect(new Rect(0,Screen.height/3,Screen.width/2,Screen.height/2)),new Vector2(50,0),new Rect(0,0,0,400),false,true,test6,test7);
			GUI.EndScrollView();
		}
	}
}
