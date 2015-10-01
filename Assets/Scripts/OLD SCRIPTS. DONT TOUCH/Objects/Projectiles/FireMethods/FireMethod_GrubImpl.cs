using UnityEngine;
using System.Collections;

public class FireMethod_GrubImpl : FireMethod {

	public int projectileNumber;
	
	
	public override void fire( Projectile proj, Vector3 spawnPos, Combatant currentCombatant, float spread){
		for(int i = 0; i <  projectileNumber; i++){
			proj = Instantiate(proj, spawnPos, transform.rotation) as Projectile;
			if(transform.lossyScale.y < 0){
				proj.transform.localScale = new Vector3(proj.transform.localScale.x, proj.transform.localScale.y * -1, proj.transform.localScale.z);
				//proj.modifySpeed(-1);	
			}
			proj.setProjectile(transform.rotation, currentCombatant.getCollider(), currentCombatant.alignment);
			float randomAngle = Random.Range(0, spread);
			proj.modifyRotation(randomAngle);
			proj.move ();
		}
	}
}
