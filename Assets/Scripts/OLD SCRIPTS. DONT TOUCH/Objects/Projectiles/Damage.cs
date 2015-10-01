using UnityEngine;
using System.Collections;

public enum DamageType{Default, Explosive};

public class Damage : MonoBehaviour {

	public DamageType damageType;
	public int damage;
	int totaldamage;
	
	void Awake(){
		totaldamage = damage;
	}
	
	public void setDamage(float damageMultiplier){
		totaldamage = (int)(totaldamage * damageMultiplier);
	}
	
	
	public void inflictDamage(Health objectHealth){
		
		objectHealth.takeDamage(damage);
		inflictAdditionalEffect(objectHealth);
	}
	
	protected virtual void inflictAdditionalEffect(Health objectHealth){
		
	}
	
	public int getTotalDamage(){
		return totaldamage;
	}
}
