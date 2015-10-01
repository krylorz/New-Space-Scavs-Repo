using UnityEngine;
using System.Collections;

public class Carryable : Item {

	bool isActive = false;
	public float throwForce;
	
	protected override void OnAwake ()
	{
		base.OnAwake ();
		gameObject.layer = LayerMask.NameToLayer("item");
		gameObject.tag = "carryable";
	}
	
	public void use(){
		if(isActive){
			onUse();
			isActive = false;
		}
	}
	
	protected virtual void onUse(){}
	protected virtual void onThrow(){}
	
	public void throwme(Collider collider, float throwModifier){
		if(isActive){
			isActive = false;
			float beforeDropScaleY = transform.lossyScale.y >= 0 ? 1 : -1;
			drop(collider);
			rb.AddForce(transform.right * beforeDropScaleY * throwForce * throwModifier, ForceMode.Impulse);
			/*
			Vector3 Xscale = transform.localScale;
			Xscale.x *= beforeDropScaleY;
			transform.localScale = Xscale;
			*/
			onThrow();
		}
		
	}
	
	protected override void onPickUp ()
	{
		base.onPickUp ();
		isActive = true;
	}
	
	protected override void onDrop ()
	{
		base.onDrop ();
		isActive = false;
	}
	
	
	
}
