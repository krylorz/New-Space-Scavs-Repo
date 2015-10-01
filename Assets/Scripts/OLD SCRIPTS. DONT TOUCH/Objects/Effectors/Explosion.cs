using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Damage))]
[RequireComponent (typeof (SphereCollider))]
[RequireComponent (typeof (SpriteRenderer))]
[RequireComponent (typeof (Animator))]
public class Explosion : MonoBehaviour {
	Damage damage;
	public float explosionForce;
	float explosionRadius;
	public float verticalForce;
	
	
	void Awake(){
		gameObject.layer = LayerMask.NameToLayer("effector");
		damage = GetComponent<Damage>();
		explosionRadius = GetComponent<SphereCollider>().radius * 5;
		GetComponent<SphereCollider>().isTrigger = true;
		Vector3 positionMod = transform.position;
		positionMod.y = 0;
		transform.position = positionMod;
		
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider collider){
		PhysicsEnvironmentObject peo = collider.gameObject.GetComponent<PhysicsEnvironmentObject>();
		if(peo != null){
			peo.addExplosionForce(explosionForce, transform.position, explosionRadius, verticalForce);
		}
		Health objhealth = collider.gameObject.GetComponent<Health>();
		if(objhealth != null){
			objhealth.takeDamage(damage.damage);
		}
	}
}
