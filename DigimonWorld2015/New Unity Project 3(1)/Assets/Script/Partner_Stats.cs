using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Partner_Stats : MonoBehaviour {
	//Variables will be compared to DigimonBase
	public GameObject Clock;
	public Text agetext;
	DigiTime digiTime;

	
	//Actual brain stat
	public  int brain;
	    //FOR Digivolution
    	bool brainOccuredtier1;
    	bool brainOccuredtier2;
    	bool brainOccuredtier3;
    	bool brainOccuredtier4;
    	bool brainOccuredtier5;
    //Actual Care mistakes stat
	public  int careMistakes;
	    //fordigivolution
	    bool careMistakesOccuredtier1;
        bool careMistakesOccuredtier2;
        bool careMistakesOccuredtier3;
        bool careMistakesOccuredtier4;
        bool careMistakesOccuredtier5;
    //Actual defense stat
	public  int  defense;
	    //used for digivolution
	   	bool defenseOccuredtier1;
        bool defenseOccuredtier2;
    	bool defenseOccuredtier3;
        bool defenseOccuredtier4;
    	bool defenseOccuredtier5;
	//actual Discipline Stat
	public  int  discipline;
	    //used for digivolution
	   	bool disciplineOccuredtier1;
    	bool disciplineOccuredtier2;
    	bool disciplineOccuredtier3;
    	bool disciplineOccuredtier4;
    	bool disciplineOccuredtier5;
    //Actual Happiness stat
	public  int  happiness;
	    bool happinessOccuredtier1;
    	bool happinessOccuredtier2;
    	bool happinessOccuredtier3;
    	bool happinessOccuredtier4;
    	bool happinessOccuredtier5;
    //Actual Max HP stat
	public  int  hpMax;
	    //Hp for digivolution
	    	bool hpMaxOccuredtier1;
        	bool hpMaxOccuredtier2;
        	bool hpMaxOccuredtier3;
        	bool hpMaxOccuredtier4;
        	bool hpMaxOccuredtier5;
    //Actual Max mp stat
	public  int  mpMax;
	    //Actual max Mp stat
    	bool mpMaxOccuredtier1;
    	bool mpMaxOccuredtier2;
    	bool mpMaxOccuredtier3;
    	bool mpMaxOccuredtier4;
    	bool mpMaxOccuredtier5;
	//Actual Hp stat
	public  int  hp;
	//Actual mp stat
	public  int  mp;
	//Actual offense stat
	public  int  offence;
	    bool offenceOccuredtier1;
    	bool offenceOccuredtier2;
    	bool offenceOccuredtier3;
    	bool offenceOccuredtier4;
    	bool offenceOccuredtier5;
	//Actual speed stat
	public  int  speed;
        //Fordigivolution
       bool speedOccuredtier1;
       bool speedOccuredtier2;
       bool speedOccuredtier3;
       bool speedOccuredtier4;
       bool speedOccuredtier5;
	
	//Actual Weight stat
	public  int  weight;
	    //Fordigivolution
		bool weightOccuredtier1;
    	bool weightOccuredtier2;
    	bool weightOccuredtier3;
    	bool weightOccuredtier4;
    	bool weightOccuredtier5;

	
	//Whoever partner is they will be here
	public GameObject partnerDigimon;
	//Use this variables to get info from digimonBase
	DigimonBase digimonBase;

	
	//Digivolution Slots for Parter
	DigimonBase partnerTier1;
	DigimonBase partnerTier2;
	DigimonBase partnerTier3;
	DigimonBase partnerTier4;
	DigimonBase partnerTier5;
	
	bool canDtTier1;
	bool canDtTier2;
    bool canDtTier3;
    bool canDtTier4;
    bool canDtTier5;

	bool useDtTier1;
	bool useDtTier2;
	bool useDtTier3;
	bool useDtTier4;
	bool useDtTier5;
    public int tier1Points;
    public int tier2Points;
    public int tier3Points;
    public int tier4Points;
    public int tier5Points;

    enum WillDigivolveTo
    {
        Tier1,
        Tier2,
        Tier3,
        Tier4,
        Tier5,
        None,
        Numemon,
        Nanimon,
        Vademon,
		Sukamon
    }
	WillDigivolveTo willDigivolveTo;



	int hourbefore;
	//Actual Life variable
	int  lives;
	    //ForDigivolution
    	bool livesOccuredtier1;
    	bool livesOccuredtier2;
    	bool livesOccuredtier3;
    	bool livesOccuredtier4;
    	bool livesOccuredtier5;
    
    //Actual technices Variable
	public int techsLearned;
	    //ForDigivolution
		bool techsLearnedOccuredtier1;
    	bool techsLearnedOccuredtier2;
    	bool techsLearnedOccuredtier3;
    	bool techsLearnedOccuredtier4;
    	bool techsLearnedOccuredtier5;

    //Actual Sleep Variable
		int sleepLocation;
        bool sleepLocationOccuredtier1;
        bool sleepLocationOccuredtier2;
        bool sleepLocationOccuredtier3;
        bool sleepLocationOccuredtier4;
        bool sleepLocationOccuredtier5;
		

	// Is increased By the DigimonTime Script
	        public int  age;
			int  ageFromLastEvolution;
			int digivolutionAge;
            int maxlife;
		//Actual battles stat
			int  battlesWon;
                bool battlesWonOccuredtier1;
                bool battlesWonOccuredtier2;
                bool battlesWonOccuredtier3;
                bool battlesWonOccuredtier4;
                bool battlesWonOccuredtier5;

			int  battlesLost;
                bool battlesLostOccuredtier1;
                bool battlesLostOccuredtier2;
                bool battlesLostOccuredtier3;
                bool battlesLostOccuredtier4;
                bool battlesLostOccuredtier5;

	//Variables will be taken from DigimonBase
	        string digimonName;
			int  digimonNumber;
			int  hungerLevel;
		    int  hungerLevelMax;


		    
	public int virus;		
	    int virusMax =10;
	bool digivolution;

	// Use this for initialization
	void Start ()
	{
	    //Variables copied directly from digimon base
	        
	    
		digiTime = Clock.GetComponent<DigiTime> ();
		agetext.GetComponent<Text> ();
		hourbefore = 0;
		lives = 3;
		
		digimonBase= partnerDigimon.GetComponent<DigimonBase>();
		partnerTier1= digimonBase.tier1.GetComponent<DigimonBase> ();

		




//For car mistakes
    hungerLevel=0;
    hungerLevelMax=digimonBase.hungerLevel;

	}
	
	// Update is called once per frame
	void Update () 
	{

	    
	    //Variables copied directly from digimon base
	    digimonName=digimonBase.digimonName;
	   digimonNumber=digimonBase.digimonNumber;
	    
	    
		//Digivolution //Digivolution //Digivolution //Digivolution //Digivolution  //Digivolution //Digivolution //Digivolution //Digivolution

			//Tier1 Digivolution //Tier1 Digivolution//Tier1 Digivolution//Tier1 Digivolution//Tier1 Digivolution//Tier1 Digivolution//Tier1 Digivolution//Tier1 Digivolution
		if (partnerTier1 == null) 
		{
						canDtTier1 = false;
						useDtTier1 = false;

		} 
				
			else
			{
					//Conditions to add points

	            //Speed state Check
						if (speed >= partnerTier1.dtSpeed && speedOccuredtier1 == false &&partnerTier1.useDtSpeed==true)
						{
									tier1Points++;
									speedOccuredtier1 = true;

						} 
						else if (speedOccuredtier1 == true && speed < partnerTier1.dtSpeed)
						{
								speedOccuredtier1 = false;
								tier1Points--;
			        	}
	            //Defense stat Check
	                     if (defense >= partnerTier1.dtDefense && defenseOccuredtier1 == false && partnerTier1.usedtDefense==true)
						    {
									tier1Points++;
									defenseOccuredtier1 = true;
					    	} 
						else if (defenseOccuredtier1 == true && defense < partnerTier1.dtDefense)
					    	{
								defenseOccuredtier1 = false;
								tier1Points--;
			            	}

				//offence stat check
	               
	               if (offence >= partnerTier1.dtOffence && offenceOccuredtier1 == false && partnerTier1.useDtOffence==true)
						{
									tier1Points++;
									offenceOccuredtier1 = true;
						} 
						else if (offenceOccuredtier1 == true && offence < partnerTier1.dtOffence)
						{
								offenceOccuredtier1 = false;
								tier1Points--;
			        	}
	            //Brains stat check
				
				if (brain >= partnerTier1.dtBrain && brainOccuredtier1 == false && partnerTier1.useDtBrain==true)
						{
									tier1Points++;
									brainOccuredtier1 = true;
						} 
						else if (brainOccuredtier1 == true && brain < partnerTier1.dtBrain)
						{
								brainOccuredtier1 = false;
								tier1Points--;
			        	}
	            //Hp Stat Check
				
				if (hpMax >= partnerTier1.dtHpMax && hpMaxOccuredtier1 == false && partnerTier1.usedtHpMax==true)
						{
									tier1Points++;
									hpMaxOccuredtier1 = true;
						} 
						else if (hpMaxOccuredtier1 == true && hpMax < partnerTier1.dtHpMax)
						{
								hpMaxOccuredtier1 = false;
								tier1Points--;
			        	}
	            //Mp Stat Check

	            if (mpMax >= partnerTier1.dtMpMax && mpMaxOccuredtier1 == false && partnerTier1.useDtMpMax==true)
						{
									tier1Points++;
									mpMaxOccuredtier1 = true;
						} 
						else if (mpMaxOccuredtier1 == true && mpMax < partnerTier1.dtMpMax)
						{
								mpMaxOccuredtier1 = false;
								tier1Points--;
			        	}

	            //Happiness Check

				if (happiness >= partnerTier1.dtHappinessMin && happiness <=partnerTier1.dtHappinessMax && happinessOccuredtier1 == false &&partnerTier1.useDtHappiness ==true)
						{
									tier1Points++;
									happinessOccuredtier1 = true;
						} 
						else if (happinessOccuredtier1 == true && happiness < partnerTier1.dtHappinessMin|| happiness > partnerTier1.dtHappinessMax)
						{
								happinessOccuredtier1 = false;
								tier1Points--;
			        	}
	            //Discipline Check
				if (discipline >= partnerTier1.dtDisciplineMin && discipline <=partnerTier1.dtDisciplineMax && disciplineOccuredtier1 == false && partnerTier1.useDtDiscipline==true)
						{
									tier1Points++;
									disciplineOccuredtier1 = true;
						} 
						else if (disciplineOccuredtier1 == true && discipline < partnerTier1.dtDisciplineMin|| discipline > partnerTier1.dtDisciplineMax)
						{
								disciplineOccuredtier1 = false;
								tier1Points--;
			        	}
				// Battles Won Check
	            if (battlesWon >= partnerTier1.dtBattlesWon && battlesWonOccuredtier1 == false&& partnerTier1.useDtBattlesWon==true)
						{
									tier1Points++;
									battlesWonOccuredtier1 = true;
						} 
						else if (battlesWonOccuredtier1 == true && battlesWon < partnerTier1.dtBattlesWon)
						{
								battlesWonOccuredtier1 = false;
								tier1Points--;
			        	}
	            //Battles lost Check
	            if (battlesLost >= partnerTier1.dtBattlesLoss && battlesWonOccuredtier1 == false&& partnerTier1.useDtBattlesLoss==true)
						{
									tier1Points++;
									battlesWonOccuredtier1 = true;
						} 
						else if (battlesWonOccuredtier1 == true && battlesLost < partnerTier1.dtBattlesLoss)
						{
								battlesWonOccuredtier1 = false;
								tier1Points--;
			        	}
	            //Lives Check
	            if  (lives == partnerTier1.dtLives && livesOccuredtier1 == false&& partnerTier1.useDtLives==true)
						{
									tier1Points++;
									livesOccuredtier1 = true;
						} 
						else if (livesOccuredtier1 == true && lives < partnerTier1.dtLives|| lives > partnerTier1.dtLives)
						{
								livesOccuredtier1 = false;
								tier1Points--;
			        	}
	            //Weight Check
	            if(weight >= partnerTier1.dtWeightMin && weight <= partnerTier1.dtWeightMax && weightOccuredtier1 == false&&partnerTier1.usedtWeight==true)
						{
									tier1Points++;
									weightOccuredtier1 = true;
						} 
						else if (weightOccuredtier1 == true && weight < partnerTier1.dtWeightMin|| weight> partnerTier1.dtWeightMax)
						{
								weightOccuredtier1 = false;
								tier1Points--;
			        	}
	            //CareMistakes Check
	             if(careMistakes >= partnerTier1.dtCareMistakesMin && careMistakes <= partnerTier1.dtCareMistakesMax && careMistakesOccuredtier1 == false&&partnerTier1.useDtCareMistakes==true)
						{
									tier1Points++;
									careMistakesOccuredtier1 = true;
						} 
				else if (careMistakesOccuredtier1 == true && careMistakes < partnerTier1.dtCareMistakesMin|| careMistakes> partnerTier1.dtCareMistakesMax)
						{
								careMistakesOccuredtier1 = false;
								tier1Points--;
			        	}

	            //SleepLocation Check
				if (sleepLocation == partnerTier1.dtSleepLocation && sleepLocationOccuredtier1 == false&&partnerTier1.useDtSleepLocation==true)
						{
									tier1Points++;
									sleepLocationOccuredtier1 = true;
						} 
						else if (sleepLocationOccuredtier1 == true && sleepLocation != partnerTier1.dtSleepLocation)
						{
								sleepLocationOccuredtier1 = false;
								tier1Points--;
						}








			//If the points are greater then the digivolution
			if (tier1Points >= partnerTier1.pointsNeeded && useDtTier1==true&&digivolutionAge>=partnerTier1.dtAge)
				{
					canDtTier1 =true;
				}
				else if (tier1Points< partnerTier1.pointsNeeded||useDtTier1==false||digivolutionAge<partnerTier1.dtAge)
				{
					canDtTier1=false;
				}

			
			}


		if (virus == virusMax) 
		{
			virus=0;
			willDigivolveTo=WillDigivolveTo.Sukamon;
		}
			
		else if(canDtTier1==true)
		{
			willDigivolveTo=WillDigivolveTo.Tier1;
		}
		else if(canDtTier1==false&&canDtTier2==true)
		{
			willDigivolveTo=WillDigivolveTo.Tier2;
		}
		else if(canDtTier1==false&&canDtTier2==false&&canDtTier3==true)
		{
			willDigivolveTo=WillDigivolveTo.Tier3;
		}
		else if(canDtTier1==false&&canDtTier2==false&&canDtTier3==false&&canDtTier4==true)
		{
			willDigivolveTo=WillDigivolveTo.Tier4;
		}
		else if(canDtTier1==false&&canDtTier2==false&&canDtTier3==false&&canDtTier4==false&&canDtTier5==true)
		{
			willDigivolveTo=WillDigivolveTo.Tier5;
		}

		else if(canDtTier1==false&&canDtTier2==false&&canDtTier3==false&&canDtTier4==false&&canDtTier5==false&&digimonBase.level==DigimonBase.Level.Rookie)
		{
			willDigivolveTo=WillDigivolveTo.Numemon;
		}
		else
		{
			willDigivolveTo=WillDigivolveTo.None;
		}
			
		// Will grab and change variables from The digivolve script
		if (willDigivolveTo==WillDigivolveTo.Tier1)
		{
			speed+=(speed*(partnerTier1.statIncreasePercentage/100));
			defense+=(defense*(partnerTier1.statIncreasePercentage/100));
			offence+=(offence*(partnerTier1.statIncreasePercentage/100));
			brain+=(brain*(partnerTier1.statIncreasePercentage/100));
			hpMax+=(hpMax*(partnerTier1.statIncreasePercentage/100));
			mpMax+=(defense*(partnerTier1.statIncreasePercentage/100));

			weight+=partnerTier1.weightChange;
			partnerDigimon=digimonBase.tier1;
			digivolution=true;
		}




    //	Life Cycle
			
		if (digiTime.hour > hourbefore) 
		{
			age++;
			hourbefore=digiTime.hour;
			digivolutionAge++;
		}

		else if(lives==0)
		{
			age -=age;
			lives=3;
		}

		if(Input.GetKeyDown(KeyCode.A))
		{
			lives--;
		}


        agetext.text = age.ToString ();
        
    //Care Mistakes
		if (digimonBase.activeTime == DigimonBase.ActiveTimes.Fresh)
		{
			if(digiTime.clockHour==2||digiTime.clockHour==7||digiTime.clockHour==12||digiTime.clockHour==18||digiTime.clockHour==22)
			{
				digimonBase.isHungry=true;
				
			}
			if(digiTime.clockHour==3||digiTime.clockHour==8||digiTime.clockHour==13||digiTime.clockHour==17||digiTime.clockHour==23)
			{
				digimonBase.willPoop=true;
				
			}
			
			
			if(digiTime.clockHour==0)
			{
				digimonBase.isSleepy=true;
				digimonBase.wakeTime=1;
			}
			else if(digiTime.clockHour==4)
			{
				digimonBase.isSleepy=true;
				digimonBase.wakeTime=5;
			}
			else if(digiTime.clockHour==9)
			{
				digimonBase.isSleepy=true;
				digimonBase.wakeTime=10;
			}
			else if(digiTime.clockHour==14)
			{
				digimonBase.isSleepy=true;
				digimonBase.wakeTime=15;
			}
			else if(digiTime.clockHour==19)
			{
				digimonBase.isSleepy=true;
				digimonBase.wakeTime=20;
			}
		}
		else
		{
			if (digiTime.clockHour == digimonBase.hungerTime1 || digiTime.clockHour == digimonBase.hungerTime2 || digiTime.clockHour == digimonBase.hungerTime3) 
			{
				digimonBase.isHungry=true;
			}
			
			if (digiTime.clockHour == digimonBase.poopTime1 || digiTime.clockHour==digimonBase.poopTime2 || digiTime.clockHour== digimonBase.poopTime3)
			{
				digimonBase.willPoop=true;
			}
			if(digiTime.clockHour==digimonBase.sleepTime)
			{	
				digimonBase.isSleepy=true;
			}
			
		}

		if (digimonBase.activeTime ==DigimonBase.ActiveTimes.Morning) 
		{
			digimonBase.hungerTime1=4;
			digimonBase.hungerTime2=8;
			digimonBase.hungerTime3=13;
			digimonBase.poopTime1=3;
			digimonBase.poopTime2=9;
			digimonBase.poopTime3= 14;
			digimonBase.sleepTime=16;
			digimonBase.wakeTime=1;
			
		}
		
		if (digimonBase.isHungry == true) 
		{
			digimonBase.timeToFeed=0;
			hungerLevel=hungerLevelMax;
			digimonBase.isHungry=false;
		}
		if (digimonBase.timeToFeed == 2) 
		{
			
		}
		
		
	




   
}
}


	