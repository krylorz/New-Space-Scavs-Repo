using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Collider))]
public class Jumper : MonoBehaviour {
	
	Rigidbody rb;
	new Collider collider;
	private bool jumping = true;
	public float verticalJumpForce;
	public float jumpDownDelay;
	
	Vector3 jumpForce;
	Collider oneWayPlatform;
	bool onewayjumpactive = true;
	bool jumpingDown = false;
	bool airborne = true;
	
	
	void Awake(){
		rb = GetComponent<Rigidbody>();
		jumpForce = new Vector3(0,0,verticalJumpForce);
		collider = GetComponent<Collider>();
	}
	
	
	
	public void jump(){
		jumping = true;
		rb.AddForce(jumpForce, ForceMode.Impulse);
		airborne = true;
	}
	
	public void overrideJump(){
		jumping = true;
	}
	
	public bool isJumping(){
		return jumping;
	}
	
	public bool isAirborne(){
		
		return jumping || !Physics.Raycast(transform.position + Vector3.back, Vector3.back, 0.5f, 1 << LayerMask.NameToLayer("terrain"));
	}
	
	
	public bool isFalling(){
		return rb.velocity.z < 0;
	}
	
	public bool isJumpingDown(){
		return jumpingDown;
	}
	
	void Update(){
		Debug.DrawLine(transform.position + (Vector3.back * 1.0f), transform.position + (Vector3.back * 1.5f), Color.green, 0.2f, false);
	}
	
	public void turnOffOneWay(){
		if(oneWayPlatform != null){
			Physics.IgnoreCollision(collider, oneWayPlatform, false);
			onewayjumpactive = true;
		}
	}
	
	public bool ableToJumpDown(){
		return onewayjumpactive;
	}
	
	public bool jumpDown(){
		RaycastHit hitInfo;
		
		if( Physics.Raycast(transform.position + Vector3.back , Vector3.back, out hitInfo, 0.5f,1 <<  LayerMask.NameToLayer("terrain")) &&
		hitInfo.collider.gameObject.CompareTag("floor_oneway")){
			onewayjumpactive = false;
			jumpingDown = true;
			this.oneWayPlatform = hitInfo.collider;
			Physics.IgnoreCollision(collider, oneWayPlatform, true);
			return true;
		}
		else{
			Debug.Log("No One Way Platform Found Below");
			return false;
		}
		
	}
	
	void resetJumpDown(){
		if(oneWayPlatform != null){
			Physics.IgnoreCollision(collider, oneWayPlatform, false);
			oneWayPlatform = null;
		}
	}
		
	
	void jumpDownTimerReset(){
		onewayjumpactive = true;
	}
	
	void turnOnOneWay(Collider oneWayPlatform){
		this.oneWayPlatform = oneWayPlatform;
		Physics.IgnoreCollision(collider, oneWayPlatform, true);
	}
	
	
	void OnCollisionEnter(Collision collision) {
		if( collision.collider.gameObject.CompareTag("floor") || collision.collider.gameObject.layer == LayerMask.NameToLayer("combatant")){
			jumping = false;
			onewayjumpactive = false;
			jumpingDown = false;
			Invoke("jumpDownTimerReset", jumpDownDelay);
			airborne = false;
		}
		else if( collision.collider.gameObject.CompareTag("floor_oneway")){
			//if(onewayjumpactive){
			onewayjumpactive = false;
			jumping = false;
			jumpingDown = false;
			oneWayPlatform = null;
			Invoke("jumpDownTimerReset", jumpDownDelay);
			airborne = false;
			//}
			/*
			else{
				oneWayPlatform = collision.collider;
				Physics.IgnoreCollision(collider, oneWayPlatform, true);
			}
			*/
		}
	}
	
	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.CompareTag("floor_oneway") && this.isJumping() && !this.isFalling()){
			//Enter Bottom of OneWayPlatform
			//Disable Collisions between platform and player
			if(oneWayPlatform != null && oneWayPlatform.gameObject.GetInstanceID() !=  collider.gameObject.GetInstanceID()){
				turnOffOneWay();
			}
			turnOnOneWay(collider);
		}
	}
	
	void OnTriggerExit(Collider collider){
		if(collider.gameObject.CompareTag("floor_oneway") && this.isFalling()){
			//Enter Bottom of OneWayPlatform
			//Disable Collisions between platform and player
			this.resetJumpDown();
		}
	}
	
	
	
}
