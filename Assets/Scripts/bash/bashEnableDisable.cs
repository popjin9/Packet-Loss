/*
	Justin Lou
	9/06/18
	Bash Enable Disable
	Script to check keys to enable and disabled the bash as needded
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bashEnableDisable : MonoBehaviour {

	public GameObject bash;
	public bool enable;

	// Use this for initialization
	void Start () {
		enable = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.B)){
			if (enable == true) {
				enable = false;
			} else {
				enable = true;
			}

			if (enable == true) {
				bash.SetActive(true);
			} else {
				bash.SetActive (false);
			}
		}
	}
}
