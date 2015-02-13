using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class evolutionTest : MonoBehaviour
{
	[Header("Hi there!")]
	public Text text;
	public int pointsNeeded;


	// Will decide who the digimon Will digivolveto
	public enum WillDigivolveto
		{
		 tier1,
		 tier2,
		 tier3,
		 tier4,
		 tier5,
		 none,
		 Numemon,
		 Sukamon,
		 Vademon
		 }
	
	 WillDigivolveto willDigivolveTo;

	//Points needed to get this digimon


	//Current Digimon stats

	bool tier1OccuredSpeed = false;
	public int speed;
	public int offence;
	public bool champion;

	//if true then digimon tier will be used if false it will not
	public bool useTier1;
	//Thepoints needed to get tier one grabed from the tier one game object
	public int tier1Points;

	//usedto signify that they are able to Dt 
	 bool canDtTier1;
	

		public bool useTier2;
		public int tier2Points;
	 bool canDtTier2;

	
	
	public GameObject[] digivolve;

	public int increaseSpeed;

	evolutionTest evolutions;
	evolutionTest teir2;
	// Use this for initialization
	void Start () 
	{
		evolutions = digivolve[0].GetComponent<evolutionTest> ();



		willDigivolveTo = WillDigivolveto.none;
		text.GetComponent<Text> ();




	if (digivolve [1] == null) 
		{
			useTier2=false;
		}
	else
		{
			teir2 = digivolve [1].GetComponent<evolutionTest> ();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (digivolve [0] == null) 
			{
				canDtTier1=false;
			}
		else
			{
				//Conditions to add points
				if(speed>=evolutions.speed&&tier1OccuredSpeed==false)
					{
						tier1Points++;
						tier1OccuredSpeed=true;
					}
				else if(tier1OccuredSpeed==true&&speed<evolutions.speed)
					{
						tier1OccuredSpeed=false;

						tier1Points--;
					}
				if(offence>=evolutions.offence)
					{
						tier1Points+=1;
					}

			}


		if (digivolve [1] == null) 
			{
			canDtTier2=false;
			}
		else
			{

			if(speed>=teir2.speed)
				{
				tier2Points+=1;
				}
			if(offence>=teir2.offence)
				{
			tier2Points+=1;
				}

			}

		

		//If you have the points needed 
		if (tier1Points >= evolutions.pointsNeeded && useTier1==true) 
			{
				canDtTier1 =true;
			}
		else if (useTier1==false ||tier1Points < evolutions.pointsNeeded)
		{
			canDtTier1=false;
		}

		if (digivolve [1] == null) 
		{
			canDtTier2 =false;
		}
		else
		{
			if (tier2Points >=teir2.pointsNeeded && useTier2==true)
				{
					canDtTier2 =true;
				}
			else if (tier2Points >=teir2.pointsNeeded && useTier2==false)
				{
					canDtTier2=false;
				}
		}
	
	// if they can digivolve to Tier one they will
		if(canDtTier1==true)
			{
			willDigivolveTo=WillDigivolveto.tier1;
			}

	//if they can digivolve to Tier 2 but cannot digivolve into tier 1 they will
		if(canDtTier2==true&&canDtTier1==false)
				{
			willDigivolveTo= WillDigivolveto.tier2;
				}
		if (canDtTier1 == false && canDtTier2 == false && champion == true) 
		{
			willDigivolveTo=WillDigivolveto.Numemon;
		}

		if (canDtTier1 == false && canDtTier2 == false && champion == false) 
		{
			willDigivolveTo=WillDigivolveto.none;
		}


		if (willDigivolveTo == WillDigivolveto.tier1) 
		{
			speed +=evolutions.increaseSpeed;

		}


		text.text = willDigivolveTo.ToString();
	}
}
