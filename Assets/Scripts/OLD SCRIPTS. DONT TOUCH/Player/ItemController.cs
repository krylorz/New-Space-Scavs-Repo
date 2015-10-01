using UnityEngine;
using System.Collections;

public enum ItemType{WEAPON, CARRYABLE, ARMOR, HELMET};

[RequireComponent (typeof (Collider))] 
public class ItemController : MonoBehaviour {
	Collider itemFinder;
	public CarryableText carryableText;
	static int nextAvailableSortingLayer = 1;
	Item highestWeightedItem = null;
	
	
	void Awake(){
		itemFinder = GetComponent<Collider>();
		itemFinder.isTrigger = true;
		gameObject.layer = LayerMask.NameToLayer("item_finder");
		if(carryableText == null){ Debug.LogError("No Carryable Text Found in Object Hierarchy!");}
	}
	
	void OnTriggerEnter(Collider collider){
		
		switch(collider.gameObject.tag){
			case "weapon":
			Debug.Log("Found a weapon!");
			Item foundWeapon = collider.gameObject.GetComponent<Item>();
			//Item Pickup Weight System. Will Find the Highest weighted item in the group.
			if(highestWeightedItem == null || highestWeightedItem.getItemPickupLayer() < foundWeapon.getItemPickupLayer())
				highestWeightedItem = foundWeapon;
			if(carryableText != null)
				carryableText.turnOnText();
			//TODO: Add text based on weapon name
			break;
			case "helmet":
			Debug.Log("Found a helmet!");
			Item foundHelmet = collider.gameObject.GetComponent<Item>();
			if(highestWeightedItem == null || highestWeightedItem.getItemPickupLayer() < foundHelmet.getItemPickupLayer())
				highestWeightedItem = foundHelmet;
			if(carryableText != null)
				carryableText.turnOnText();
			break;
			case "armor":
			Debug.Log("Found armor!");
			Item foundArmor = collider.gameObject.GetComponent<Item>();
			if(highestWeightedItem == null || highestWeightedItem.getItemPickupLayer() < foundArmor.getItemPickupLayer())
				highestWeightedItem = foundArmor;
			if(carryableText != null)
				carryableText.turnOnText();
			break;
			case "carryable":
			Debug.Log("Found carryable!");
			Item foundCarryable = collider.gameObject.GetComponent<Item>();
			if(highestWeightedItem == null || highestWeightedItem.getItemPickupLayer() < foundCarryable.getItemPickupLayer())
				highestWeightedItem = foundCarryable;
			if(carryableText != null)
				carryableText.turnOnText();
			break;
		}
		//TODO: Add switch based on item tag
		
	}
	
	void OnTriggerExit(Collider collider){
		switch(collider.gameObject.tag){
		case "weapon":
			Debug.Log("Leaving weapon!");
			if( highestWeightedItem != null && collider.gameObject.GetInstanceID() == highestWeightedItem.gameObject.GetInstanceID())
				highestWeightedItem = null;
			if(carryableText != null)
				carryableText.turnOffText();
			break;
		case "helmet":
			Debug.Log("Leaving helmet!");
			if( highestWeightedItem != null && collider.gameObject.GetInstanceID() == highestWeightedItem.gameObject.GetInstanceID())
				highestWeightedItem = null;
			if(carryableText != null)
				carryableText.turnOffText();
			break;
		case "armor":
			Debug.Log("Leaving armor!");
			if( highestWeightedItem != null && collider.gameObject.GetInstanceID() == highestWeightedItem.gameObject.GetInstanceID())
				highestWeightedItem = null;
			if(carryableText != null)
				carryableText.turnOffText();
			break;
		case "carryable":
			Debug.Log("Leaving carryable!");
			if( highestWeightedItem != null && collider.gameObject.GetInstanceID() == highestWeightedItem.gameObject.GetInstanceID())
				highestWeightedItem = null;
			if(carryableText != null)
				carryableText.turnOffText();
			break;
		
		}
		
		/*
		if( collider.gameObject.CompareTag("weapon")){
			Debug.Log("Leaving weapon!");
			if( highestWeightedItem != null && collider.gameObject.GetInstanceID() == highestWeightedItem.gameObject.GetInstanceID())
				highestWeightedItem = null;
			carryableText.turnOffText();
		}
		*/
		
	}
	
	public bool pickUp(out GameObject item){
		if(highestWeightedItem == null){
			item = null;
			return false;
		}
		else{
			item = highestWeightedItem.gameObject;
			if(carryableText != null)
				carryableText.turnOffText();
			highestWeightedItem = null;
			return true;
		}
	}
	
	public static int getNextAvailableSortingLayer(){
		return nextAvailableSortingLayer++;
	}
	
}
