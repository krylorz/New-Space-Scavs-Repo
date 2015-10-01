using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AIStateMachine))]
public class Enemy : Combatant {

	protected StateMachine stateMachine;
	public GameObject currentTarget;
	public Projectile projectile1;
	
	protected override void OnAwake ()
	{
		stateMachine = GetComponent<StateMachine>();
		alignment = AlignmentType.ENEMY;
	}
	
	public void playerEnter(GameObject player){
		currentTarget = player;
		if(player.transform.position.x < transform.position.x){
			flip(MoveDirection.LEFT);
		}
		else if(player.transform.position.x > transform.position.x){
			flip(MoveDirection.RIGHT);
		}
		stateMachine.addEventOfName("ShootAtTarget");
	}
	
	public void playerLeave(GameObject player){
		currentTarget = null;
		stateMachine.removeCurrentEvent();
	}
	
	
	
	
	
}
