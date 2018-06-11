﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bashFullEnableDisable : MonoBehaviour {

	public GameObject bash;
	public bool enable;

	// Use this for initialization
	void Start () {
		enable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.BackQuote) && Input.GetKey (KeyCode.LeftShift)) {
			if (enable == true) {
				enable = false;
			} else {
				enable = true;
			}

			if (enable == true) {
				bash.SetActive (true);
			} else {
				bash.SetActive (false);
			}
		}
	}
}
