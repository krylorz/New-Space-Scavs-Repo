using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SpriteRenderer))]
public class Item : PhysicsEnvironmentObject, ICarryable {
	
	
	protected SpriteRenderer sr;
	private Combatant currentCombatant;
	public Combatant CurrentCombatant{get {return currentCombatant; }} //set { currentCombatant = value; }}
	Collider prevCollider;
	int itemPickupSort;
	bool pickedUp = false;
	AlignmentType alignment;
	
	
	protected override void OnAwake(){
		sr = GetComponent<SpriteRenderer>();
		sr.sortingLayerName = "item";
		gameObject.layer = LayerMask.NameToLayer("item");
		gameObject.tag = "item";
		itemPickupSort = ItemController.getNextAvailableSortingLayer();
	}
	
	public void pickUp(Combatant currentCombatant){
		this.currentCombatant = currentCombatant;
		transform.rotation = currentCombatant.transform.rotation;
		rb.isKinematic = true;
		collider.enabled = false;
		pickedUp = true;
		onPickUp();
	}
	
	void setAlignment(AlignmentType newAlignment){
		alignment = newAlignment;
		gameObject.tag = Alignment.Alignment2String(newAlignment);
	}
	
	public int getItemPickupLayer(){
		return itemPickupSort;
	}
	
	public void setPickupLayerMax(){
		itemPickupSort = 0;
	}
	
	
	
	protected virtual void onPickUp(){
		
	}
	
	public void drop(Collider carrier){
		
		transform.parent = null;
		this.currentCombatant = null;
		rb.isKinematic = false;
		collider.enabled = true;
		Vector3 theScale = transform.lossyScale;
		theScale.y = Mathf.Abs(theScale.y);
		transform.localScale = theScale;
		transform.localEulerAngles = PhysicsEnvironmentObject.X_ROT_VECTOR;
		pickedUp = false;
		Physics.IgnoreCollision(carrier, this.getCollider());
		prevCollider = carrier;
		Invoke("enableCollision", 0.5f);
		onDrop();
	}
	
	public bool hasCombatant(){
		return currentCombatant != null;
	}
	
	public void dropFromPoint(Collider carrier, Vector3 position){
		position.y = 0;
		transform.position = position;
		drop(carrier);
	}
	
	void enableCollision(){
		Physics.IgnoreCollision(prevCollider, this.getCollider(), false);
		prevCollider = null;
	}

	
	protected virtual void onDrop(){
		
	}
	
	
	public void disableSprite(){
		sr.enabled = false;
	}
	
	public void enableSprite(){
		sr.enabled = true;
	}
	
	
	
	
}
