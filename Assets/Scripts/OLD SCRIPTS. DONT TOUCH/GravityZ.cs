using UnityEngine;
using System.Collections;

public class GravityZ : MonoBehaviour {
	private static Vector3 globalGravity;
	static Vector3 defaultGravity; //Y Must Be Zero!!!!
	public Vector3 defaultGravityValue;
	
	void Awake(){
		setDefaultGravity(defaultGravityValue);
		setGravity(defaultGravity);
	}
	
	static void setDefaultGravity(Vector3 newdefault){
		if(newdefault.y == 0 ){
			defaultGravity = newdefault;
		}
		else
			Debug.LogError("Default Gravity not changed because Y was not Zero!");
		
	}
	
	public static void setGravity(Vector3 newGravity){
		if(newGravity.y == 0 ){
			globalGravity = newGravity;
			setPhysicsGravity(globalGravity);
		}
		else
			Debug.LogError("Gravity not changed because Y was not Zero!");
	}
	
	public static Vector3 getCurrentGravity(){
		return globalGravity;
	}
	
	public static void resetGravityToDefault(){
		setGravity(defaultGravity);
	}
	
	static void setPhysicsGravity(Vector3 newGravity){
		Physics.gravity = newGravity;
	}
	
	
	
}
