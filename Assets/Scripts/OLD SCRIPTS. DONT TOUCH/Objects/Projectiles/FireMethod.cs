using UnityEngine;
using System.Collections;

public abstract class FireMethod : MonoBehaviour {

	
	public abstract void fire(Projectile proj, Vector3 spawnPos, Combatant currentCombatant, float spread);
		
	
}
