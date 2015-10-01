using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Item))]
public class Passive : MonoBehaviour, IPassive {

	public string passiveName;
	Item owner;
	
	void Awake(){
		owner = GetComponent<Item>();
	}
	
	public string getName(){
		return passiveName;
	}
	
	
	
	public void activatePassive(){
		
	}
	
	public void deactivatePassive(){
		
	}
	
	
	
	
	/*	Possibly for future children
	public static void createAndAttachPassive(GameObject toBeAttachedTo, string passiveName){
		
	}
	*/
}
