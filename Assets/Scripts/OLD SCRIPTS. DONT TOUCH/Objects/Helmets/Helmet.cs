using UnityEngine;
using System.Collections;

public class Helmet : Item {

	IPassive passive;
	public bool disablesBaseHead;
	
	protected override void OnAwake ()
	{
		base.OnAwake();
		gameObject.tag = "helmet";
		gameObject.layer = LayerMask.NameToLayer("item_noproj");
		
		findPassive();
		
	}
	
	void findPassive(){
		passive = GetComponent<Passive>() as IPassive;
		if(passive == null){Debug.LogError("No passive attached!");}
	}
	
	public Sprite getSprite(){
		return sr.sprite;
	}
	
	protected override void onPickUp ()
	{
		sr.enabled = false;
	}
	
	protected override void onDrop ()
	{
		sr.enabled = true;
	}
	
	
	void findPassiveFromFactory(string passiveName){
		IPassive temp = PassiveFactory.Instance.getPassive(passiveName);
		if(temp != null){
			passive = temp;
		}
		else{ Debug.LogError("No passive attached because there is no passive named: " + passiveName);}
	}
	
	public void switchPassive(string passiveName){
		findPassiveFromFactory(passiveName);
	}
	
	public bool containsPassive(){
		return passive != null;
	}
	
	public void enablePassive(){
		passive.activatePassive();
	}
	
	public void disablePassive(){
		passive.deactivatePassive();
	}
	
	
	
}
