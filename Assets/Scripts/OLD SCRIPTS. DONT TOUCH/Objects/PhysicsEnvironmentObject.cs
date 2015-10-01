using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Collider))]
public class PhysicsEnvironmentObject : MonoBehaviour {

	
	protected Rigidbody rb;
	new protected Collider collider;
	static Vector3 X_ROTATION = new Vector3(90, 0, 0);
	public static float MAX_VELOCITY = 1000f;
	//static float MAX_VELOCITY_SLOWDOWN = 0.99f;
	public static Vector3 X_ROT_VECTOR{ get{return X_ROTATION;}}
	
	void Awake(){
		rb = GetComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
		collider = GetComponent<Collider>();
		transform.position = new Vector3(transform.position.x, 0, transform.position.z);
		transform.rotation = Quaternion.Euler(X_ROTATION);
		gameObject.layer = LayerMask.NameToLayer("physicsobject");
		OnAwake();
		
	}
	
	public Collider getCollider(){
		return collider;
	}
	
	public void addExplosionForce(float explosionForce,Vector3 explosionPosition,  float explosionRadius, float upwardsModifier){
		rb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, upwardsModifier, ForceMode.Impulse);
	}
	
	void LateUpdate(){
		if(rb.velocity.sqrMagnitude > MAX_VELOCITY){
			float limit = rb.velocity.sqrMagnitude /  MAX_VELOCITY;
			rb.velocity /= limit;
		}
	}
	
	
	protected virtual void OnAwake(){}
}
