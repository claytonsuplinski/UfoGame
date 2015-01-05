using UnityEngine;
using System.Collections;

public class PenguinScript : MonoBehaviour {

	public GameObject penguin;
	bool change;
	float range;
	void Start () {
		range = 2f;
		//InvokeRepeating ("NewTarget",0.01f,2.0f);
	}
	void Update () {

	}

	void FixedUpdate(){
		penguin.transform.eulerAngles = new Vector3(penguin.transform.eulerAngles.x, 
		                                            penguin.transform.eulerAngles.y+Random.Range(-5f, 5f),
		                                            penguin.transform.eulerAngles.z);

		//rigidbody.AddForce (Vector3.forward);
		penguin.transform.Translate (Vector3.forward * 0.2f);

		//turn penguin around if outside of boundary
		if(penguin.transform.position.z < 4550 ||
		   penguin.transform.position.z > 4950 ||
		   penguin.transform.position.x < -260 ||
		   penguin.transform.position.x > 260){ 
			penguin.transform.eulerAngles = new Vector3(penguin.transform.eulerAngles.x, 
			                                            penguin.transform.eulerAngles.y+180,
			                                            penguin.transform.eulerAngles.z);
			penguin.transform.Translate (Vector3.forward * 0.3f);
		}

		float tmpHeight = Terrain.activeTerrain.SampleHeight(penguin.transform.position)
			+ Terrain.activeTerrain.transform.position.y;
		penguin.transform.position = new Vector3 (penguin.transform.position.x,
		                                          tmpHeight,
		                                          penguin.transform.position.z);

		
//		Vector3 movement = new Vector3 (0.0f, 0.0f, 1.0f);
//		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

}
