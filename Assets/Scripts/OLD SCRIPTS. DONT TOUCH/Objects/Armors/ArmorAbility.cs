using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Armor))]
public abstract class ArmorAbility : MonoBehaviour {
	
	protected Armor armor;
	
	void Awake(){
		armor = GetComponent<Armor>();
		onAwake();
	}
	
	protected abstract void onAwake();
	
	public void use(){
		onUse();
	}
	
	protected abstract void onUse();
}
