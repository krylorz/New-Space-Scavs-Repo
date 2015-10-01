using UnityEngine;
using System.Collections;


//Hover will move an AI around in both X/Y (Z in engine) 
//This script will repeat and reset automatically, the only way to exit this script is externally.
public class Hover : AIEvent {
	
	
	public float maxRange = 0;
	
	public float speed = 0;
	Vector3 originalpos;
	Vector3 destination;
	Rigidbody rb;
	
 	protected override void OnAwake ()
	{
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false;
		this.eventName = "Hover";
		originalpos = transform.position;
		
	}
	
	protected override void OnStartAction ()
	{
		if(rb== null){rb = GetComponent<Rigidbody>();}
		
		rb.velocity = Vector3.zero;
		Vector2 randompoint = Random.insideUnitCircle;
		randompoint *= maxRange;  
		Vector3 randomPointEngine = Vector3.zero;
		randomPointEngine.x = randompoint.x;
		randomPointEngine.z = randompoint.y;
		randomPointEngine += originalpos;
		destination = randomPointEngine;
		Vector3 force = Vector3.zero;
		force = (randomPointEngine - transform.position).normalized * speed;
		rb.AddForce(force, ForceMode.Impulse);
	}

	
	protected override void OnActionEvent ()
	{
		if( (transform.position - destination).sqrMagnitude < 1f){
			this.StartAction();
		}
	}
	
	protected override void OnExit ()
	{
		
	}
	
	//Resets the script if contact is made with objects
	void OnCollisionEnter(Collision collision){
		StartAction();
	}
	void OnCollisionStay(Collision collision){
		StartAction();
	}
	
}
