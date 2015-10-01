using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {
	
	public WeaponSlots weaponSlots;
	public HelmetSlot helmetSlot;
	public ArmorSlot armorSlot;
	public CarrySlot carrySlot;
	
	
	void Awake(){
		if(weaponSlots == null)
			weaponSlots = GetComponentInChildren<WeaponSlots>();
		if(weaponSlots == null){Debug.LogError("Primary Weapon Slot not found in object hierarchy");}
	}	
	
	public void pickUp(GameObject item){
		if(item == null){
			Debug.LogError("item passed in is null!");
			return;
		}
		else{
			switch(item.tag){
				case "weapon":
					pickUpWeapon(item.GetComponent<Weapon>());
				break;
				case "helmet":
					pickUpHelmet(item.GetComponent<Helmet>());
				break;
				case "armor":
					pickUpArmor(item.GetComponent<Armor>());
				break;
				case "carryable":
					pickUpCarryable(item.GetComponent<Carryable>());
				break;
			}
		}
	}	
	
	
	
	void pickUpWeapon(Weapon weapon){
		weaponSlots.attachWeapon(weapon);
	}
	
	void pickUpHelmet(Helmet helmet){
		helmetSlot.attachHelmet(helmet);
	}
	
	void pickUpArmor(Armor armor){
		armorSlot.attachArmor(armor);
	}
	
	void pickUpCarryable(Carryable carryable){
		carrySlot.pickUpObj(carryable);
	}
	
}
