using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

	Rigidbody2D rb;
	public GameObject proj;

	//for modification for other weapons
	Transform fireLocation;

	//reload Stuff

	bool reloading;
	public float reloadTime = 1.0f;
	public float curTime = 0;
	// Use this for initialization
	void Start () {
		reloading = false;
		rb = GetComponent<Rigidbody2D>();
		fireLocation = transform.FindChild("firePoint");
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.parent != null)
		{
			rb.isKinematic = true;
		}
		else
		{
			rb.isKinematic = false;
		}

		if(reloading)
		{
			curTime += Time.deltaTime;
			if(curTime >= reloadTime)
			{
				reloading = false;
				curTime = 0.0f;
			}
		}
	
	}

	public void Shoot()
	{
		if(!reloading)
		{
			Vector3 direction = fireLocation.position - this.transform.position;
			GameObject projShot = Instantiate(proj,fireLocation.position,fireLocation.rotation) as GameObject;
			projShot.GetComponent<ProjectileNew>().dir = direction;

			if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
			{
				projShot.GetComponent<ProjectileNew>().faceLeft =true;
			}
			reloading = true;
		}


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "weapon")
		{
			Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(),other);
			Physics2D.IgnoreCollision(this.GetComponent<CircleCollider2D>(),other);
		}
	}
}
