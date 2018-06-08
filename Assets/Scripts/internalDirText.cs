using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class internalDirText : MonoBehaviour {

	private float charSpeed = 0.05f;

	public Text dirInfo;
	public Renderer dirRenderer;

	public string areaInfo;

	public Transform camera;

	private Vector3 moduleDir;
	private float playerModuleAngle;
	public float threshold = 30;

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
				dirTextStart ();
				prompted = true;
			}
		}
	}

	public void dirTextStart(){
		StopAllCoroutines ();
		StartCoroutine ("displayDirInfo");
	}

	IEnumerator displayDirInfo(){
		string prompt = "Module:\n" + areaInfo + "\n";
		dirInfo.text = "";

		foreach(char character in prompt){
			dirInfo.text += character;
			yield return new WaitForSeconds (charSpeed);
		}
	}

}

