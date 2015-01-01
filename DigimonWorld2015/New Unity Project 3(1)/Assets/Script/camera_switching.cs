using UnityEngine;
using System.Collections;

public class camera_switching : MonoBehaviour {
	public Camera[] camera;

	// Use this for initialization
	void Start () {
		camera [0].enabled = true;
		for (int i = 1; i < camera.Length; i++) 
		{
			camera[i].enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) 
		{
			for (int i =0; i < camera.Length;i++)
			{
				if (camera[i].enabled == true)
				{
					camera[i].enabled = false;
					if (i+1 == camera.Length)
					{
						i = 0;
						camera[i].enabled = true;
						break;
					}
					else
					{
						camera[i+1].enabled = true;
						break;
					}
				}

			}
		}

	}
	/*void OnTriggerStay(Collider player)
	{
		if (player.name == "player") 
		{
			camera_enabled.enabled = true;
			camera_disabled.enabled = false;

		}
	}*/
}
