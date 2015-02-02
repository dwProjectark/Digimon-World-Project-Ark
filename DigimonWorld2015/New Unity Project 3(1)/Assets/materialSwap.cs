using UnityEngine;
using System.Collections;

public class materialSwap : MonoBehaviour 

{
	public Texture blinking; 
	private int blinkTimer;
	public Texture eyesOpen;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		blinkTimer = Time.time;

		if (blinkTimer > 5) 
		{
			renderer.material.mainTexture = blinking;
		}

		if (blinkTimer > 6)
		{
			renderer.material.mainTexture = eyesOpen;

			blinkTimer =0;



		}
		Debug.Log(blinkTimer);


	
	}
}
