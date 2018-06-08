using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 camera = Camera.main.transform.position;
		transform.LookAt (Camera.main.transform);
	}
}
