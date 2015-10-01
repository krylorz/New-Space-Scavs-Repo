using UnityEngine;
using System.Collections;
using System.Timers;

public class CurrentLevelVars : MonoBehaviour {

	public string myLevel;
	private bool canDo;
	// Use this for initialization

	public Timer myTimer;
	void Start () {
		myTimer = new Timer (1000);
		myTimer.AutoReset = false;
		myTimer.Elapsed += (object sender, ElapsedEventArgs e) => 
		{
			canDo = true;
		};
		canDo = false;
		myTimer.Start ();

	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.P)) {

			if (canDo) {

				LevelController.NextLevel (myLevel);
				//temp
			}
		}
	}
}
