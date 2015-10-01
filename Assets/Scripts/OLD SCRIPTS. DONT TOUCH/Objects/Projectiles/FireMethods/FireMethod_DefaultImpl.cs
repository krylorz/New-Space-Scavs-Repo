using UnityEngine;
using System.Collections;

public class FireMethod_DefaultImpl : FireMethod {

	public override void fire(Projectile proj, Vector3 spawnPos, Combatant currentCombatant, float spread){
		//Fire projectile
		
		proj = Instantiate(proj, spawnPos, transform.rotation) as Projectile;
		if(transform.lossyScale.y < 0){
			proj.transform.localScale = new Vector3(proj.transform.localScale.x, proj.transform.localScale.y * -1, proj.transform.localScale.z);
			//proj.modifySpeed(-1);	
		}
		proj.setProjectile(transform.rotation, currentCombatant.getCollider(), currentCombatant.alignment);
		float randomAngle = Random.Range(-spread, spread);
		proj.modifyRotation(randomAngle);
		proj.move();
	}
}
