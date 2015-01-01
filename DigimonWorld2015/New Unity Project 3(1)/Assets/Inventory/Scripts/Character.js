//The Character window (CSheet).

var WeaponSlot : Transform; //This is where the Weapons are going to go (be parented too). In my case it's the "Melee" gameobject.

private var ArmorSlot : Item[]; //This is the built in Array that stores the Items equipped. You can change this to static if you want to access it from another script.
var ArmorSlotName : String[]; //This determines how many slots the character has (Head, Legs, Weapon and so on) and the text on each slot.
var buttonPositions : Rect[]; //This list will contain where all buttons, equipped or not will be and SHOULD HAVE THE SAME NUMBER OF cells as the ArmorSlot array.

var windowSize : Vector2 = Vector2(375,300); //The size of the character window.
var useCustomPosition = false; //Do we want to use the customPosition variable to define where on the screen the Character window will appear.
var customPosition : Vector2 = Vector2 (70, 70); //The custom position of the Character window.
var cSheetSkin : GUISkin; //This is where you can add a custom GUI skin or use the one included (CSheetSkin) under the Resources folder.
var canBeDragged = true; //Can the Character window be dragged?

var onOffButton : KeyCode = KeyCode.I; //The key to toggle the Character window on and of.

var DebugMode = false; //If this is enabled, debug.logs will print out information when something happens (equipping items etc.).

static var csheet = false; //Helps with turning the CharacterSheet on and off.

private var windowRect = Rect(100,100,200,300); //Keeping track of our character window.

//These are keeping track of components such as equipmentEffects and Audio.
private var playersinv; //Refers to the Inventory script.
private var equipmentEffectIs = false;
private var invAudio : InvAudio;
private var invDispKeyIsSame = false;

@script AddComponentMenu ("Inventory/Character Sheet")
@script RequireComponent(Inventory)

//Assign the differnet components to variables and other "behind the scenes" stuff.
function Awake ()
{
	playersinv = GetComponent(Inventory);

	if (useCustomPosition == false)
	{
		windowRect = Rect(Screen.width-windowSize.x-70,Screen.height-windowSize.y-(162.5+70*2),windowSize.x,windowSize.y);
	}
	else
	{
		windowRect = Rect(customPosition.x,customPosition.y,windowSize.x,windowSize.y);
	}
	invAudio = GetComponent(InvAudio);
	if (GetComponent(InventoryDisplay).onOffButton == onOffButton)
	{
		invDispKeyIsSame = true;
	}
}

//Take care of the array lengths.
function Start ()
{
	ArmorSlot = new Item [ArmorSlotName.length];
	if (buttonPositions.Length != ArmorSlotName.Length)
	{
		Debug.LogError("The variables on the Character script attached to " + transform.name + " are not set up correctly. There needs to be an equal amount of slots on 'ArmorSlotName' and 'buttonPositions'.");
	}
}

//Checking if we already have somthing equipped
function CheckSlot(tocheck:int)
{
	var toreturn=false;
	if(ArmorSlot[tocheck]!=null){
		toreturn=true;
	}
	return toreturn;
}

//Using the item. If we assign a slot, we already know where to equip it.
function UseItem(i:Item,slot:int,autoequip:boolean)
{
	if(i.isEquipment){
		//This is in case we dbl click the item, it will auto equip it. REMEMBER TO MAKE THE ITEM TYPE AND THE SLOT YOU WANT IT TO BE EQUIPPED TO HAVE THE SAME NAME.
		if(autoequip)
		{
			var index=0; //Keeping track of where we are in the list.
			var equipto=0; //Keeping track of where we want to be.
			for(var a in ArmorSlotName) //Loop through all the named slots on the armorslots list
			{
				if(a==i.itemType) //if the name is the same as the armor type.
				{
					equipto=index; //We aim for that slot.
				}
				index++; //We move on to the next slot.
			}
			EquipItem(i,equipto);
		}
		else //If we dont auto equip it then it means we must of tried to equip it to a slot so we make sure the item can be equipped to that slot.
		{
			if(i.itemType==ArmorSlotName[slot]) //If types match.
			{
				EquipItem(i,slot); //Equip the item to the slot.
			}
		}
	}
	if (DebugMode)
	{
		Debug.Log(i.name + " has been used");
	}
}

//Equip an item to a slot.
function EquipItem(i:Item,slot:int)
{
	if(i.itemType == ArmorSlotName[slot]) //If the item can be equipped there:
	{
		if(CheckSlot(slot)) //If theres an item equipped to that slot we unequip it first:
		{
			UnequipItem(ArmorSlot[slot]);
			ArmorSlot[slot]=null;
		}
		ArmorSlot[slot]=i; //When we find the slot we set it to the item.
		
		gameObject.SendMessage ("PlayEquipSound", SendMessageOptions.DontRequireReceiver); //Play sound
		
		//We tell the Item to handle EquipmentEffects (if any).
		if (i.GetComponent(EquipmentEffect) != null)
		{
			equipmentEffectIs = true;
			i.GetComponent(EquipmentEffect).EquipmentEffectToggle(equipmentEffectIs);
		}
		
		//If the item is also a weapon we call the PlaceWeapon function.
		if (i.isAlsoWeapon == true)
		{
			if (i.equippedWeaponVersion != null)
			{
				PlaceWeapon(i);
			}
			
			else 
			{
				Debug.LogError("Remember to assign the equip weapon variable!");
			}
		}
		if (DebugMode)
		{
			Debug.Log(i.name + " has been equipped");
		}
		
		playersinv.RemoveItem(i.transform); //We remove the item from the inventory
	}
}

