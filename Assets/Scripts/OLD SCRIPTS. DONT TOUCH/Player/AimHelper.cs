using UnityEngine;
using System.Collections;

public class AimHelper : MonoBehaviour {

	public float offsetScalar = 1f;
	
	public void aim(float X, float Y){
		transform.localPosition = new Vector3(X, -Y, 0);
		transform.localPosition *= offsetScalar;
	}
}
