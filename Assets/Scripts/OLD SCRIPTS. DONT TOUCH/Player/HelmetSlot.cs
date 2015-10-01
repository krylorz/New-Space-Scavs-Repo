using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SpriteRenderer))]
public class HelmetSlot : MonoBehaviour {

	public GameObject head;
	SpriteRenderer headsr;
	SpriteRenderer sr;
	Helmet primaryHelmet;
	public Combatant owner;
	
	
	void Awake(){
		sr = GetComponent<SpriteRenderer>();
		if(head == null){Debug.LogError("404: Head not found");}
		headsr = head.GetComponent<SpriteRenderer>();
		if(headsr == null){Debug.LogError("Head does not have a sprite renderer"); }
	}
	
	void changeHeadSprite(Helmet helmet){
		if(helmet.disablesBaseHead)
			headsr.enabled = false;
		sr.enabled = true;
		sr.sprite = helmet.getSprite();
	}
	
	void removeHelmetSprite(){
		headsr.enabled = true;
		sr.enabled = false;
	}
	
	
	public void attachHelmet(Helmet helmet){
		if(isPrimarySlotOccupied()){
			removeHelmet();
		}
		primaryHelmet = helmet;
		helmet.enablePassive();
		changeHeadSprite(helmet);
		helmet.disableSprite();
		helmet.pickUp(owner);
		helmet.transform.position = this.transform.position;
		helmet.transform.SetParent(this.transform);
		Debug.Log("Primary helmet sucessfully picked up!");
	}
	
	public void removeHelmet(){
		if(isPrimarySlotOccupied()){
			
			primaryHelmet.transform.parent = null;
			primaryHelmet.disablePassive();
			primaryHelmet.enableSprite();
			primaryHelmet.drop(owner.getCollider());
			removeHelmetSprite();
			primaryHelmet = null;
		}
	}
	
	public bool isPrimarySlotOccupied(){
		return primaryHelmet != null;
	}
}
