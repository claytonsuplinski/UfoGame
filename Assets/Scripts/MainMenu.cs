using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject theGame;
	
	void OnGUI () {
		if (GUI.Button (new Rect (512, 512, 100, 30), "Start")) {
			// This code is executed when the Button is clicked
			//mainMenu.SetActive(false);
			theGame.SetActive(true);
		}
	}
	
}