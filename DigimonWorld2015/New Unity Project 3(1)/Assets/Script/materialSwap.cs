using UnityEngine;
using System.Collections;

public class materialSwap : MonoBehaviour 
	
{

	public Texture blinking; 
	private float blinkTimer;
	public Texture eyesOpen;
	float start;



	// Use this for initialization
	void Start () 
	{
		start = 0f;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		float open = Random.Range(2.0f,5.0f);
		float close = open + 0.5f;
		blinkTimer = Time.time-start;
		
		if (blinkTimer > open) 
		{
			renderer.material.mainTexture = blinking;
		}
		
		if (blinkTimer > close)
		{
			renderer.material.mainTexture = eyesOpen;
			start = Time.time;
			blinkTimer = 0;
			Debug.Log(blinkTimer);
			
		}
		
		Debug.Log(blinkTimer);
		
		
	}
}