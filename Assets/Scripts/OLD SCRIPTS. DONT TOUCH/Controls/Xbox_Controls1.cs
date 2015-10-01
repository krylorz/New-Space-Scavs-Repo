using UnityEngine;
using System.Collections;

public class Xbox_Controls1 : Xbox_Controls {

    /*
     * Created by Nick Joebgen and Kevin Wolski - 2015
     * Player Controls is a template to use for your player character with Xbox Controls
     * All subclasses inherit from this class. 
     * 
     * 
     * 
     * Attach this to Player 1
     * Make Sure Player_Controls is not attached to any GameObject but in your file structure somewhere
     * 
     * 
     * 
     * Any Unity Specific Functions (Such as Start or OnTriggerEnter) 
     * that appears in Player_Controls should be listed here with the template:
 
        protected override void FUNCTION_NAME (PARAMS GO HERE) 
	    {
		    base.FUNCTION_NAME (PARAM NAME);
	    }
     * 
     * Actual functionality should be done in Player Controls, unless you want Player specific actions. 
     * Please read up on Inheritance at http://unity3d.com/learn/tutorials/modules/intermediate/scripting/inheritance
     * 
     */

	

    protected override void Start () 
	{
		base.Start ();
	}

	protected override void Update () 
	{
		base.Update ();
	}

    //You can change this with the commands GetButton, GetButtonDown, GetButtonUp
    //Do not change GetAxis
	protected override void XBoxInput()
	{
		A = Input.GetButtonDown("A_1") ;
		B = Input.GetButtonDown("B_1") ;
		X = Input.GetButtonDown("X_1");
		Y = Input.GetButtonDown("Y_1") ;
		RB = Input.GetButton("RB_1");
		LB = Input.GetButton("LB_1") ;
		
		RS = Input.GetButton("RS_1");
		LS = Input.GetButton("LS_1");
		
		StartButton = Input.GetButtonDown("Start_1") ;
		BackButton = Input.GetButton("Back_1") ;
		
		

        radialStickInput.x = Input.GetAxis("L_XAxis_1");
        radialStickInput.y = Input.GetAxis("L_YAxis_1");
        if (radialStickInput.magnitude < deadZone) {
            radialStickInput = Vector2.zero;
        }
        L_Left = false;
        L_Right = false;
        if (radialStickInput.x > 0 ) {
            L_Right = true;
        }
        else if (radialStickInput.x < 0 ) {
            L_Left = true;
        }
        L_Up = false;
        L_Down = false;
        if (radialStickInput.y < 0 ) {
            L_Up = true;
        }
        else if (radialStickInput.y > 0 ) {
            L_Down = true;
        }
		
		L_XAxis = Input.GetAxisRaw("L_XAxis_1");
		L_YAxis = Input.GetAxisRaw("L_YAxis_1");
		R_XAxis = Input.GetAxisRaw("R_XAxis_1");
		R_YAxis = Input.GetAxisRaw("R_YAxis_1");
		DPAD_X = Input.GetAxisRaw("DPad_XAxis_1");
		DPAD_Y = Input.GetAxisRaw("DPad_YAxis_1");
		
		RT = Input.GetAxisRaw("RT_1");
		LT = Input.GetAxisRaw("LT_1");
		
		anyButton = A || B || X || Y || StartButton || BackButton || LT>0 || RT>0 || LB || RB;
	}
	
	
	
	
	
}
