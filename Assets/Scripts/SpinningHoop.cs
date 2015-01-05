using UnityEngine;
using System.Collections;

public class SpinningHoop : MonoBehaviour {

	public GameObject hoop;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		hoop.transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);

	}
}
