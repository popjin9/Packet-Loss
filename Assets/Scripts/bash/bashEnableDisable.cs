/*
	Justin Lou
	9/06/18
	Bash Enable Disable
	Script to check keys to enable and disabled the bash as needed
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bashEnableDisable : MonoBehaviour {

	public GameObject player;
	public GameObject bash;
	public bool enable;

	// Use this for initialization
	void Start () {
		enable = false;
		bash.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.BackQuote) && !Input.GetKey (KeyCode.LeftShift)) {
			if (enable == true) {
				enable = false;
				bash.SetActive (false);
			} else {
				enable = true;
				bash.SetActive (true);
			}
		}
	}
}
