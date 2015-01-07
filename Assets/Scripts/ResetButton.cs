using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour {

	public GUITexture resetButton;
	public GameObject startingScreen;
	public GameObject ufoGame;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (resetButton.HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0)) {
			ufoGame.SetActive(false);
			startingScreen.SetActive(true);
		}
	}
}
