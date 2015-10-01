using UnityEngine;
using System.Collections;

public class Lighting_Shader_Switcher : MonoBehaviour {

	public SpriteRenderer Character;
	public SpriteRenderer Character_Arm;
	public SpriteRenderer Held_Item;
	public SpriteRenderer Character_Head;

	public Material litMat;
	public Material unlitMat;

	void OnTriggerEnter(Collider other) {

		if(other.gameObject.tag == "Player"){
			Character = other.gameObject.GetComponent<SpriteRenderer>();
			Character.material = litMat;
		}

		if(other.gameObject.tag == "Player_Arm"){
			Character_Arm = other.gameObject.GetComponent<SpriteRenderer>();
			Character_Arm.material = litMat;
		}

		if(other.gameObject.tag == "Held_Item"){
			Held_Item = other.gameObject.GetComponent<SpriteRenderer>();
			Held_Item.material = litMat;
		}

		if(other.gameObject.tag == "Player_Head"){
			Character_Head = other.gameObject.GetComponent<SpriteRenderer>();
			Character_Head.material = litMat;
		}

	}

	void OnTriggerExit(Collider other){

		if(other.gameObject.tag == "Player"){
			Character = other.gameObject.GetComponent<SpriteRenderer>();
			Character.material = unlitMat;
		}
		
		if(other.gameObject.tag == "Player_Arm"){
			Character_Arm = other.gameObject.GetComponent<SpriteRenderer>();
			Character_Arm.material = unlitMat;
		}
		
		if(other.gameObject.tag == "Held_Item"){
			Held_Item = other.gameObject.GetComponent<SpriteRenderer>();
			Held_Item.material = unlitMat;
		}
		
		if(other.gameObject.tag == "Player_Head"){
			Character_Head = other.gameObject.GetComponent<SpriteRenderer>();
			Character_Head.material = unlitMat;
		}

	}
}
