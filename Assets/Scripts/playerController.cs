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

	// Use this for initialization
	void Start () {
		//moveSpeed = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		input = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		transform.Translate (input * moveSpeed);
	}
}
