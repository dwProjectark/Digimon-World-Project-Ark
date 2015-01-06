using UnityEngine;
using System.Collections;
using UnityEditor;



[CustomEditor (typeof(TalkingSphere))]
public class TalkingShpereEditor : Editor
{
	//Create seralized instances of variables
	SerializedProperty playerProp;
	SerializedProperty partnerProp;
	SerializedProperty actionTypeProp;

	void OnEnable () 
	{
		playerProp = serializedObject.FindProperty ("player");
		partnerProp = serializedObject.FindProperty ("partner");
		playerProp = serializedObject.FindProperty ("actionType");
	}



	public override void OnInspectorGUI()
	{
		serializedObject.Update ();





	}
}
