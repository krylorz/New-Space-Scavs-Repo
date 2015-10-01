using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AIStateMachine))]
public class AIEvent : MonoBehaviour {
	
	public bool needsToExit = false; //Flag for if the script calls the Exit function if the AI event is switched from outside
	public string eventName; //Public name of the Event(Needs to be the same as the Script Name (for now))
	protected AIStateMachine currentStateMachine;
	
	
	void Awake(){
		currentStateMachine = GetComponent<AIStateMachine>();
		OnAwake();
	}
	
	protected virtual void OnAwake(){
		
	}
	
	public virtual string getEventName(){
		return eventName;
	}
	//Called to Initiate the Event
	public void StartAction(){
		OnStartAction();
	}
	//Called every frame for Ai behavior
	public void ActionEvent(){
		OnActionEvent();
	}
	//Called to exit the behavior
	protected void Exit(){
		//currentStateMachine.calculateNextEvent();
		OnExit();
	}
	//Used to exit the behavior from outside the script
	public void OverrideExit(){
		if(needsToExit){
			Exit();
		}
	}
	
	protected virtual void OnStartAction(){
		
	}
	
	protected virtual void OnActionEvent(){
		
	}
	
	protected virtual void OnExit(){
		
	}
	
	
	//Returns the attached 
	public GameObject getCurrentOwner(){
		return this.gameObject;
	}
}
