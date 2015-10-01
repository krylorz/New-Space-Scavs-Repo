using UnityEngine;
using System.Collections;

public class DisableAfterTimer : MonoBehaviour {

	public float deathtimer;
	public MonoBehaviour scriptToDisable;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(deathtimer > 0)
		{
			deathtimer -= Time.deltaTime;
		}
		else
		{
			scriptToDisable.enabled = false;
		}
	}
}
