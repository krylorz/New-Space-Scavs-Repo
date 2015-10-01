using UnityEngine;
using System.Collections;
[RequireComponent (typeof (MeshRenderer))]
[RequireComponent (typeof (TextMesh))]
public class CarryableText : MonoBehaviour {
	MeshRenderer meshrenderer;
	TextMesh text;
	void Awake(){
		text = GetComponent<TextMesh>();
		meshrenderer = GetComponent<MeshRenderer>();
		meshrenderer.sortingLayerName = "ui";
		meshrenderer.enabled = false;
	}
	
	public void turnOnText(){
		meshrenderer.enabled = true;
	}
	
	public void turnOffText(){
		meshrenderer.enabled = false;
	}
	
}
