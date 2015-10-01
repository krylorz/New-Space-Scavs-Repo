﻿using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	Rigidbody2D rb;
	Animator playerAni;
	Vector2 jumpforce;
	bool inair;
	public Sprite fall;
	public Sprite jump;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		playerAni = GetComponentInChildren<Animator>();
		jumpforce = new Vector2(0f,200f);
		inair = false;
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if( inair)
		{
			playerAni.enabled = false;
		}
		else
		{
			playerAni.enabled = true;
		}
		//To move left and right use the Horizontal Axis
		if(Mathf.Abs (Input.GetAxis("Horizontal")) > 0.2f)
		{
			if(inair == false)
			{
				playerAni.Play("bodywalk");
			}
			// cheap way to max out velocity
			if(Mathf.Abs(rb.velocity.x) <0.8f)
			{
				//add velocity
				rb.velocity +=new Vector2( Input.GetAxis("Horizontal") *0.2f,0);
			}

		}
		// idle
		else
		{
			if(inair == false)
			{
				playerAni.Play("idle");

				//make the player come to a full stop a bit sooner after the input has stopped
				//i.e. reduce the "sliding" effect
				rb.velocity = new Vector2(0.9f*rb.velocity.x,rb.velocity.y);
			}
		}
		//jumping
		if(Input.GetAxis("Jump")>0f && inair == false)
		{

			rb.AddForce(jumpforce);
			inair = true;
		}
		if(inair == true && rb.velocity.y > 0.0f)
		{
			GameObject.FindGameObjectWithTag("body").GetComponent<SpriteRenderer>().sprite = jump;
		}
		else if (inair == true && rb.velocity.y < 0.0f)
		{
			GameObject.FindGameObjectWithTag("body").GetComponent<SpriteRenderer>().sprite = fall;
		}

		//if moving left, scale to -1
		if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
		{
			//do we really want this or should sprite facing be determined by weapon aim?
			Vector3 newscale = transform.localScale;
			newscale.x =-1;
			transform.localScale = newscale;
		}
		else
		{
			Vector3 newscale = transform.localScale;
			newscale.x =1;
			transform.localScale = newscale;
		}

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "floor")
		{
			inair = false;
		}
		if(other.gameObject.tag =="weapon")
		{
			Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), other.gameObject.GetComponent<BoxCollider2D>());
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag =="weapon")
		{
			if(Input.GetKeyDown(KeyCode.X))
			{
				//finding point to lock weapon to hand
				other.transform.parent = GetComponentInChildren<WeaponAim>().transform.FindChild("PlayerHand").transform;
				//sync position

				//first get the difference to move from grip point of weapon to hand
				Vector3 posDiff = other.transform.parent.position - other.transform.FindChild("weaponGrip").transform.position;

				//then move weapon by that much
				other.transform.position = other.transform.position + posDiff;

				//sync scale
				other.transform.transform.localScale =other.transform.parent.transform.localScale;

				//sync rotation
				other.transform.transform.rotation =other.transform.parent.transform.rotation;
			}
		}
	}
}
