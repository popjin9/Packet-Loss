/*
	Justin Lou
	28/05/18
	Firewall Ping Control
	Control the GUI when the firewall is pinged
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firewallPingControl : MonoBehaviour {

	private float charSpeed = 0.05f;

	public Text pingInfo;
	public Renderer firewallRenderer;

	public string firewallDescription;
	//private bool prompted;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (firewallRenderer.isVisible && prompted == false) {
			StartCoroutine ("promptPing");
			prompted = true;
		}

		if (Input.GetKeyDown (KeyCode.E) && prompted == true) {
			StartCoroutine ("pingResponse");
		}
		*/
	}

	public void promptPing(){
		StopAllCoroutines ();
		StartCoroutine ("promptPingCoroutine");
		//prompted = true;
	}

	public void pingResponse(){
		StopAllCoroutines ();
		StartCoroutine ("pingResponseCoroutine");
	}

	IEnumerator promptPingCoroutine(){
		string prompt = "'E' to ping";
		pingInfo.text = "";

		foreach(char character in prompt){
			pingInfo.text += character;
			yield return new WaitForSeconds (charSpeed);
		}
	}

	IEnumerator pingResponseCoroutine(){
		string prompt = firewallDescription + "\n\nOptions: \nnmap ('n')\ns_client ('c')";
		pingInfo.text = "";

		foreach (char character in prompt) {
			pingInfo.text += character;
			yield return new WaitForSeconds (charSpeed);
		}
	}

}