using UnityEngine;
using System.Collections;

public class Armor : Item {
	public string armorAnimationLayerName;
	public Sprite armSprite;
	bool canUseAbility = false;
	ArmorAbility primaryAbility;
	
	protected override void OnAwake ()
	{
		base.OnAwake();
		gameObject.tag = "armor";
		gameObject.layer = LayerMask.NameToLayer("item_noproj");
		primaryAbility = GetComponent<ArmorAbility>();
	}
	
	protected override void onPickUp ()
	{
		enableAbility();
	}
	
	protected override void onDrop ()
	{
		disableAbility();
	}
	
	public void enableAbility(){
		canUseAbility = true;
	}
	
	public void disableAbility(){
		canUseAbility = false;
	}
	
	public void useAbility(){
		if(canUseAbility && primaryAbility != null){
			primaryAbility.use();
		}
	}
}
