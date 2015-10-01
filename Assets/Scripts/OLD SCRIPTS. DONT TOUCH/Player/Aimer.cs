using UnityEngine;
using System.Collections;

public class Aimer : MonoBehaviour {
	
	public AimHelper aimHelper;
	public GameObject rootPlayer;
	
	void aimAtHelper(){
		if(rootPlayer.transform.lossyScale.x < 0){
			Vector3 fuckUnity = transform.localScale;
			fuckUnity.y = Mathf.Abs(fuckUnity.y) *-1;
			transform.localScale = fuckUnity;
		}
		else{
			Vector3 fuckUnity = transform.localScale;
			fuckUnity.y = Mathf.Abs(fuckUnity.y);
			transform.localScale = fuckUnity;
		}
		
		transform.LookAt(aimHelper.transform.position);
		transform.Rotate( new Vector3(90, 0, 90));
		
		//transform.Rotate( new Vector3(-90, 0, 0));
	}
	
	void LateUpdate(){
		followRoot();
	}
	
	
	
	public void aim(float X, float Y){
		
		/*
		if(transform.localScale.x > 0)
			aimHelper.aim(X, Y);
		else
			aimHelper.aim(-X, Y);
		*/
		aimHelper.aim(Mathf.Abs(X), Y);
		aimAtHelper();
		/*
		float angleInRadians =0 ;
		if(transform.rotation.z > 0){
			angleInRadians = Mathf.Atan2(-Y, X) - Mathf.Atan2(0, 1);
			float degrees = angleInRadians * Mathf.Rad2Deg;
			aimVector.z = degrees;
		}
		else if(transform.rotation.z < 0f){
			angleInRadians = Mathf.Atan2(-Y, X) - Mathf.Atan2(0, 1);
			float degreesneg = angleInRadians * Mathf.Rad2Deg;
			aimVector.z = -degreesneg;
		}
		transform.localEulerAngles = aimVector;
		*/
	}
	
	void followRoot(){
		transform.position = rootPlayer.transform.position;
	}
	
	
	
	
	
}
