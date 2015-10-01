using UnityEngine;
using System.Collections;

public class CarrySlot : MonoBehaviour {

	Carryable carryable;
	WeaponSlots weaponSlots;
	public Combatant owner;
	public float throwForceModifier = 1;
	
	void Awake(){
		weaponSlots = GetComponent<WeaponSlots>();
		if(weaponSlots == null){Debug.Log ("No weapon slots found, object can only carry");}
	}
	
	public void useObj(){
		if(isCarrying()){
			carryable.use();
		}
	}
	
	public void throwObj(){
		if(isCarrying()){
			carryable.throwme(owner.getCollider(), throwForceModifier);
		}
		if(isUsingWeapons()){
			weaponSlots.enableWeapons();
		}
		carryable = null;
	}
	
	public void pickUpObj(Carryable carryable){
		if(isCarrying()){
			dropObj();
		}
		carryable.pickUp(owner);
		carryable.transform.SetParent(transform);
		carryable.transform.position = this.transform.position;
		carryable.transform.localScale = Vector3.one;
		this.carryable = carryable;
		if(isUsingWeapons()){
			weaponSlots.disableWeapons();
		}
	}
	
	public void dropObj(){
		if(isCarrying()){
			carryable.drop(owner.getCollider());
		}
		if(isUsingWeapons()){
			weaponSlots.enableWeapons();
		}
		carryable = null;
	}
	
	public bool isCarrying(){
		return carryable != null;
	}
	
	bool isUsingWeapons(){
		return weaponSlots != null;
	}
}
