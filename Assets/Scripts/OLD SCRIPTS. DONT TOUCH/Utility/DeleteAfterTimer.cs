using UnityEngine;
using System.Collections;

public class DeleteAfterTimer : MonoBehaviour {

	public float deathtimer;

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
			GameObject.Destroy(this.gameObject);
		}
	}
}
