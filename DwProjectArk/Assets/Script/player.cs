using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public  float speed = 3;
	bool stat_digimon = false;
	public Animator anim;




	// Use this for initialization
	void Start () {
		anim.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		float move_y = Input.GetAxis("Vertical")*Time.deltaTime* speed;
		float move_x = Input.GetAxis ("Horizontal")*Time.deltaTime*speed;
		transform.Translate (0, 0, move_y);
		transform.Translate (move_x, 0, 0);
		transform.Rotate (0, move_y, 0);


			anim.SetFloat("Move",move_y);
		

		if (Input.GetKeyDown (KeyCode.Escape)) {

			stat_digimon = !stat_digimon; 
		}

	}


	void OnGUI()
	{

		if (stat_digimon == true) {
					GUI.Box (new Rect (200, 250, 300, 300),"Test");
					GUI.Button(new Rect(150,200,100,100),"Test");		
				}

			

	}
}
