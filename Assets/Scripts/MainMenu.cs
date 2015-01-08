using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject theGame;
	public GUITexture startButton;
	public GUITexture helpButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (startButton.HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0)) {
			mainMenu.SetActive(false);
			theGame.SetActive(true);
		}

		/*
		if (helpButton.HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0)) {
			helpScreen.SetActive(true);
		}
*/
	}
	
}