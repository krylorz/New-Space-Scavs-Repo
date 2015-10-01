using UnityEngine;
using System.Collections;

public class PassiveFactory : MonoBehaviour {

	IPassive[] passives;
	
	//Singleton
	private static PassiveFactory instance;
	public static PassiveFactory Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<PassiveFactory> ();
				if (instance == null) {
					GameObject obj = new GameObject ();
					obj.hideFlags = HideFlags.HideAndDontSave;
					instance = obj.AddComponent<PassiveFactory> ();
				}
			}
			return instance;
		}
	}
	
	void Awake(){
		passives = Transform.FindObjectsOfType<Passive>() as IPassive[];
	}
	
	
	

	public IPassive getPassive(string passiveName){
		IPassive temp = null;
		foreach(IPassive passive in passives){
			if(passive.getName() == passiveName){
				temp = passive;
			}
		}
		if(temp == null){Debug.LogError("No passive found of name: " + passiveName);}
		return temp;
	}
}
