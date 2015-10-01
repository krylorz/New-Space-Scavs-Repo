using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class DeleteAfterAni : MonoBehaviour {
	
	Animator animator;
	
	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Enabled"))
		{	
			GameObject.Destroy (this.gameObject);
		}
	}
}
