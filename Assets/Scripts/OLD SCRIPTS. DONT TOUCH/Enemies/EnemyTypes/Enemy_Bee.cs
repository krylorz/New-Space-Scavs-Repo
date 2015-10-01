using UnityEngine;
using System.Collections;

public class Enemy_Bee : Enemy {
	
	
	new public void playerEnter(GameObject player){
		currentTarget = player;
		
		stateMachine.addEventOfName("MoveTowardsTarget");
	}
	
	new public void playerLeave(GameObject player){
		stateMachine.addEventOfName("Hover");
		currentTarget = null;
	
	}
	
}
