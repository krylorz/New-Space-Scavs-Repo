using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class Door : PhysicsEnvironmentObject {
	
	
	int playersInTrigger = 0;
	bool isDoorOpen = false;
	Animator animator;
	
	protected override void OnAwake(){
		
		rb.isKinematic = true;
		rb.useGravity = false;
		gameObject.tag = "floor";
		animator = GetComponent<Animator>();
	}
	
	void openDoorRequest(){
		playersInTrigger ++;
		if(!isDoorOpen)
			openDoor();
		
	}
	
	void closeDoorRequest(){
		if(playersInTrigger > 0)
			playersInTrigger --;
		if(playersInTrigger <= 0 && isDoorOpen) //If the door has no players in the vicinity
		{
			closeDoor();	//Try and close door
		}
	}
	
	public void combatantEnter(){
		openDoorRequest();
	}
	
	public void combatantLeave(){
		closeDoorRequest();
	}
	
	public void openDoor(){
		isDoorOpen = true;
		getCollider().enabled = false;
		if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Open")){animator.Play("Open");}
	}
	
	public void closeDoor(){
		isDoorOpen = false;
		getCollider().enabled = true;
		if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Close")){animator.Play("Close");}
	}
	
	
	/*
	void OnTriggerEnter(Collider collider){
		
		if(collider.GetComponent<Combatant>() != null){
			openDoorRequest();
		}
		
	}
	
	void OnTriggerExit(Collider collider){
		
		if(collider.GetComponent<Combatant>() != null){
			closeDoorRequest();
		}
		
	}
	*/
}
