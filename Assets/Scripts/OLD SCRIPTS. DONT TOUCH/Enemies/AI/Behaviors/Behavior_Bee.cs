using UnityEngine;
using System.Collections;

public class Behavior_Bee : SM_Behavior {

	public override string calculateNextEvent (string currentEventName)
	{
		string nextEventName = "Hover";
		
		return nextEventName;
	}
}
