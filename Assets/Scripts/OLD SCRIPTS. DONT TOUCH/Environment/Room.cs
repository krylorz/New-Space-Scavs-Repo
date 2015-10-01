using UnityEngine;
using System.Collections;


public class Room : PhysicsEnvironmentObject {
	
	protected override void OnAwake(){
		rb.isKinematic = true;
		rb.useGravity = false;
	}
}
