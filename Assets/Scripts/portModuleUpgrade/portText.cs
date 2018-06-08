using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portText : MonoBehaviour {

	private float charSpeed = 0.05f;

	public Text portInfo;
	public Renderer moduleRenderer;

	public string protocolInfo;

	public Transform camera;

	private Vector3 moduleDir;
	private float playerModuleAngle;
	public float threshold = 10;

	private bool prompted = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		moduleDir = transform.position - camera.position;
		playerModuleAngle = Vector3.Angle (moduleDir, camera.forward);

		if (playerModuleAngle < threshold){
			if (prompted == false) {
				portTextStart ();
				prompted = true;
			}
		}
	}

	public void portTextStart(){
		StopAllCoroutines ();
		StartCoroutine ("displayPortInfo");
	}

	IEnumerator displayPortInfo(){
		string prompt = "New Connection Protocol\n" + protocolInfo + "\nInstall ready";
		portInfo.text = "";

		foreach(char character in prompt){
			portInfo.text += character;
			yield return new WaitForSeconds (charSpeed);
		}
	}

}

