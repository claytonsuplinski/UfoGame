using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public GUIText countText;
	public GUIText timerText;
	public GameObject mainMenuText;
	public GameObject gameOverText;
	public GameObject ufoGame;
	public GameObject endUfoGame;
	public AudioClip coinSound;
	public AudioClip gameOverSound;
	public GameObject ufo;
	public GameObject tractorBeam;
	public GameObject ufoLight;
	private int count;
	private int numPickups;
	private List<GameObject> collectedCoins = new List<GameObject>();
	private bool aPressed;
	private bool qPressed;
	private bool gameOverSoundPlayed = false;
	private float ufoMaxHeight = 200;
	private float timeLeft = 6;

	private GameObject scienceFestDemo;
	private GameObject holidayDemo;

	private Vector3 startingPosition = new Vector3(0,50,0);

	void Start(){
		count = 0;
		aPressed = false;
		SetCountText ();
		numPickups = GameObject.FindGameObjectsWithTag("Pickup").Length;

		rigidbody.transform.position = startingPosition;
		
		scienceFestDemo = GameObject.Find("ScienceFestDemo");
		holidayDemo = GameObject.Find("HolidayDemo");
		//holidayDemo.active = false;
	}

	void Update(){
	  if (!gameOverSoundPlayed) {
			aPressed = false;
			if (Input.GetKey ("a")) {
					aPressed = true;
			}
			qPressed = false;
			if (Input.GetKey ("q")) {
					qPressed = true;
			}		

			if (timeLeft > 0) {
					timeLeft -= Time.deltaTime;
			}
			if (timeLeft <= 0) {
					GameOver ();
			}
			UpdateTimerText ();
	  }
	}

	void FixedUpdate(){
	  if (!gameOverSoundPlayed) {
			float moveHorizontal = 0;
			if (Input.GetKey (KeyCode.RightArrow)) {
					moveHorizontal++;
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
					moveHorizontal--;
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
					rigidbody.velocity = rigidbody.velocity / 1.2f;
			}

			float forwardMag = 0;
			if (Input.GetKey ("w")) {
					forwardMag = 2;
			} else if (Input.GetKey ("s")) {
					forwardMag = -2;
			}

			Vector3 movement = new Vector3 (1, 0, 1);
			movement = forwardMag * ufo.transform.forward;
			transform.Rotate (transform.up, moveHorizontal);

			ufo.transform.Rotate (ufo.transform.up, moveHorizontal);

			this.audio.volume = (float)(rigidbody.velocity.magnitude / 90.0f) + 0.1f;
			this.audio.pitch = (float)(rigidbody.velocity.magnitude / 30.0f) + 1.0f;

			//Horizontal forces

			rigidbody.AddForce (movement * speed * Time.deltaTime, ForceMode.VelocityChange);

//		rigidbody.velocity = ufo.transform.forward * Mathf.sqrt(rigidbody.velocity.x*rigidbody.velocity.x
//		                                                   +rigidbody.velocity.z*rigidbody.velocity.z);

			//Vertical forces
			if (aPressed) {
					rigidbody.AddForce (new Vector3 (0, -50, 0));

			}

			if (qPressed && rigidbody.transform.position.y < ufoMaxHeight) {
					rigidbody.AddForce (new Vector3 (0, 50, 0));

			}

			if (rigidbody.transform.position.y > ufoMaxHeight) {
					rigidbody.transform.position = new Vector3 (rigidbody.transform.position.x, 
                                           ufoMaxHeight,
                                           rigidbody.transform.position.z);

			}

	  }
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Pickup") {
			collectedCoins.Add (other.gameObject);
			other.gameObject.SetActive(false);
			if(coinSound.isReadyToPlay){
			AudioSource.PlayClipAtPoint(coinSound, other.gameObject.transform.position);
			}
			count++;
			SetCountText ();

		}
	}

	void ToggleVisibility(Transform obj, bool state)
	{
		for (int i = 0; i < obj.GetChildCount(); i++)
		{
			if (obj.GetChild(i).guiTexture != null)
				obj.GetChild(i).guiTexture.enabled = state;
			if (obj.GetChild(i).guiText != null)
				obj.GetChild(i).guiText.enabled = state;
			if (obj.GetChild(i).GetChildCount() > 0)
			{
				ToggleVisibility(obj.GetChild(i), state);
			}
		}
	}

	void SetCountText(){
		countText.text = count.ToString ();
	}

	void UpdateTimerText(){
		if (timeLeft >= 10 || timeLeft == 0) {
			timerText.text = timeLeft.ToString ("F0");
		} else{
			timerText.text = timeLeft.ToString ("F1");
		}
	}

	void GameOver(){
		timeLeft = 0;
		transform.position = new Vector3 (0, 10, 0);
		ufo.transform.rotation = Quaternion.identity;
		if (!gameOverSoundPlayed) {
			AudioSource.PlayClipAtPoint (gameOverSound, transform.position);
			gameOverSoundPlayed = true;
			gameOverText.SetActive(true);
			ufoGame.SetActive(false);
			ufo.renderer.enabled = false;
			ufoLight.SetActive(false);
			tractorBeam.SetActive(false);
			endUfoGame.SetActive(true);
		}
	}
}
