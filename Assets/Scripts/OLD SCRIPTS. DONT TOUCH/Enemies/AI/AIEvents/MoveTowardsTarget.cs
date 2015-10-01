using UnityEngine;
using System.Collections;

public class MoveTowardsTarget : AIEvent {

	public float speed;
	Rigidbody rb;
	
	
	protected override void OnAwake ()
	{
		rb = GetComponent<Rigidbody>();
		this.needsToExit = true;
	}
	
	
	protected override void OnStartAction ()
	{
		
	}
	
	protected override void OnActionEvent ()
	{
		if( (transform.position - this.currentStateMachine.enemy.currentTarget.transform.position).sqrMagnitude < 4f){
			Exit();
			return;
		}
		
		
		rb.AddForce( (this.currentStateMachine.enemy.currentTarget.transform.position - transform.position).normalized * speed, ForceMode.Impulse);
		Vector3 nextForce = rb.velocity;
		nextForce.x = Mathf.Clamp(nextForce.x, -speed, speed);
		nextForce.z = Mathf.Clamp(nextForce.z, -speed, speed);
		rb.velocity = nextForce;
	}
	
	protected override void OnExit ()
	{
		rb.velocity = Vector3.zero;
		currentStateMachine.calculateNextEvent();
	}
	
	
	
}
