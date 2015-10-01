using UnityEngine;
using System.Collections;


public class StateMachine : MonoBehaviour {
	
	protected AIEvent currentEvent; 
	public string startingAction;	//Name of the Event to start off with
	public string debugCurrentActionName; //Shows the current AI Event (Read Only)
	SM_Behavior behavior_impl;
	
	void Awake(){
		if(startingAction != null)
		{
			if(addEventOfName(startingAction)){}//Success!
			else
			{
				Debug.LogError("No Starting Event Found with name: " + startingAction);
			}
		}
		
		behavior_impl = GetComponent<SM_Behavior>();
		if(behavior_impl == null){
			Debug.LogError("No behavior impl attached");
		}
	}
	
	//Tries to find Event of eventName and set it as the current event
	//Returns true/false if event was found
	public bool addEventOfName(string eventName){
		if(currentEvent != null){
			exitCurrentEvent();
		}
		
		AIEvent tempEvent = GetComponent(eventName) as AIEvent;
		if(tempEvent == null){
			Debug.LogError("No Event Found with name: " + eventName);
			return false;
		}
		else{
			setCurrentEvent(tempEvent);
			Debug.Log("Event Attached: " + eventName);
			return true;
		}
	}
	
	//Internally sets the current event and initializes it
	void setCurrentEvent(AIEvent newEvent){
		//If there is a currentEvent, we try and OverrideExit to detach it safely
		
		currentEvent = newEvent;
		currentEvent.StartAction();
	}
	
	public void exitCurrentEvent()
	{
		if(currentEvent != null){
			currentEvent.OverrideExit();
		}
		Debug.Log("Event Removed: " + currentEvent.getEventName());
		currentEvent = null; //TODO add a nullObject Event script
	}
	
	public void removeCurrentEvent()
	{
		Debug.Log("Event Removed: " + currentEvent.getEventName());
		currentEvent = null; //TODO add a nullObject Event script
	}
	
	public string getCurrentEventName(){
		if(currentEvent == null){return "None";}
		return currentEvent.getEventName();
	}
	
	
	
	public void calculateNextEvent()
	{
		Debug.Log (gameObject.name + " " + currentEvent);
		string nextEventName = behavior_impl.calculateNextEvent(currentEvent.getEventName());
		removeCurrentEvent();
		Debug.Log ("behavior Impl has chosen " + nextEventName + " as the next event");
		if(addEventOfName(nextEventName)){
			Debug.Log("Event " + nextEventName + " attached");
		}
		else{
			Debug.LogError("Event " + nextEventName + " is not attached to this object");
		}
	}
	
	
	
	void Update(){
		debugCurrentActionName = "";
		if(currentEvent != null){
			debugCurrentActionName = currentEvent.getEventName();
			currentEvent.ActionEvent();
		}
	}
	
	
	
}
