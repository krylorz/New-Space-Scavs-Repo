using UnityEngine;
using System.Collections;

public class Player_Controls : MonoBehaviour {
	
    //Game Inputs
    public bool jump;
	public bool weapon;
	public bool throwobj;
	public bool use;
	public bool equip;
	public bool interact;
	public bool ability;
    public bool menu;
    public bool inventory;
    public bool weaponswap;
    
    public float x_move;
    public float y_move;
    public float x_aim;
    public float y_aim;
    
    
    
     
	void Update () 
	{
		PlayerInputUpdate();
		
		
	}
	
	public string getName(){
		return gameObject.tag;
	}	
	
	protected virtual void PlayerInputUpdate(){
		
	}
		
	
	
	
	
	
}


