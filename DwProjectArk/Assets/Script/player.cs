using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public  float speed = 1;

	bool stat_digimon = false;
	Animator animator; 
	float moving = 4;
	public Transform body;
	//Vector3 dircetion = transform.localEulerAngles ;
	//direction.y = 180.0f;


	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {


		CharacterController Controller = GetComponent<CharacterController>();
		Vector3 vertical = transform.TransformDirection (Vector3.forward);
		Vector3 horizontal = transform.TransformDirection (Vector3.right);
		animator.SetFloat("Speed",speed);
		if (Input.GetAxis ("Vertical")>0||Input.GetAxis ("Vertical")<0 
		    || Input.GetAxis ("Horizontal")>0||Input.GetAxis ("Horizontal")<0) 
		{
			animator.SetFloat ("Speed", moving);
			Controller.Move ((vertical * (speed * Input.GetAxis ("Vertical")) * Time.deltaTime));
			Controller.Move ((horizontal * (speed * Input.GetAxis ("Horizontal")) * Time.deltaTime));
		} 
		else 
		{
			animator.SetFloat("Speed",speed);
		
		}

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
	void LateUpdate(){
		// Rotate the Character to match the direction he/she is going
		if(Input.GetAxis("Vertical") == 0){
			if(Input.GetAxis("Horizontal") > 0){
				transform.localEulerAngles = new Vector3(0f,90f,0f);
				//transform.localEulerAngles = dircetion;
			}else if(Input.GetAxis("Horizontal") < 0){
				transform.localEulerAngles = new Vector3(0f,-90f,0f);
			}
		}else if(Input.GetAxis("Vertical") > 0){
			if(Input.GetAxis("Horizontal") > 0){
				transform.localEulerAngles = new Vector3(0f,45f,0f);
			}else if(Input.GetAxis("Horizontal") < 0){
				transform.localEulerAngles = new Vector3(0f,-45f,0f);
			}
		}else if(Input.GetAxis("Vertical") < 0){
			if(Input.GetAxis("Horizontal") == 0){
				transform.localEulerAngles = new Vector3(0f,0f,0f);
			}else if(Input.GetAxis("Horizontal") > 0){
				transform.localEulerAngles = new Vector3(0f,135f,0f);
			}else if(Input.GetAxis("Horizontal") < 0){
				transform.localEulerAngles = new Vector3(0f,-135f,0f);
			}
		}
	}
}

