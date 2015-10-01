using UnityEngine;
using System.Collections;

public class Player_Controls1 : Player_Controls {

	
	
	
	protected override void PlayerInputUpdate ()
	{
		
		
		
		jump = Xbox_Controls1.A  || Xbox_Controls.LB || Input.GetKey(KeyCode.Space);
		equip = Xbox_Controls1.X || Input.GetKeyDown(KeyCode.E);
		weaponswap = Xbox_Controls1.Y || Input.GetKeyDown(KeyCode.Tab);
		use = Xbox_Controls1.B;
		weapon = Xbox_Controls1.RT > 0.4f;
		throwobj = Xbox_Controls1.LT > 0.4f;
		ability = Xbox_Controls1.RB;
		
		//Horizontal Movement
		float hkeyboard = Input.GetKey(KeyCode.A) ? -1.0f: 0;
		hkeyboard += Input.GetKey(KeyCode.D) ? 1.0f : 0;
		x_move = Xbox_Controls1.L_XAxis + hkeyboard;
		//Jump Down OneWay
		float vkeyboard = Input.GetKey(KeyCode.S) ? -1.0f: 0;
		if(Xbox_Controls1.L_YAxis > 0.95f && Xbox_Controls1.L_XAxis < 0.05f && Xbox_Controls1.L_XAxis > -0.05f)
			y_move = -1.0f;
		else
			y_move = 0;
		y_move = Mathf.Clamp(vkeyboard + y_move, -1.0f, 1.0f);
		
		//Aiming
		y_aim = Xbox_Controls1.R_YAxis;
		x_aim = Xbox_Controls1.R_XAxis;
	}
}
