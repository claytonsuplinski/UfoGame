using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject theGame;
	public GameObject title;
	public GUITexture startButton;
	public GUITexture helpButton;
	public GUITexture helpText;
	public GameObject mainMenuOrtho;
	public GameObject missionsButton;
	public GameObject storeButton;

	public GUITexture wisconsinSelect;
	public GUITexture texasSelect;
	public GUITexture pennsylvaniaSelect;
	public GUITexture alaskaSelect;

	public GameObject wisconsin;
	public GameObject texas;
	public GameObject pennsylvania;
	public GameObject alaska;
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (startButton.HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0)) {
			//mainMenu.SetActive(false);
			title.SetActive(false);
			startButton.gameObject.SetActive(false);
			helpButton.gameObject.SetActive(false);
			missionsButton.SetActive(false);
			storeButton.SetActive(false);
			activateAllButtons();

			//mainMenuOrtho.SetActive(false);
			//theGame.SetActive(true);
		}


		if (helpButton.HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0)) {
			helpText.gameObject.SetActive(true);
			startButton.gameObject.SetActive(false);
			helpButton.gameObject.SetActive(false);
			missionsButton.SetActive(false);
			storeButton.SetActive(false);
			title.SetActive(false);
		}

		if (wisconsinSelect.HitTest (Input.mousePosition) && Input.GetMouseButtonDown (0)) {
			mainMenu.SetActive(false);
			mainMenuOrtho.SetActive(false);
			deactivateAllButtons();
			deactivateAllEnvironments();
			wisconsin.SetActive(true);
			theGame.SetActive(true);
		}

		if (texasSelect.HitTest (Input.mousePosition) && Input.GetMouseButtonDown (0)) {
			mainMenu.SetActive(false);
			mainMenuOrtho.SetActive(false);
			deactivateAllButtons();
			deactivateAllEnvironments();
			texas.SetActive(true);
			theGame.SetActive(true);
		}

		if (pennsylvaniaSelect.HitTest (Input.mousePosition) && Input.GetMouseButtonDown (0)) {
			mainMenu.SetActive(false);
			mainMenuOrtho.SetActive(false);
			deactivateAllButtons();
			deactivateAllEnvironments();
			pennsylvania.SetActive(true);
			theGame.SetActive(true);
		}

		if (alaskaSelect.HitTest (Input.mousePosition) && Input.GetMouseButtonDown (0)) {
			mainMenu.SetActive(false);
			mainMenuOrtho.SetActive(false);
			deactivateAllButtons();
			deactivateAllEnvironments();
			alaska.SetActive(true);
			theGame.SetActive(true);
		}

	}

	void activateAllButtons(){
		wisconsinSelect.gameObject.SetActive(true);
		texasSelect.gameObject.SetActive(true);
		pennsylvaniaSelect.gameObject.SetActive(true);
		alaskaSelect.gameObject.SetActive(true);
	}

	void deactivateAllButtons(){
		wisconsinSelect.gameObject.SetActive(false);
		texasSelect.gameObject.SetActive(false);
		pennsylvaniaSelect.gameObject.SetActive(false);
		alaskaSelect.gameObject.SetActive(false);
	}

	void deactivateAllEnvironments(){
		wisconsin.SetActive (false);
		texas.SetActive (false);
		pennsylvania.SetActive (false);
		alaska.SetActive (false);
	}
}