/* 
	Justin Lou z5218709
	31/03/18
	Player Movement
	Moves the player (A cube)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public float moveSpeed;
	private Vector3 input;

	private Camera mainCam;
	private float mainCamRotY;
	private Vector3 mainCamRot;

	// Use this for initialization
	void Start () {
		//moveSpeed = 0.5f;
		mainCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		input = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		transform.Translate (input * moveSpeed);


		mainCamRotY = mainCam.transform.eulerAngles.y;
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, mainCamRotY, transform.eulerAngles.z);
		print (mainCamRotY);


		//mainCamRot = mainCam.transform.rotation;
	}
}
