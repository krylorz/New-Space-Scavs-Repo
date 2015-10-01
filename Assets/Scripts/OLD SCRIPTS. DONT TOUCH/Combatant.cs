using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
[RequireComponent (typeof (Rigidbody))]
public class Combatant : MonoBehaviour {
	new Collider collider;
	Rigidbody rb;
	public AlignmentType alignment = AlignmentType.NEUTRAL;
	
	void Awake(){
		collider = GetComponent<Collider>();
		rb = GetComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
		gameObject.layer = LayerMask.NameToLayer("combatant");
		OnAwake();
	}
	
	protected virtual void OnAwake(){
		
	}
	
	public Collider getCollider(){
		return collider;
	}
	
	public Rigidbody getRigidBody(){
		return rb;
	}
	
	void LateUpdate(){
		if(rb.velocity.sqrMagnitude > PhysicsEnvironmentObject.MAX_VELOCITY){ //TODO: detach Max Velocity from PhysicsEnvironmentObject
			float limit = rb.velocity.sqrMagnitude / PhysicsEnvironmentObject.MAX_VELOCITY;
			rb.velocity /= limit;
		}
	}
	
	
	protected void flip(MoveDirection directionToFlip){
		Vector3 theScale = transform.localScale;
		switch (directionToFlip){
		case MoveDirection.RIGHT:
			theScale.x = Mathf.Abs(theScale.x);
			transform.localScale = theScale;
			break;
		case MoveDirection.LEFT:
			theScale.x = Mathf.Abs(theScale.x) * -1;
			transform.localScale = theScale;
			break;
		}
		
	}
	
}
