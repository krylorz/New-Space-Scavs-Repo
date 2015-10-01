using UnityEngine;
using System.Collections;

public enum MoveDirection{NONE, LEFT, RIGHT};
[RequireComponent (typeof (Rigidbody))]
public class Mover : MonoBehaviour {
	public Player_Controls pc;
	Rigidbody rb;
	public float hMoveSpeed;
	public float hMoveSpeedAirMultiplier;
	public float maxHSpeed;
	Vector3 hMoveVector;
	Vector3 hMoveVectorDefault;
	bool moveAfterJumping = false;
	
	
	void Awake(){
		rb = GetComponent<Rigidbody>();
		hMoveVector = new Vector3 (hMoveSpeed, 0, 0);
		hMoveVectorDefault = new Vector3 (hMoveSpeed, 0, 0);
	}
	
	public void move(MoveDirection direction, bool useInAirMod){
			
		switch (direction){
			case MoveDirection.LEFT:
			
			if(useInAirMod)
				rb.AddRelativeForce( -hMoveVector * hMoveSpeedAirMultiplier, ForceMode.VelocityChange);
			else 
				rb.AddRelativeForce( -hMoveVector, ForceMode.VelocityChange );
			break;
			case MoveDirection.RIGHT:
			if(useInAirMod)
				rb.AddRelativeForce( hMoveVector * hMoveSpeedAirMultiplier, ForceMode.VelocityChange );
				//transform.position += hMoveVector * hMoveSpeedAirMultiplier * Time.deltaTime;
			else
				rb.AddRelativeForce( hMoveVector, ForceMode.VelocityChange  );
				//transform.position += hMoveVector * Time.deltaTime;
			break;
		}
		
		
	}
	
	
	void Update(){
		
		if( Mathf.Abs (rb.velocity.x) > maxHSpeed){
			Vector3 vel = rb.velocity;
			float direction = rb.velocity.x > 0 ? 1 : -1;
			vel.x = maxHSpeed * direction;
			rb.velocity = vel;
		}
		
	}
	
	/*
	public void moveFixed(MoveDirection direction, bool useInAirMod){
		
		switch (direction){
		case MoveDirection.LEFT:
			
			if(useInAirMod)
				rb.MovePosition( transform.position -hMoveVector * hMoveSpeedAirMultiplier);
			else 
				rb.MovePosition( transform.position -hMoveVector );
			break;
		case MoveDirection.RIGHT:
			if(useInAirMod)
				rb.MovePosition( transform.position + hMoveVector * hMoveSpeedAirMultiplier );
			//transform.position += hMoveVector * hMoveSpeedAirMultiplier * Time.deltaTime;
			else
				rb.MovePosition( transform.position + hMoveVector );
			//transform.position += hMoveVector * Time.deltaTime;
			break;
		}
	}
	*/
	public void setMovementSpeed(float newMovementSpeed){
		hMoveVector.x = newMovementSpeed;
	}
	
	public void resetMovementSpeed(){
		hMoveVector = hMoveVectorDefault;
	}
	
	
		
	
}
