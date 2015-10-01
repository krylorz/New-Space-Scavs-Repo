using UnityEngine;
using System.Collections;

public class SmoothFollowTarget : MonoBehaviour {
	public GameObject objectToFollow;
	public float speed;
	Vector3 lastGameObjPos;
	public Vector3 offset;
	
	void Awake(){
		lastGameObjPos = transform.position;
		offset.y = transform.position.y;
	}
	
	void LateUpdate(){
		if(objectToFollow != null){
			transform.position = Vector3.Lerp(transform.position, objectToFollow.transform.position + offset, speed);//TODO fix jerkyness with other methods of tranform
			lastGameObjPos = objectToFollow.transform.position;
		}
		else 
			transform.position = Vector3.Lerp(transform.position, lastGameObjPos + offset, speed);
		
	}
	
}
