using UnityEngine;
using System.Collections;

public class TalkingSphere : MonoBehaviour 
{
	public enum ActionType
	{
		Conversation,Cutscene,Training
	}


	public GameObject player;
	public GameObject partner;

	public ActionType actionType;


}
