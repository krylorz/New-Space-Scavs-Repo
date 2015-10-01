using UnityEngine;
using System.Collections;

public class Xbox_Controls : MonoBehaviour {

    /*
     * Created by Nick Joebgen and Kevin Wolski - 2015
     * Player Controls is a template to use for your player character with Xbox Controls
	 * For use with the included InputManager.asset file
     * All subclasses inherit from this class. 
     * Write all player actions in this script.
     * 
	 *	
	 *
     * DO NOT ATTACH THIS SCRIPT TO ANY GAMEOBJECT
     * Keep it in the scripts section of your project
     * For each player you want controller support for attach the player#_controls script to the player.
     */
	
	/*
	private static Player_Controls instance;
	public static Player_Controls Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<Player_Controls>();
				if (instance == null) {
					GameObject obj = new GameObject();
					obj.hideFlags = HideFlags.HideAndDontSave;
					instance = obj.AddComponent<Player_Controls>();
				}
			}
			return instance;
		}
	}
	*/

    //Xbox Inputs
	public static bool A;
	public static bool B;
	public static bool X;
	public static bool Y;
	public static bool RB;
	public static bool LB;
	
	public static bool StartButton;
	public static bool StartButtonMenu;
	public static bool BackButton;
	public static bool LS;
	public static bool RS;

	public static bool L_Up;
	public static bool L_Down;
	public static bool L_Left;
	public static bool L_Right;
	public static bool anyButton;
	public static float L_XAxis;
	public static float L_YAxis;
	public static float R_XAxis;
	public static float R_YAxis;
	public static float DPAD_X;
	public static float DPAD_Y;
	public static float RT;
	public static float LT;


    public static float deadZone = 0.05f;
    public static Vector2 radialStickInput;
	

    //Initialization for in-object variables
    protected virtual void Awake()
    {
        radialStickInput = new Vector2();
    }


    //Initialization for things dependant on other GameObjects
	protected virtual void Start () 
	{
		
		
	}

    
	protected virtual void Update () 
	{
		
		//This will handle all Input, Actions based on Button Inputs, and Actions based on Stick
        XBoxInput();            //Input Retrieval
		XboxButtonActions();    //Actions based on Button inputs
		XBoxMovement();         //Actions based on "Stick" inputs
		
	}
	
	//Handles Input Retrieval for up to 4 controllers
	protected virtual void XBoxInput()
	{
		//Defined in Subclasses
	}
	
    //All actions based on button inputs should be done in here. This will get called every update
    //If you do not want debug logs you can safely remove them
	protected virtual void XboxButtonActions()
	{
		//A
		/*if (A)
		{
			Debug.Log("A: " + A);
		}
		
        //B
		if (B)
		{
			Debug.Log("B: " + B);
		}
		
		//X
		if (X)
		{
			Debug.Log("X: " + X);
		}
		
		//Y
		if (Y)
		{
			Debug.Log("Y: " + Y);
			
		}
		
        //Left Bumper
		if (LB)
		{
			Debug.Log("Left Bumper: " + LB);
			
		}
		
        //Right Bumper
		if (RB)
		{
			Debug.Log("Right Bumper: " + RB);
			
		}
		
        //Back Button
		if (BackButton)
		{
			Debug.Log("Back: " + BackButton);
			
		}
		
        //Start Button
		if (StartButton)
		{
			Debug.Log("Start: " + StartButton);
			
		}
		
        //Left Stick Click
		if (LS)
		{
			Debug.Log("Left Stick Down: " + LS); 
		}
		
        //Right Stick Click
		if (RS)
		{
			Debug.Log("Right Stick Down: " + RS);
		}*/
	}

    //All actions based on "joysticks" should be done in here. This will get called every update
    //This includes Right and Left Triggers, DPad, and Stick Movement
    //If you do not want debug logs you can safely remove them
	protected virtual void XBoxMovement()
	{
		//left stick left/right
		/*if (L_XAxis < 0) // Left Stick Left
		{
            Debug.Log("L_XAxis < 0 Left: " + L_XAxis);
		}
		else if (L_XAxis > 0) // Left Stick Right
		{
            Debug.Log("L_XAxis > 0 Right: " + L_XAxis);
		}

        //left stick up/down
		if (L_YAxis < 0) // Left Stick Up
		{
            Debug.Log("L_YAxis < 0 Up: " + L_YAxis); //This will be negative (it's wierd I know. Just accept it.)
			
		}
		else if (L_YAxis > 0)// Left Stick Down
		{
            Debug.Log("L_YAxis > 0 Down" + L_YAxis); //This will be positive (it's wierd I know. Just accept it.)
		}



        //right stick up/down
		if (R_YAxis > 0)	// Down on Right Stick
		{
            Debug.Log("R_YAxis > 0 Down: " + R_YAxis); //This will be positive (it's wierd I know. Just accept it.)
			
		}
		else if (R_YAxis < 0) // Up on Right Stick
		{
            Debug.Log("R_YAxis < 0 Up: " + R_YAxis); //This will be negative (it's wierd I know. Just accept it.)
			
		}


        //right stick left/right
		if (R_XAxis > 0) //Right on Right Stick
		{
            Debug.Log("R_XAxis > 0 Right: " + R_XAxis); 
			
		}
		else if (R_XAxis < 0) //Left on Right Stick
		{
            Debug.Log("R_XAxis < 0 Left: " + R_XAxis); 
			
		}
		

        //Dpad Left/Right.
		if (DPAD_X > 0) //Right on D Pad
		{
            Debug.Log("DPAD_X > 0 Right: " + DPAD_X); 
		}
		else if(DPAD_X < 0) //Left on D Pad
		{
            Debug.Log("DPAD_X < 0 Left: " + DPAD_X); 
		}

        //Dpad Up/Down.
        if (DPAD_Y > 0) //Up on D Pad
        {
            Debug.Log("DPAD_Y > 0 Up: " + DPAD_Y);
        }
        else if (DPAD_Y < 0) //Down on D Pad
        {
            Debug.Log("DPAD_Y < 0 Down: " + DPAD_Y);
        }



        //Left and Right Triggers
		if (LT > 0 && RT > 0) //If both triggers pressed
		{
            Debug.Log("Both Triggers Down, (LT: " + LT + " // RT: "+ RT);
		}
		else
		{
			if(RT > 0) //Right Trigger Pressed
			{
                Debug.Log("Right Trigger: " + RT);
			}
			if(LT > 0)	//Left Trigger Pressed
			{
                Debug.Log("Left Trigger: " + LT);
			}
		}*/
	}
	
	
	
	
}


