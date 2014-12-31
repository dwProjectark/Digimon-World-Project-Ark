#pragma strict

var LevelName = "Level02";
var PlayerName = "Player";

@script AddComponentMenu ("Inventory/Other/ChangeScene")

function Awake () 
{
	DontDestroyOnLoad (GameObject.Find(PlayerName));
}

function Update ()
{
	if (Input.GetKeyDown(KeyCode.T))
	{
		Application.LoadLevel("Level02");
	}
}