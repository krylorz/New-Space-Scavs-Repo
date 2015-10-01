using UnityEngine;
using System.Collections;

public class WeaponSlots : MonoBehaviour {
	
	Weapon primaryWeapon;
	Weapon secondaryWeapon;
	public Combatant owner;
	bool weaponsEnabled = true;
	
	public void attachWeapon(Weapon weapon){
		
		if(!isPrimarySlotOccupied()){ //
			primaryWeaponAttach(weapon);
			return;
		}
		else if(!isSecondarySlotOccupied()){ //Backpack first weapon, pick up new weapon as primary
			secondaryWeaponAttach(primaryWeapon);
			primaryWeaponAttach(weapon);
			return;
			
		}
		else if(isPrimarySlotOccupied() && isSecondarySlotOccupied()){
			detachPrimaryWeapon(true);
			primaryWeaponAttach(weapon);
			return;
			
		}
		else{Debug.LogError("Something went wrong, this code should not be accessed");}
	}
	
	void updateLocals(Weapon weapon){
		weapon.transform.position = this.transform.position;
		if(transform.localScale.y > 0){
			Vector3 theScale = transform.localScale;
			theScale.y = Mathf.Abs(theScale.y);
			weapon.transform.localScale = theScale;
		}
		else{
			Vector3 theScale = transform.localScale;
			theScale.y = Mathf.Abs(theScale.y) * -1;
			weapon.transform.localScale = theScale;
		}
		weapon.transform.rotation = transform.rotation;
	}
	
	void primaryWeaponAttach(Weapon weapon){
		primaryWeapon = weapon;
		
		weapon.enableWeapon();
		weapon.enableSprite();
		weapon.pickUp(owner);
		weapon.transform.SetParent(this.transform);
		updateLocals(weapon);
		Debug.Log("Primary Weapon sucessfully picked up!");
	}
	
	void secondaryWeaponAttach(Weapon weapon){
		secondaryWeapon = weapon;
		secondaryWeapon.disableWeapon();
		secondaryWeapon.disableSprite();
	}
	
	
	
	public void detachPrimaryWeapon(bool isSwapping){
		primaryWeapon.disableWeapon();
		primaryWeapon.drop(owner.getCollider());
		primaryWeapon = null;
		if(!isSwapping && isSecondarySlotOccupied()){
			switchWeapons();
		}
	}

	
	
	public void detachSecondaryWeapon(){
		secondaryWeapon.disableWeapon();
		secondaryWeapon.enableSprite();
		secondaryWeapon.drop (primaryWeapon.getCollider());
		secondaryWeapon = null;
	}
	
	public void switchWeapons(){
		if( weaponsEnabled){
			if(isSecondarySlotOccupied() && isPrimarySlotOccupied()){
				Weapon tempWeapon = secondaryWeapon;
				secondaryWeaponAttach(primaryWeapon);
				primaryWeaponAttach(tempWeapon);
				return;
			}
			else if(isSecondarySlotOccupied()){
				primaryWeaponAttach(secondaryWeapon);
				secondaryWeapon = null;
				return;
			}
			else{
				Debug.Log("No Secondary weapon found, no switch");
				return;
			}
		}
		else{ //If weapons are disabled, we still want the secondary weapon to change into the primary slot if it is empty
			if(isSecondarySlotOccupied()){
				primaryWeaponAttach(secondaryWeapon);
				secondaryWeapon = null;
				return;
			}
		}
	
	}
	
	public void disableWeapons(){
		if(isPrimarySlotOccupied()){
			primaryWeapon.disableWeapon();
			primaryWeapon.disableSprite();
		}
		weaponsEnabled = false;
	}
	
	public void enableWeapons(){
		if(isPrimarySlotOccupied()){
			primaryWeapon.enableWeapon();
			primaryWeapon.enableSprite();
		}
		weaponsEnabled = true;
	}
	
	
	
	public void firePrimaryWeapon(){
		if(isPrimarySlotOccupied() && weaponsEnabled){
			primaryWeapon.fire();
		}
	}
	
	
	
	public bool isSecondarySlotOccupied(){
		return secondaryWeapon != null;
	}
	
	public bool isPrimarySlotOccupied(){
		return primaryWeapon != null;
	}
	
}
