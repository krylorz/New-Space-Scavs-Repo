using UnityEngine;
using System.Collections;

public class ArmorSlot : MonoBehaviour {

	Armor primaryarmor;
	public Combatant owner;
	ArmorSwitcher armorSwitcher;
	
	
	void Awake(){
		armorSwitcher = owner.GetComponent<ArmorSwitcher>();
		if(armorSwitcher == null){
			Debug.Log("Armor Switcher not found, not using animation switching");
		}
	}
	
	
	
	public void attachArmor(Armor armor){
		if(isPrimarySlotOccupied()){
			removeArmor();
		}
		primaryarmor = armor;
		armor.enableAbility();
		changeArmor(armor);
		armor.disableSprite();
		armor.pickUp(owner);
		armor.transform.position = this.transform.position;
		armor.transform.SetParent(this.transform);
		Debug.Log("Primary armor sucessfully picked up!");
	}
	
	public void removeArmor(){
		if(isPrimarySlotOccupied()){
			primaryarmor.transform.parent = null;
			primaryarmor.disableAbility();
			primaryarmor.enableSprite();
			primaryarmor.drop(owner.getCollider());
			defaultArmor();
			primaryarmor = null;
		}
	}
	
	void changeArmor(Armor armor){
		if(armorSwitcher != null){
			armorSwitcher.changeAnimationLayer(armor.armorAnimationLayerName);
			armorSwitcher.switchArm(armor.armSprite);
		}
	}
	
	void defaultArmor(){
		if(armorSwitcher != null){
			armorSwitcher.resetAnimationLayer();
			armorSwitcher.resetArm();
		}
	}
	
	public bool isPrimarySlotOccupied(){
		return primaryarmor != null;
	}
	
	public void useArmorAbility(){
		if(isPrimarySlotOccupied()){
			primaryarmor.useAbility();
		}
	}
}
