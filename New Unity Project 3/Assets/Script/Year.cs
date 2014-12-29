using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Year : MonoBehaviour {
	Text text1;
	public GameObject day;
	int _Day;
	 int year;
	int counter;
	bool increased;
	// Use this for initialization
	void Start () {
		increased = false;
		year = 0;
		counter = 1;
		text1 = GetComponent<Text>();
		text1.text = year.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		_Day = day.GetComponent<DAY> ().Day;
		text1.text = year.ToString ();
		if (_Day == 30*counter) 
		{
			if (increased == true)
			{
				year +=1;

				counter++;

			}
		}
		increased = true;

	
	}
}
