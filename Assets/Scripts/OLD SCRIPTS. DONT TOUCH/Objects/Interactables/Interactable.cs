using UnityEngine;
using System.Collections;

public enum InteractableType{Default = 10, ItemBox = 2 }


[RequireComponent (typeof (SpriteRenderer))]
public class Interactable : PhysicsEnvironmentObject {

	
	public int maxPlayersControlling;
	int currentPlayersControlling = 0;
	public bool active = true;
	public InteractableType interactableWeight;

	protected override void OnAwake(){
		gameObject.layer = LayerMask.NameToLayer("interactable");
	}
	
	
	
	public void doneInteracting(PlayerBehavior interactee){
		if(active){
			interactee.setInteracting(false);
			currentPlayersControlling --;
			onDoneInteracting();
		}
		
	}
	
	protected virtual void onInteract(PlayerBehavior interactee){
		if(interactee.pc.use){
			doneInteracting(interactee);
		}
	}
	
	protected virtual void onStartInteract(){
		
	}
	
	protected virtual void onDoneInteracting(){
		
	}
	
	public void use(PlayerBehavior interactee){
		if(currentPlayersControlling < maxPlayersControlling){
			interactee.setInteracting(true);
			currentPlayersControlling++;
			onStartInteract();
		}
		else{
			onInteract(interactee);
		}
	}
	
	public bool isBeingUsed(){
		return currentPlayersControlling > 0;
	}
	
	
	
	
	
	
	
	
	
}
