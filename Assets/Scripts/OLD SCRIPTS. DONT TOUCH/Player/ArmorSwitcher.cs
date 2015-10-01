using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class ArmorSwitcher : MonoBehaviour {
	Animator animator;
	int defaultArmorLayer = 0;
	int currentArmorLayer;
	public Sprite defaultArm;
	public GameObject arm;
	
	
	void Awake(){
		animator = GetComponent<Animator>();
		currentArmorLayer = defaultArmorLayer;
	}
	
	public void changeAnimationLayer(string layerName){
		int armorLayer = animator.GetLayerIndex(layerName);
		animator.SetLayerWeight(armorLayer, 1);
		animator.SetLayerWeight(currentArmorLayer, 0);
		currentArmorLayer = armorLayer;
	}
	
	public void resetAnimationLayer(){
		animator.SetLayerWeight(currentArmorLayer, 0);
		animator.SetLayerWeight(defaultArmorLayer, 1);
		currentArmorLayer = defaultArmorLayer;
	}
	
	public void switchArm(Sprite newArm){
		arm.GetComponent<SpriteRenderer>().sprite = newArm;
	}
	
	public void resetArm(){
		arm.GetComponent<SpriteRenderer>().sprite = defaultArm;
	}	
	
	
}
