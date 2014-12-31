using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Closing : MonoBehaviour,IPointerDownHandler {
	public CanvasGroup option;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnPointerDown(PointerEventData data)
	{
		option.alpha = 0;
		option.interactable = false;
	}
}
