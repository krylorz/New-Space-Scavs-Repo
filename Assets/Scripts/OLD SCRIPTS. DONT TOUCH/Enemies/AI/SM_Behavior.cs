using UnityEngine;
using System.Collections;

public abstract class SM_Behavior : MonoBehaviour {
	
	public abstract string calculateNextEvent(string currentEventName);
}
