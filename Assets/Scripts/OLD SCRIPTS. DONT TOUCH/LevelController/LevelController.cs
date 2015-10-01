using UnityEngine;
using System.Collections;
using System.Timers;

public class LevelController : MonoBehaviour {

	private static Timer myTimer;
	private static bool timerActive;
	public static string[] Levels = 
	{
		"Level_Test_Menus",
		"Level_Test_SpaceStation1",
		"Level_Test_Playground",

	};




	// Use this for initialization
	void Start () {
		if (myTimer == null) {
			myTimer = new Timer (1000);
			myTimer.AutoReset = false;
			myTimer.Elapsed += (object sender, ElapsedEventArgs e) => 
			{
				timerActive = false;
			};
			timerActive = false;
		}


	
	}


	public static void NextLevel(string currentLevel)
	{
		if (!timerActive) {
			int count = 0;
			foreach (string level in Levels) {
				if (level == currentLevel) {
					count++;
					if (count >= Levels.Length) {
						count = 0;
					}
					timerActive = true;
					Application.LoadLevel (count);
					myTimer.Start();
					break;
				}
				count++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
