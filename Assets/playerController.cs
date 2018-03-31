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
	public string playerMoveUp;
	public string playerMoveLeft;
	public string playerMoveDown;
	public string playerMoveRight;

	// Use this for initialization
	void Start () {
		moveSpeed = 0.5;
		playerMoveUp = "w";
		playerMoveLeft = "a";
		playerMoveDown = "s";
		playerMoveRight = "d";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (playerMoveUp) || Input.GetKey ("up")) {
			transform.Translate (0, 0, moveSpeed);
		}

		if (Input.GetKey (playerMoveLeft) || Input.GetKey ("down")) {
			transform.Translate(moveSpeed, 0, 0);
		}

		if (Input.GetKey (playerMoveDown) || Input.GetKey ("down")) {
			transform.Translate(0, 0, -moveSpeed);
		}

		if (Input.GetKey (playerMoveRight) || Input.GetKey ("down")) {
			transform.Translate(-moveSpeed, 0, 0);
		}

	}
}