//Unequip an item.
function UnequipItem(i:Item)
{
	gameObject.SendMessage ("PlayPickUpSound", SendMessageOptions.DontRequireReceiver); //Play sound
	
	//We tell the Item to disable EquipmentEffects (if any).
	if (i.equipmentEffect != null)
	{
		equipmentEffectIs = false;
		i.GetComponent(EquipmentEffect).EquipmentEffectToggle(equipmentEffectIs);
	}
	
	//If it's a weapon we call the RemoveWeapon function.
	if (i.itemType == "Weapon")
	{
		RemoveWeapon(i);
	}
	if (DebugMode)
	{
		Debug.Log(i.name + " has been unequipped");
	}
	playersinv.AddItem(i.transform);
}

//Places the weapon in the hand of the Player.
function PlaceWeapon (Item)
{
		var Clone = Instantiate (Item.equippedWeaponVersion, WeaponSlot.position, WeaponSlot.rotation);
		Clone.name = Item.equippedWeaponVersion.name;
		Clone.transform.parent = WeaponSlot;
		if (DebugMode)
		{
			Debug.Log(Item.name + " has been placed as weapon");
		}
}

//Removes the weapon from the hand of the Player.
function RemoveWeapon (Item)
{	if (Item.equippedWeaponVersion != null)
	{
		Destroy(WeaponSlot.FindChild(""+Item.equippedWeaponVersion.name).gameObject);
		if (DebugMode)
		{
			Debug.Log(Item.name + " has been removed as weapon");
		}
	}
}

function Update ()
{
	//This will turn the character sheet on and off.
	if (Input.GetKeyDown(onOffButton))
	{
		if (csheet)
		{
			csheet = false;
			if (invDispKeyIsSame != true)
			{
				gameObject.SendMessage ("ChangedState", false, SendMessageOptions.DontRequireReceiver); //Play sound
				gameObject.SendMessage("PauseGame", false, SendMessageOptions.DontRequireReceiver); //StopPauseGame/EnableMouse/ShowMouse
			}
		}
		else
		{
			csheet = true;
			if (invDispKeyIsSame != true)
			{
				gameObject.SendMessage ("ChangedState", true, SendMessageOptions.DontRequireReceiver); //Play sound
				gameObject.SendMessage("PauseGame", true, SendMessageOptions.DontRequireReceiver); //PauseGame/DisableMouse/HideMouse
			}
		}
	}
}

//Draw the Character Window
function OnGUI()
{
	GUI.skin = cSheetSkin; //Use the cSheetSkin variable.
	
	if(csheet) //If the csheet is opened up.
	{
		//Make a window that shows what's in the csheet called "Character" and update the position and size variables from the window variables.
		windowRect=GUI.Window (1, windowRect, DisplayCSheetWindow, "Character");
	}
}

//This will display the character sheet and handle the buttons.
function DisplayCSheetWindow(windowID:int)
{
	if (canBeDragged == true)
	{
		GUI.DragWindow (Rect (0,0, 10000, 30));  //The window is dragable.
	}
	
	var index=0;
	for(var a in ArmorSlot) //Loop through the ArmorSlot array.
	{
		if(a==null)
		{
			if(GUI.Button(buttonPositions[index], ArmorSlotName[index])) //If we click this button (that has no item equipped):
			{
				var id=GetComponent(InventoryDisplay);
				if(id.itemBeingDragged != null) //If we are dragging an item:
				{
					EquipItem(id.itemBeingDragged,index); //Equip the Item.
					id.ClearDraggedItem();//Stop dragging the item.
				}
			}
		}
		else
		{
			if(GUI.Button(buttonPositions[index],ArmorSlot[index].itemIcon)) //If we click this button (that has an item equipped):
			{
				var id2=GetComponent(InventoryDisplay);
				if(id2.itemBeingDragged != null) //If we are dragging an item:
				{
					EquipItem(id2.itemBeingDragged,index); //Equip the Item.
					id2.ClearDraggedItem(); //Stop dragging the item.
				}
				else if (playersinv.Contents.length < playersinv.MaxContent) //If there is room in the inventory:
				{
					UnequipItem(ArmorSlot[index]); //Unequip the Item.
					ArmorSlot[index] = null; //Clear the slot.
					id2.ClearDraggedItem(); //Stop dragging the Item.
				}
				else if (DebugMode)
				{
					Debug.Log("Could not unequip " + ArmorSlot[index].name + " since the inventory is full");
				}
			}
		}
		index++;
	}
}
