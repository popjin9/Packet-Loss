using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayText : MonoBehaviour {

	public float charSpeed = 0.05f;

	public Text info;
	public Renderer infoRenderer;
	public Collider infoCollider;
	public bool accessDenied = false;

	public Material displayBlue;
	public Material displayRed;

	[Multiline]
	public string textToDisplay;

	public Transform mainCamera;

	private Vector3 moduleDir;
	private float playerModuleAngle;
	public float threshold = 30;

	private bool prompted = false;

	// Use this for initialization
	void Start () {
		infoCollider.enabled = accessDenied;

		if (accessDenied == true) {
			infoRenderer.material = displayRed;
		}
	}

	// Update is called once per frame
	void Update () {
		moduleDir = transform.position - mainCamera.position;
		playerModuleAngle = Vector3.Angle (moduleDir, mainCamera.forward);

		if (playerModuleAngle < threshold){
			if (prompted == false) {
				textStart ();
				prompted = true;
			}
		}
	}

	public void textStart(){
		StopAllCoroutines ();
		StartCoroutine ("displayInfo");
	}

	IEnumerator displayInfo(){
		string prompt = textToDisplay + "\n";
		info.text = "";

		foreach(char character in prompt){
			info.text += character;
			yield return new WaitForSeconds (charSpeed);
		}
	}

}

