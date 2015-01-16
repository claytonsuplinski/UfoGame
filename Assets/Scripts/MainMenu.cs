using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject theGame;
	public GameObject title;
	public GUITexture startButton;
	public GUITexture helpButton;
	public GUITexture helpText;
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (startButton.HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0)) {
			mainMenu.SetActive(false);
			title.SetActive(false);
			theGame.SetActive(true);
		}


		if (helpButton.HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0)) {
			helpText.gameObject.SetActive(true);
			startButton.gameObject.SetActive(false);
			helpButton.gameObject.SetActive(false);
			title.SetActive(false);
		}

	}
	
}