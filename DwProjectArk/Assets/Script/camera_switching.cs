using UnityEngine;
using System.Collections;

public class camera_switching : MonoBehaviour {
	public Camera camera_enabled;
	public Camera camera_disabled;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider player)
	{
		if (player.name == "player") 
		{
			camera_enabled.enabled = true;
			camera_disabled.enabled = false;

		}
	}
}
