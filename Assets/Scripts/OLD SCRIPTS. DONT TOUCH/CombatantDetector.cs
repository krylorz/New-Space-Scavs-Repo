using UnityEngine;
using System.Collections;

public enum DetectorType{PLAYER, ENEMY, ALL};

[RequireComponent (typeof (Collider))]
public class CombatantDetector : MonoBehaviour {

	public Collider detector;
	public DetectorType detectEnemyType;
	public MonoBehaviour callbackObj;
	
	void Awake(){
		detector = GetComponent<Collider>();
		detector.isTrigger = true;
		gameObject.layer = LayerMask.NameToLayer("combatant_detector");
	}
	
	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.GetInstanceID() != transform.parent.gameObject.GetInstanceID() 
		&& !collider.isTrigger){
			switch(detectEnemyType){
				case DetectorType.ENEMY:
				if(collider.gameObject.CompareTag("enemy")){
					Debug.Log("Enemy Found");
					callbackObj.SendMessage("enemyEnter", collider.gameObject );
				}
				break;
				case DetectorType.PLAYER:
				if(collider.gameObject.CompareTag("Player")){
					Debug.Log("Player found");
					callbackObj.SendMessage("playerEnter", collider.gameObject );
				}
				break;
				case DetectorType.ALL:
				if(collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("enemy")){
					Debug.Log ("Combatant Found");
					callbackObj.SendMessage("combatantEnter", collider.gameObject );
				}
				break;
			}
		}
	}
	
	void OnTriggerExit(Collider collider){
		if(collider.gameObject.GetInstanceID() != transform.parent.gameObject.GetInstanceID()
		   && !collider.isTrigger){
			switch(detectEnemyType){
			case DetectorType.ENEMY:
				if(collider.gameObject.CompareTag("enemy")){
					Debug.Log("Enemy left");
					callbackObj.SendMessage("enemyLeave", collider.gameObject );
				}
				break;
			case DetectorType.PLAYER:
				if(collider.gameObject.CompareTag("Player")){
					Debug.Log("Player left");
					callbackObj.SendMessage("playerLeave", collider.gameObject );
				}
				break;
			case DetectorType.ALL:
				if(collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("enemy")){
					Debug.Log ("Combatant Left");
					callbackObj.SendMessage("combatantLeave", collider.gameObject );
				}
				break;
			}
		}
	}
	
}
