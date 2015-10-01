using UnityEngine;
using System.Collections;

public class Behavior_ArmorGrub : SM_Behavior {

	public override string calculateNextEvent (string currentEventName)
	{
		string nextEventName = "";
		switch(currentEventName){
			case "ShootAtTarget":
				
			nextEventName = "ShootAtTarget";
			break;
		}
		return nextEventName;
	}
	
	
}
