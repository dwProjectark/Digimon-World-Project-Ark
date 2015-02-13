using UnityEngine;
using System.Collections;

public class DigimonBase : MonoBehaviour
{
    //Digimon numnber is used to identify what digimon it is
    public int digimonNumber;
    public string digimonName;

    public enum DigimonSize
    {
        small,
        Medium,
        Large,
        XtraLarge

    }

    DigimonSize digimonSize;
    public enum ActiveTimes
    {
        Morning,
        Afternoon,
        Fresh
    }
   public ActiveTimes activeTime;

	[HideInInspector]  public int hungerTime1;
	[HideInInspector]	public int hungerTime2;
	[HideInInspector]	public int hungerTime3;
	[HideInInspector]  public	int timeToFeed;
	[HideInInspector]  public	bool isHungry;
	[HideInInspector]   public int sleepTime;
	[HideInInspector] public	bool isSleepy;
	[HideInInspector]	public int wakeTime;
	[HideInInspector] public int poopTime1;
	[HideInInspector] public int poopTime2;
	[HideInInspector] public int poopTime3;

	[HideInInspector] public bool willPoop;
	

    //Variables For Digmon Leve go Here
    private string digimonlevel;

    //Variables for Digimon Type
    private string digimonType;

    //Variables for Digimon Element go here
    private string digimonElement;

    // Declaring list for Digivolution Level
    public enum Level
    {
        Fresh, Intraining, Rookie, Champion, Ultimate, Mega, Armor, SuperMega
    }
    public Level level;

    // Declaring list for Elements
    public enum Element
    {
        Air, Battle, Darkness, Earth, Filth, Fire, Holy, Ice, Mech
    }
    public Element element;

    //Declaring List for Type
    public enum Type
    {
        Virus, Data, Vaccine
    }
    public Type type;





    //Digivolve ActiveTime
   


    [Header("Digivolution/DigivolveTo")]
    public bool canDtTier1;
    public GameObject tier1;
    int tier1Points;
    public bool canDtTier2;
    public GameObject tier2;
    int tier2Points;
    public bool canDtTier3;
    public GameObject tier3;
    int tier3Points;
    public bool canDtTier4;
    public GameObject tier4;
    int tier4Points;
    public bool canDtTier5;
    public GameObject tier5;
    int tier5Points;

    DigimonBase digimonBaseTier1;
    DigimonBase digimonBaseTier2;
    DigimonBase digimonBaseTier3;
    DigimonBase digimonBaseTier4;
    DigimonBase digimonBaseTier5;

    [Header("Digivolution/EvolutionRequirements")]
    //DIGIVOLUTION STATS

    public int dtAge;
    public int dtAgeFromdigvolution;
    public int tamerExperienceGiven;
    public int pointsNeeded;

    public bool useDtBrain;
    public int dtBrain;


    public bool useDtSpeed;
    public int dtSpeed;
 


    public bool usedtDefense;
    public int dtDefense;


    public bool useDtOffence;
    public int dtOffence;


    public bool usedtHpMax;
    public int dtHpMax;


    public bool useDtMpMax;
    public int dtMpMax;


    public bool useDtHappiness;
    public int dtHappinessMin;
    public int dtHappinessMax;
    bool happinessOccuredtier1;
    bool happinessOccuredtier2;
    bool happinessOccuredtier3;
    bool happinessOccuredtier4;
    bool happinessOccuredtier5;

    public bool useDtDiscipline;
    public int dtDisciplineMin;
    public int dtDisciplineMax;


    public bool useDtBattlesWon;
    public int dtBattlesWon;
   

    public bool useDtSleepLocation;
    public int dtSleepLocation;
    bool sleepLocationOccuredtier1;
    bool sleepLocationOccuredtier2;
    bool sleepLocationOccuredtier3;
    bool sleepLocationOccuredtier4;
    bool sleepLocationOccuredtier5;

    public bool useDtCareMistakes;
    public int dtCareMistakesMin;
    public int dtCareMistakesMax;

    public bool useDtLives;
    public int dtLives;
    bool livesOccuredtier1;
    bool livesOccuredtier2;
    bool livesOccuredtier3;
    bool livesOccuredtier4;
    bool livesOccuredtier5;

    public bool useDtBattlesLoss;
    public int dtBattlesLoss;
    bool battlesLostOccuredtier1;
    bool battlesLostOccuredtier2;
    bool battlesLostOccuredtier3;
    bool battlesLostOccuredtier4;
    bool battlesLostOccuredtier5;

    public bool usedtWeight;
    public int dtWeightMin;
	public int dtWeightMax;

	public int stomachSize;




    public int hungerLevel;

	[Header("Stat Increase")]
	public int statIncreasePercentage;
	public int weightChange;





    // Use this for initialization
    void Start()
    {

		if (activeTime == ActiveTimes.Morning) 
		{
			hungerTime1=4;
			hungerTime2=8;
			hungerTime3=13;
			poopTime1=3;
			poopTime2=9;
			poopTime3= 14;
			sleepTime=16;
			wakeTime=1;
			
		}




       
	}
    // Update is called once per frame
    void Update()
    {


       

	}
}

       
