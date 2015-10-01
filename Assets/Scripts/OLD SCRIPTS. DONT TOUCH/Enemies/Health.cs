using UnityEngine;
using System.Collections;

public enum HealthType{Combatant, PhysicsObj};


public class Health : MonoBehaviour {
	
	public HealthType healthType;
	public int maxHealth;
	int health;
	bool dead;
	
	
	void Awake(){
		health = maxHealth;
		dead = health <= 0;
	}
	
	public bool isDead(){
		return dead;
	}
	
	
	public bool takeDamage(int healthlost){
		health -= healthlost;
		if(health <= 0){
			health = 0;
			dead = true;
			//TODO: broadcast message for generic dead function
		}
		FlashRed();
		return dead;
	}
	
	public void increaseHealth(int healthIncrease){
		health += healthIncrease;
		if(health > maxHealth){
			health = maxHealth;
		}
	}
	
	public bool hasMaxHealth(){
		return health == maxHealth;
	}
	
	public int currentHealth(){
		return health;
	}
	
	void Update(){
		if(isDead()){
			GameObject.Destroy(this.gameObject);
		}
	}
	
	
	void FlashRed() {
		this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,0,0,1);
		Invoke("BackToNormal",.3f);
	}
	
	void BackToNormal() {
		this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
	}
	
		
}
