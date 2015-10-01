using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Mover))]
[RequireComponent (typeof (Jumper))]
[RequireComponent (typeof (Animator))]
[RequireComponent (typeof (PlayerInventory))]
public class PlayerBehavior : Combatant {
	public Player_Controls pc;
	public Aimer aimer;
	//OneWayBypass onewaybypass;
	Animator animator;
	ItemController itemController;
	InteractableFinder interactFinder;
	PlayerInventory inventory;
	Mover localMover;
	Jumper localJumper;
	bool grounded;
	bool moveafterjumping = false;
	bool interacting = false;
	MoveDirection lastMoveDirection = MoveDirection.NONE;
	Interactable currentInteractable;
	
	protected override void OnAwake(){
		
		if(pc == null){
			Debug.LogError("No" + pc.getName() + "attached to this object");
		}
		if(aimer == null){
			Debug.LogError("No Aimer attached to this object");
		}
		localMover = GetComponent<Mover>();
		localJumper = GetComponent<Jumper>();
		//onewaybypass = transform.FindChild("OneWayPlatformCollider").GetComponent<OneWayBypass>();
		animator = GetComponent<Animator>();
		itemController = GetComponentInChildren<ItemController>();
		interactFinder = GetComponentInChildren<InteractableFinder>();
		inventory = GetComponent<PlayerInventory>();
		alignment = AlignmentType.FRIENDLY;
	}
	
	
	
	void Update(){
		grounded = !localJumper.isJumping();
		if(Globals.isInputOn ){
			
			if(interacting){
				currentInteractable.use(this);
			}
			else{
				//Aiming
				if( (Mathf.Abs(pc.x_aim) > 0.1f || Mathf.Abs(pc.y_aim) > 0.1f) || Mathf.Abs(pc.y_aim) > 0.8 || Mathf.Abs(pc.x_aim) > 0.8){
					if(pc.x_aim < 0)
					flip (MoveDirection.LEFT);
					else
					flip (MoveDirection.RIGHT);
					aimer.aim (pc.x_aim, pc.y_aim);
				}
				
				
				
				
				
				//Horiontal Movement
				if(!localJumper.isAirborne()){
					moveafterjumping = false;
					if(pc.x_move > 0){
						lastMoveDirection = MoveDirection.RIGHT;
						if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Walk")){ animator.Play ("Walk");}
						if(transform.localScale.x < 0)
							animator.SetFloat("Speed", -1);
						else
							animator.SetFloat("Speed", 1);
					}
					else if(pc.x_move < 0){
						lastMoveDirection = MoveDirection.LEFT;
						if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Walk")){ animator.Play ("Walk");}
						if(transform.localScale.x < 0)
							animator.SetFloat("Speed", 1);
						else
							animator.SetFloat("Speed", -1);
					}
					else{
						lastMoveDirection = MoveDirection.NONE;
						if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")){ animator.Play ("Idle");}
					}
				}
				else {  //Flying in air
					if(lastMoveDirection == MoveDirection.RIGHT){
						if(pc.x_move < 0){
							lastMoveDirection = MoveDirection.LEFT;
							moveafterjumping = true;
						}
						else {} //Do Nothing
					}
					else if(lastMoveDirection == MoveDirection.LEFT){
						if(pc.x_move > 0){
							lastMoveDirection = MoveDirection.RIGHT;
							moveafterjumping = true;
						}
						else{} //Do Nothing
					}
					else {
						if(pc.x_move < 0){
							lastMoveDirection = MoveDirection.LEFT;
							moveafterjumping = true;
						}
						if(pc.x_move > 0){
							lastMoveDirection = MoveDirection.RIGHT;
							moveafterjumping = true;
						}
					}
					if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Falling")){ animator.Play ("Falling");}
				}
				localMover.move(lastMoveDirection, moveafterjumping);
				if(pc.x_move == 0 &&  !localJumper.isAirborne()){
					Vector3 vel = getRigidBody().velocity;
					vel.x = 0;
					this.getRigidBody().velocity = vel;
				}
				
				//Jumping
				if(pc.jump && !localJumper.isJumping() && !localJumper.isJumpingDown()){
					localJumper.jump();
					if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Jump")){ animator.Play ("Jump");}
					
				}
				else if( localJumper.isJumping() && localJumper.isFalling() ){
					localJumper.turnOffOneWay();
					if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Falling")){ animator.Play ("Falling");}
				}
				else{} //DoNothing
				
				//MoveDown
				if(grounded && pc.y_move == -1.0f && localJumper.ableToJumpDown()){
					if(localJumper.jumpDown()){
						if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Falling")){ animator.Play ("Falling");}
					}
				}
				
				//Equip Carryables
				if(pc.equip){
					GameObject item;
					if( itemController.pickUp(out item)){
						inventory.pickUp(item);
					}
					else{
						Debug.LogWarning("Pressed equip, but no item found");
					}
				}
				
				//SwitchWeapons
				if(pc.weaponswap){
					inventory.carrySlot.dropObj();
					inventory.weaponSlots.switchWeapons();
				}
				
				//Fire Primary Weapon
				if(pc.weapon){
					inventory.weaponSlots.firePrimaryWeapon();
				}
				
				//Throw
				if(pc.throwobj){
					inventory.carrySlot.throwObj();
				}
				
				if(pc.use){
					Interactable interactable;
					if( interactFinder.use(out interactable)){
						interactable.use(this);
						currentInteractable = interactable;
					}
					else{
						Debug.LogWarning("Pressed use, but no interactable found");
					}
				}
				
				if(pc.ability){
					inventory.armorSlot.useArmorAbility();
				}
			}
			
			
		}
	}
	
	/*
	void FixedUpdate(){
		localMover.moveFixed(lastMoveDirection, moveafterjumping);
	}
	*/
	
	public void setInteracting(bool isInteracting){
		interacting = isInteracting;
		if(!isInteracting){
			currentInteractable = null;		
		}
	}
	
	
	
	
	
	
	
}
