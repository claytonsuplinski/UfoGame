using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public GUIText countText;
	public GUIText winText;
	public AudioClip coinSound;
	public GameObject skis;
	public GameObject bronzeMedal;
	public GameObject silverMedal;
	public GameObject goldMedal;
	private int count;
	private int numPickups;
	private List<GameObject> collectedCoins = new List<GameObject>();
	private bool aPressed;
	private float ufoMaxHeight = 200;

	private GameObject scienceFestDemo;
	private GameObject holidayDemo;

	void Start(){
		count = 0;
		aPressed = false;
		SetCountText ();
		winText.text = "";
		numPickups = GameObject.FindGameObjectsWithTag("Pickup").Length;
		
		goldMedal.SetActive(false);
		silverMedal.SetActive(false);
		bronzeMedal.SetActive(false);
		
		scienceFestDemo = GameObject.Find("ScienceFestDemo");
		holidayDemo = GameObject.Find("HolidayDemo");
		//holidayDemo.active = false;
	}

	void Update(){
		if (Input.GetKeyDown ("r")) {
			//Application.LoadLevel ("MiniGame");
			this.transform.position = new Vector3 (0,0,0);
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;

			for(int i=0; i<count; i++){
				GameObject tmpPickup = collectedCoins[i] as GameObject;
				tmpPickup.SetActive(true);
			}
			
			count = 0;
			goldMedal.SetActive(false);
			silverMedal.SetActive(false);
			bronzeMedal.SetActive(false);
			
			SetCountText ();
			collectedCoins.Clear();
		} 

		aPressed = false;
		if (Input.GetKey ("a")) {
			aPressed = true;
		}
	}

	void FixedUpdate(){
		float moveHorizontal = 0;
		if (Input.GetKey (KeyCode.RightArrow)) {
			moveHorizontal++;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			moveHorizontal--;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			rigidbody.velocity = rigidbody.velocity/1.2f;
		}

		float forwardMag = 0;
		if (Input.GetKey ("w")) {
			forwardMag = 1;
		}

		Vector3 movement = new Vector3(1,0,1);
		movement = forwardMag*skis.transform.forward;
		transform.Rotate(transform.up, moveHorizontal);

		skis.transform.Rotate(skis.transform.up, moveHorizontal);

		this.audio.volume = (float)(rigidbody.velocity.magnitude / 90.0f) + 0.1f;
		this.audio.pitch = (float)(rigidbody.velocity.magnitude / 30.0f)+ 1.0f;

		//Horizontal forces

		rigidbody.AddForce (movement * speed * Time.deltaTime);

//		rigidbody.velocity = skis.transform.forward * Mathf.sqrt(rigidbody.velocity.x*rigidbody.velocity.x
//		                                                   +rigidbody.velocity.z*rigidbody.velocity.z);

		//Vertical forces
		if (aPressed && rigidbody.transform.position.y < ufoMaxHeight) {
			rigidbody.AddForce (new Vector3(0, 50, 0));
			
		}

		if (rigidbody.transform.position.y > ufoMaxHeight) {
			rigidbody.transform.position = new Vector3(rigidbody.transform.position.x, 
			                                           ufoMaxHeight,
			                                           rigidbody.transform.position.z);

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
		countText.text = "Count: " + count.ToString ();
	}
}
