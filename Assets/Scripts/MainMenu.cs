using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	public GameObject gameSelectMenu;
	public GUITexture leftArrow;
	public GUITexture rightArrow;

	public GUIText highScoreEnvironment;
	
	///////////////////////////////////

	public GUITexture wisconsinSelect;
	public GUITexture iowaSelect;
	public GUITexture northDakotaSelect;
	public GUITexture kansasSelect;
	public GUITexture montanaSelect;
	public GUITexture wyomingSelect;
	public GUITexture southDakotaSelect;
	public GUITexture arkansasSelect;
	public GUITexture nebraskaSelect;
	public GUITexture oklahomaSelect;
	public GUITexture newMexicoSelect;

	public GUITexture texasSelect;
	public GUITexture pennsylvaniaSelect;
	public GUITexture alaskaSelect;
	
	///////////////////////////////////

	public GameObject wisconsin;
	public GameObject iowa;
	public GameObject northDakota;
	public GameObject kansas;
	public GameObject montana;
	public GameObject wyoming;
	public GameObject southDakota;
	public GameObject arkansas;
	public GameObject nebraska;
	public GameObject oklahoma;
	public GameObject newMexico;

	public GameObject texas;
	public GameObject pennsylvania;
	public GameObject alaska;
	
	///////////////////////////////////

	private bool mainMenuOn = true;
	private string selectedEnvironment = "";

	private Vector3 gameSelectLerpDest;
	private bool gameSelectLerping = false;
	private int currGameSelectFrame = 0;

	private List<GUITexture> stateButtons = new List<GUITexture>();
	private List<GameObject> stateEnvironments = new List<GameObject>();
	private List<string> stateNames = new List<string>();
		
	// Use this for initialization
	void Start () {

		//////////////////////////////

		stateButtons.Add (wisconsinSelect);	
		stateButtons.Add (iowaSelect);
		stateButtons.Add (northDakotaSelect);
		stateButtons.Add (kansasSelect);
		stateButtons.Add (montanaSelect);
		stateButtons.Add (wyomingSelect);
		stateButtons.Add (southDakotaSelect);
		stateButtons.Add (arkansasSelect);
		stateButtons.Add (nebraskaSelect);
		stateButtons.Add (oklahomaSelect);
		stateButtons.Add (newMexicoSelect);

		stateButtons.Add (texasSelect);
		stateButtons.Add (pennsylvaniaSelect);
		stateButtons.Add (alaskaSelect);

		//////////////////////////////

		stateEnvironments.Add (wisconsin);
		stateEnvironments.Add (iowa);
		stateEnvironments.Add (northDakota);
		stateEnvironments.Add (kansas);
		stateEnvironments.Add (montana);
		stateEnvironments.Add (wyoming);
		stateEnvironments.Add (southDakota);
		stateEnvironments.Add (arkansas);
		stateEnvironments.Add (nebraska);
		stateEnvironments.Add (oklahoma);
		stateEnvironments.Add (newMexico);

		stateEnvironments.Add (texas);
		stateEnvironments.Add (pennsylvania);
		stateEnvironments.Add (alaska);

		////////////////////////////////

		stateNames.Add ("Wisconsin");
		stateNames.Add ("Iowa");
		stateNames.Add ("North Dakota");
		stateNames.Add ("Kansas");
		stateNames.Add ("Montana");
		stateNames.Add ("Wyoming");
		stateNames.Add ("South Dakota");
		stateNames.Add ("Arkansas");
		stateNames.Add ("Nebraska");
		stateNames.Add ("Oklahoma");
		stateNames.Add ("New Mexico");

		stateNames.Add ("Texas");
		stateNames.Add ("Pennsylvania");
		stateNames.Add ("Alaska");
	}

	// Update is called once per frame
	void Update () {
		if (startButton.HitTest(Input.mousePosition) && Input.GetMouseButtonUp(0)) {
			//mainMenu.SetActive(false);
			title.SetActive(false);
			startButton.gameObject.SetActive(false);
			helpButton.gameObject.SetActive(false);
			leftArrow.gameObject.SetActive(true);
			rightArrow.gameObject.SetActive(true);
			missionsButton.SetActive(false);
			storeButton.SetActive(false);
			activateAllButtons();

			//mainMenuOrtho.SetActive(false);
			//theGame.SetActive(true);
		}


		if (helpButton.HitTest(Input.mousePosition) && Input.GetMouseButtonUp(0)) {
			helpText.gameObject.SetActive(true);
			startButton.gameObject.SetActive(false);
			helpButton.gameObject.SetActive(false);
			missionsButton.SetActive(false);
			storeButton.SetActive(false);
			title.SetActive(false);
		}

		if (!mainMenuOn) {
			if(currGameSelectFrame < 1){leftArrow.gameObject.SetActive(false);}
			else{leftArrow.gameObject.SetActive(true);}

			if(currGameSelectFrame > 11){rightArrow.gameObject.SetActive(false);}
			else{rightArrow.gameObject.SetActive(true);}

			if (leftArrow.HitTest (Input.mousePosition) && Input.GetMouseButtonDown (0) && !gameSelectLerping && currGameSelectFrame > 0) {
				gameSelectLerpDest = new Vector3(gameSelectMenu.transform.position.x+1, gameSelectMenu.transform.position.y, gameSelectMenu.transform.position.z);
				gameSelectLerping = true;
				currGameSelectFrame--;
			}
			if (rightArrow.HitTest (Input.mousePosition) && Input.GetMouseButtonDown (0) && !gameSelectLerping && currGameSelectFrame < 12) {
				gameSelectLerpDest = new Vector3(gameSelectMenu.transform.position.x-1, gameSelectMenu.transform.position.y, gameSelectMenu.transform.position.z);
				gameSelectLerping = true;
				currGameSelectFrame++;
			}

			if(gameSelectLerping){
				gameSelectMenu.transform.position = Vector3.Lerp(gameSelectMenu.transform.position, gameSelectLerpDest, 0.5f);
				if(gameSelectMenu.transform.position == gameSelectLerpDest){
					gameSelectLerping = false;
				}
			}

			for(int i=0; i<stateNames.Count; i++){
				if(stateButtons[i].HitTest (Input.mousePosition) && Input.GetMouseButtonDown (0)) {
					deactivateMainMenu();
					deactivateAllButtons ();
					deactivateAllEnvironments ();
					stateEnvironments[i].SetActive (true);
					theGame.SetActive (true);
					selectedEnvironment = stateNames[i];
				}
			}

			highScoreEnvironment.text = selectedEnvironment;
		}

	}

	void activateAllButtons(){
		for (int i=0; i<stateButtons.Count; i++) {
			stateButtons[i].gameObject.SetActive (true);
		}
		mainMenuOn = false;
	}

	void deactivateAllButtons(){
		for (int i=0; i<stateButtons.Count; i++) {
			stateButtons[i].gameObject.SetActive (false);
		}
	}

	void deactivateAllEnvironments(){
		for (int i=0; i<stateEnvironments.Count; i++) {
			stateEnvironments[i].SetActive (false);
		}
	}

	void deactivateMainMenu(){
		mainMenu.SetActive (false);
		mainMenuOrtho.SetActive (false);
		leftArrow.gameObject.SetActive (false);
		rightArrow.gameObject.SetActive (false);
	}
	
}