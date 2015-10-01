using UnityEngine;
using System.Collections;

public class ShootAtTarget : AIEvent {

	public float shotDelay;
	bool readyToShoot = true;
	public float speedMod = 1f;
	Vector3 currentTarget;
	Projectile projectile;
	public FireMethod fireMethod;
	public float spread;
	
	protected override void OnStartAction ()
	{
		currentTarget = currentStateMachine.enemy.currentTarget.transform.position;
		projectile = currentStateMachine.enemy.projectile1;
		Debug.Log ("StartAction Set");
		if(fireMethod == null){
			Debug.LogError("No FireMode attached");
		}
	}
	
	protected override void OnActionEvent ()
	{
		Debug.Log ("ActionEvent Running");
		if(readyToShoot){
			fireMethod.fire (projectile, transform.position, this.currentStateMachine.enemy, spread);
			disableShooting();
			Invoke("enableShooting", shotDelay);
			Exit();
		}
	}
	
	protected override void OnExit ()
	{
		base.OnExit ();
	}
	
	
	public void shootTarget(Projectile projectile, Vector3 target){
		
	}
	
	void enableShooting(){
		readyToShoot = true;
	}
	
	void disableShooting(){
		readyToShoot = false;
	}

	
}
