﻿using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.parent != null)
		{
			rb.isKinematic = true;
		}
	
	}
}
