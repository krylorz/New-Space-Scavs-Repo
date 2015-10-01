using UnityEngine;
using System.Collections;

public class Jetpack : ArmorAbility {

	public float thrust;
	public float maxUseTimeSeconds;
	float currentUseTime = 0;
	public float cooldownTimer;
	float currentCooldown;
	bool cooldown = false;
	bool beingUsed = false;
	
	
	protected override void onAwake(){
		currentCooldown = cooldownTimer;
	}
	
	
	protected override void onUse(){
		if(canUse()){
			if(armor.CurrentCombatant.getRigidBody().velocity.sqrMagnitude < 60f){
				armor.CurrentCombatant.getRigidBody().AddForce(Vector3.forward * thrust, ForceMode.Acceleration);
				if(armor.CurrentCombatant.GetComponent<Jumper>() != null){
					armor.CurrentCombatant.GetComponent<Jumper>().overrideJump();
				}	
			}
			currentUseTime += Time.deltaTime;
			beingUsed = true;
		}
		else{
			beingUsed = false;
			cooldown = true;
		}
	}
	
	void LateUpdate(){
		
		
		if(beingUsed){
			
		}
		else{
			if(!canUse()){
				coolDown();
			}
			else{
				if(currentUseTime > 0)
					currentUseTime -= Time.deltaTime;
				else
					currentUseTime = 0;
			}
		}
		beingUsed = false;
	}
	
	bool canUse(){
		return currentUseTime < maxUseTimeSeconds && !cooldown;
	}
	
	void coolDown(){
		cooldown = true;
		
		if(currentCooldown > 0){
			currentCooldown -= Time.deltaTime;
			return;
		}
		
		if(currentUseTime > 0){
			currentUseTime -= Time.deltaTime;
			return;
		}
		
		cooldown = false;
		currentCooldown = cooldownTimer;
		currentUseTime = 0;
	}
	
	
}
