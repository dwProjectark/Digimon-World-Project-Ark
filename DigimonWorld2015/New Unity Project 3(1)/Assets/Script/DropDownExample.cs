using UnityEngine;
using System.Collections;

public class DropDownExample : MonoBehaviour 
{	
	//Variables for Animations to load on Digimon\






	//Declaring Variables to be replaced

	//Variables For Digmon Leve go Here
	private string digimonlevel;

	//Variables for Digimon Element go here
	private string digimonElement;

	//Variables for Digimon ActiveTime Go here
	private string digimonActivetime;
	private int digimonTimeEatOne;
	private int digimonTimeEatTwo;
	private int digimonTimeEatThree;
	private int digimonTimePoopOne;
	private int digimonTimePoopTwo;
	private int digimonTimePoopThree;
	private int digimonTimeSleepOne;
	private int digimonTimeSleepTwo;
	private int digimonTimeSleepThree;
	private int digimonTimeWakeOne;
	private int digimonTimeWakeTwo;
	private int digimonTimeWakeThree;

		//Variables for Digimon Type
		private string digimonType;

		//====================================================================

		// Declaring list for Digivolution Level
		public enum Level
		{
			Fresh,Intraining,Rookie,Champion,Ultimate,Mega,Armor,SuperMega
		}
		public Level level;

		// Declaring list for Elements
		public enum Element
		{
			Air,Battle,Darkness,Earth,Filth,Fire,Holy,Ice,Mech
		}
		public Element element;

		//Declaring list for ActiveTimes
		public enum ActiveTime
		{
			Morning,DayEarly,DayLate,Evening,NightEarly,NightLate,
		}
		public ActiveTime activeTime;

		//Declaring List for Type
		public enum Type
		{
			Virus,Data,Vaccine
		}
		public Type type;

		//====================================================================

		void start ()
		{
			//Switch for Level
			switch(level)
			{
				// Variables for fresh
			case Level.Fresh:
				digimonlevel ="Fresh";
				break;

				// Variables for Intraining
			case Level.Intraining:
				digimonlevel ="Intraining";
				break;
		
				// Variables for Rookies
			case Level.Rookie:
				digimonlevel ="Rookie";
				break;

				// Variables for Champion
			case Level.Champion:
				digimonlevel ="Champion";
				break;

				// Variables for Ultimates
			case Level.Ultimate:
				digimonlevel ="Ultimate";
				break;

				// Variables for Megas

			case Level.Mega:
				digimonlevel ="Mega";
				break;

				// Variables for SuperMega
			case Level.SuperMega:
				digimonlevel ="Mega";
				break;

				// Variables for Armor
			case Level.Armor:
				digimonlevel ="Armor";
				break;
			}
			//====================================================================

			//Switch for Element
			switch(element)
			{
				//Variables for air Element
			case Element.Air:
				digimonElement="Air";
				break;

				//Variables for Battle Element
			case Element.Battle:
				digimonElement="Battle";
				break;

				//Variables for Darkness Element
			case Element.Darkness:
				digimonElement="Darkness";
				break;

				//Variables for Earth Element
			case Element.Earth:
				digimonElement="Earth";
				break;

				//Variables for Filth Element
			case Element.Filth:
				digimonElement="Filth";
				break;
				// Variables for Fire Element
			case Element.Fire:
				digimonElement="Fire";
				break;

				//Variables for holy Element
			case Element.Holy:
				digimonElement="Holy";
				break;

				//Variables for holy Element
			case Element.Ice:
				digimonElement="Ice";
				break;

				//Variables for Mech Element
			case Element.Mech:
				digimonElement="Mech";
				break;
			}
			//====================================================================

			//Switch for Active Times
			switch (activeTime) 
			{
				//Variables for Early Day
				case ActiveTime.DayEarly:
					digimonActivetime ="EarlyBird";
					digimonTimeEatOne = 1;
					digimonTimeEatTwo = 2;
					digimonTimeEatThree = 3;
					digimonTimePoopOne = 4;
					digimonTimePoopTwo = 5;
					digimonTimePoopThree =6;
					
					break;
			}

		//====================================================================
			
			//switch for digimonType
			switch (type)
			{
				//Variables for Data digimon
				case Type.Data:
					digimonType="data";
					break;

				//Variables for Vaccine
				case Type.Vaccine:
					digimonType="Vaccine";
					break;
				//Variables for Virus
				case Type.Virus:
					digimonType="Virus";
					break;

			}
		     

		}
	
}
