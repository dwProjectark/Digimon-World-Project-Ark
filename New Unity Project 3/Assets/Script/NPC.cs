using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {
	 bool check_gui = false;
	public string[] talking;
	public GUISkin Dialog;
	int count = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider NPC)
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
						if (NPC.gameObject.name == "player") {
								
								check_gui = true;
								count++;
								if(count == 3)
								{
									count = 0;
								}
						}
				}
	}
	void OnTriggerExit()
	{
		check_gui = false;
	}

	public void OnGUI()
	{	if (check_gui) 
		{
			GUI.skin = Dialog;
			GUI.Box(new Rect(25,Screen.height/1.5f,Screen.width-50,Screen.height/3),talking[count]);
			


		}
	}


}
