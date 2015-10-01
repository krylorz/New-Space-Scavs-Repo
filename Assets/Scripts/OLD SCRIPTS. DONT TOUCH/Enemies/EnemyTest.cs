using UnityEngine;
using System.Collections;


public class EnemyTest : Combatant {

	bool playerInRange;
	GameObject currentTarget;
	public Projectile projectile1;
	
	
	public void playerEnter(GameObject player){
		playerInRange = true;
		currentTarget = player;
		if(player.transform.position.x < transform.position.x){
			flip(MoveDirection.LEFT);
		}
		else if(player.transform.position.x > transform.position.x){
			flip(MoveDirection.RIGHT);
		}
	}
	
	public void playerLeave(GameObject player){
		playerInRange = false;
		currentTarget = null;
	}
	
	void Update(){
		if(playerInRange){
			GetComponent<ShootAtTarget>().shootTarget(projectile1, currentTarget.transform.position);
		}
	}
	
	
	
	
}
