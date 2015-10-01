using UnityEngine;
using System.Collections;

public class WeaponAim : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		float AngleRad = Mathf.Atan2 (Input.mousePosition.y - transform.position.y, Input.mousePosition.x - transform.position.x);
		float AngleDeg = (180 / Mathf.PI) * AngleRad;
		this.transform.rotation = Quaternion.Euler (0, 0, AngleDeg);
	}
}
