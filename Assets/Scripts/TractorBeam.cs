using UnityEngine;
using System.Collections;

public class TractorBeam : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float delX = (player.transform.position.x-transform.position.x);
		float delZ = (player.transform.position.z - transform.position.z);
		if (Mathf.Sqrt (delX * delX + delZ * delZ) < 10) {
			transform.Translate (Vector3.up * 1.0f);
		} else {
			float tmpHeight = Terrain.activeTerrain.SampleHeight(transform.position)
				+ Terrain.activeTerrain.transform.position.y;
			transform.Translate (Vector3.up * -1.0f);
			if(transform.position.y < tmpHeight){
				transform.position = new Vector3 (transform.position.x,
				                                  tmpHeight,
				                                  transform.position.z);
			}
		}
	}
}
