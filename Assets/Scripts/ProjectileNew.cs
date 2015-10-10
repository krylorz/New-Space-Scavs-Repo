using UnityEngine;
using System.Collections;

public class ProjectileNew : MonoBehaviour {


	public Vector3 dir;
	Rigidbody2D rb;
	public bool faceLeft;
	public float speed = 3f;
	public GameObject flash;
	public GameObject explosion;
	// Use this for initialization
	void Start () 
	{

		rb = GetComponent<Rigidbody2D>();

		if (faceLeft)
		{
			//do we really want this or should sprite facing be determined by weapon aim?
			Vector3 newscale = transform.localScale;
			newscale.x =-1;
			transform.localScale = newscale;
			Vector3 newRot = transform.rotation.eulerAngles;
			newRot.z = -newRot.z;
			transform.rotation= Quaternion.Euler(newRot);

		}

		GameObject obj = Instantiate(flash,this.transform.position,this.transform.rotation) as GameObject;
		obj.transform.localScale = this.transform.localScale;

	}
	
	// Update is called once per frame
	void Update () 
	{
		rb.velocity = dir.normalized * speed;
	}

	void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			Destroy(this.gameObject);
		}
	}

	void OnDestroy()
	{
		Instantiate(explosion,this.transform.position,this.transform.rotation);
	}
}
