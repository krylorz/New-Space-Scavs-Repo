using UnityEngine;
using System.Collections;



[RequireComponent (typeof (SpriteRenderer))]
[RequireComponent (typeof (Damage))]
public class Projectile : PhysicsEnvironmentObject {
	public const float RANGE_INFINITE = 1000;
	
	protected SpriteRenderer sr;
	public float travelSpeed;
	public Damage damage;
	public float maxTravelTime = RANGE_INFINITE;
	public float scale = 1;
	public bool usesGravity = false;
	public float massMultiplier;
	public AlignmentType alignment;
	float totalSpeed;
	public GameObject objectToSpawnOnDestroy_default;
	
	
	protected override void OnAwake(){
		
		//Update Scale
		transform.localScale *= scale;
		//Update Gravity/Mass
		if(usesGravity){
			rb.useGravity = true;
			rb.mass *= massMultiplier;
		}
		else
			rb.useGravity = false;
		rb.constraints = RigidbodyConstraints.FreezeRotation;
		gameObject.layer = LayerMask.NameToLayer("projectile");
		setAlignment(alignment);
		totalSpeed = travelSpeed;
		damage = GetComponent<Damage>();
	}
	
	
	public void setAlignment(AlignmentType alignment){
		
		gameObject.tag = Alignment.Alignment2String(alignment);
		this.alignment = alignment;
			
	}
	
	
	void Update(){
		//this.rb.AddForce(transform.right * totalSpeed);
	}
	
	public void move(){
		this.rb.AddForce(transform.right * totalSpeed, ForceMode.Impulse);
	}
	
	
	
	public void setProjectile(Collider owner, AlignmentType ownerAlignment){
		Physics.IgnoreCollision(owner, this.getCollider());
		alignment = ownerAlignment;
		gameObject.tag = Alignment.Alignment2String(alignment);
	}
	
	public void setProjectile(Quaternion rotation, Collider owner,  AlignmentType ownerAlignment){
		transform.rotation = rotation;
		setProjectile(owner, ownerAlignment);
	}
	
	public void modifyRotation(float spreadAngle){
		
		Vector3 eulerAngles = transform.eulerAngles;
		eulerAngles.z += spreadAngle;
		transform.Rotate(Vector3.forward * spreadAngle);
	}
	
	
	
	public void modifySpeed(float speedMod){
		totalSpeed *= speedMod;
	}	
	
	public void modifyDamageAmount(float damageMultiplier){
		damage.setDamage(damageMultiplier);
	}
	
	public void setNewDamage(Damage newDamage){
		damage = newDamage;
	}
	
	
	
	
	void OnCollisionEnter(Collision collision){
		bool hit = false;
		switch(alignment){
			case AlignmentType.ENEMY:
			hit = !collision.collider.gameObject.CompareTag("enemy");
			break;
			case AlignmentType.FRIENDLY:
			hit = !collision.collider.gameObject.CompareTag("Player") && !collision.collider.gameObject.CompareTag("friendly");
			break;
			case AlignmentType.NEUTRAL:
			hit = true;
			break;
		}
		
		if(hit){
			projectileHit(collision.collider);
		}
	}
	
	public void setVelocity(Vector3 velocity){
		velocity.z = velocity.y;
		velocity.y = 0;
		rb.velocity = velocity;
	}
	
	void spawnObjectOnDestroy(Collider collider){
		if(objectToSpawnOnDestroy_default != null){
			Instantiate(objectToSpawnOnDestroy_default, transform.position, transform.rotation);
		}
	}
	
	
	void projectileHit(Collider collider){
		Health objHitHealth = collider.GetComponent<Health>();
		if(objHitHealth != null){
			damage.inflictDamage(objHitHealth);
			Debug.Log(damage.getTotalDamage() + " damage applied to " + collider.gameObject.name);
		}
		else
			Debug.Log("Damage not applied - Object: " + collider.gameObject.name + " does not have a Health component attached");
		spawnObjectOnDestroy(collider);
		GameObject.Destroy(this.gameObject);
	}
	
	
}
