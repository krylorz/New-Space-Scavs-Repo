using UnityEngine;
using System.Collections;

public enum WeaponType{PISTOL, SHOTGUN};

[RequireComponent (typeof (FireMethod))]
public class Weapon : Item, IWeapon {

	
	public float rangeModifier = 1;	//TODO
	public float damageModifier = 1;//TODO
	public float projectileSpeedModifier = 1;//TODO
	public float fireRate;//TODO
	public WeaponType weaponType;
	public Projectile projectile;//TODO
	public FireMethod firemethod;
	public float spread = 0;//TODO
	GameObject projectileBone;
	public GameObject muzzleFlashObject;
	bool cooldownDone = true;//TODO
	bool canFire = false;//TODO
	
	
	
	
	
	protected override void OnAwake ()
	{
		base.OnAwake();
		gameObject.tag = "weapon";
		gameObject.layer = LayerMask.NameToLayer("item_noproj");
		Transform temp = transform.FindChild("bone");
		if(temp != null){projectileBone = temp.gameObject;}
	}
	
	void muzzleFlash(){
		if(muzzleFlashObject != null && projectileBone != null){
			GameObject muzzleflash = Instantiate(muzzleFlashObject, projectileBone.transform.position, transform.rotation) as GameObject;
			muzzleflash.transform.parent = this.transform;
		}
	}
	
	
	public void fire(){
		if(canFire){
			if(cooldownDone){
				Vector3 spawnPos =  projectileBone.transform.position;
				if(spawnPos == null){spawnPos = transform.position;}
				firemethod.fire (projectile, spawnPos, CurrentCombatant, spread);
				cooldownDone = false;
				Invoke("fireRateCooldownDone", fireRate);
				muzzleFlash();
			}
		}
	}
	
	void fireRateCooldownDone(){
		cooldownDone = true;
	}
	
	protected override void onPickUp ()
	{
		enableWeapon();
	}
	
	protected override void onDrop ()
	{
		disableWeapon();
	}
	
	void setProjectile(Projectile proj){
		
		
		//Physics.IgnoreCollision(CurrentCombatant.getCollider(), proj.getCollider());
	}
	
	public void disableWeapon(){
		canFire = false;
	}
	
	public void enableWeapon(){
		canFire = true;
	}
	
	public bool isWeaponOfType(WeaponType type){
		return this.weaponType == type;
	}
	
	
}
