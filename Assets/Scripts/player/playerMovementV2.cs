using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementV2 : MonoBehaviour {

	public float moveSpeed;
	private Vector3 movementInput;
	private Rigidbody rb;

	private Camera mainCam;
	private float mainCamRotY;
	private Vector3 mainCamRot;

	void Start () {
		rb = GetComponent<Rigidbody>();

		mainCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		movementInput = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		rb.AddRelativeForce (movementInput * moveSpeed *Time.deltaTime, ForceMode.Acceleration);

		mainCamRotY = mainCam.transform.eulerAngles.y;
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, mainCamRotY, transform.eulerAngles.z);
		//print (mainCamRotY)
	}
}
