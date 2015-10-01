using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))] 
public class InteractableFinder : MonoBehaviour {

	Collider itemFinder;
	public CarryableText carryableText;
	static int nextAvailableSortingLayer = 1;
	Interactable highestWeightedInteractable = null;
	
	void Awake(){
		itemFinder = GetComponent<Collider>();
		itemFinder.isTrigger = true;
		gameObject.layer = LayerMask.NameToLayer("interactable_finder");
		if(carryableText == null){ Debug.LogError("No Carryable Text Found in Object Hierarchy!");}
	}
	
	void OnTriggerEnter(Collider collider){
		Debug.Log("Found an interactable!");
		Interactable foundInteractable = collider.gameObject.GetComponent<Interactable>();
		//Item Pickup Weight System. Will Find the Highest weighted item in the group.
		if(highestWeightedInteractable == null || highestWeightedInteractable.interactableWeight < foundInteractable.interactableWeight)
			highestWeightedInteractable = foundInteractable;
		if(carryableText != null)
			carryableText.turnOnText();
	}
	
	void OnTriggerExit(Collider collider){
		Debug.Log("Leaving interactable!");
		if(highestWeightedInteractable != null && collider.gameObject.GetInstanceID() == highestWeightedInteractable.gameObject.GetInstanceID())
			highestWeightedInteractable = null;
		if(carryableText != null)
			carryableText.turnOffText();
	}
	
	public bool use(out Interactable interactable){
		if(highestWeightedInteractable == null){
			interactable = null;
			return false;
		}
		else{
			interactable = highestWeightedInteractable;
			if(carryableText != null)
				carryableText.turnOffText();
			highestWeightedInteractable = null;
			return true;
		}
	}
	
	
}
