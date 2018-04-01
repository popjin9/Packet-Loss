using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Vector3 cameraOffset;
	public GameObject player;

	void Start () {
		cameraOffset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + cameraOffset;
		
	}
}
