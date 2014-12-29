using UnityEngine;
using System.Collections;

public class Menu_Test : MonoBehaviour {


	 public CanvasGroup test2;
	// Use this for initialization
	void Start () {
		inventory ();
	}
	
	// Update is called once per frame
	void Update () {
		//inventory ();
	}

	public void inventory()
	{

		test2.alpha = 0;
		test2.interactable = false;


	}
}
