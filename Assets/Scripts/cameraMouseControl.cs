/*
	Justin Lou z5218709
	2/04/18
	Camera Mouse Control
	Script to allow the player to rotate the camera with their mouse
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMouseControl : MonoBehaviour {

	public Transform target; //Where the camera will point to
	//public Transform camTransform; //Camera's transform

	//private Camera cam; //Target camera (self)
	private float distanceFromTarget = 8; 
	private float mouseX = 0f;
	private float mouseY = 0f;
	public float sensitivity = 3f;


	void Update () {
		mouseX += Input.GetAxis("Mouse X") * sensitivity;
		mouseY += Input.GetAxis("Mouse Y") * sensitivity;

		if (mouseY <= 2f) {
			mouseY = 2f;
		}

		if (mouseY >= 50f) {
			mouseY = 50f;
		}

		//distanceFromTarget = mouseY / 50f * 8f;//Zoom in effect as the camera pans down (WIP)
	}

	void LateUpdate () {
		Vector3 dir = new Vector3 (0, 0, -distanceFromTarget);
		Quaternion rotation = Quaternion.Euler (mouseY, mouseX, 0);

		transform.position = target.position + rotation * dir;
		transform.LookAt (target);
	}
}
