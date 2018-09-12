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

	public InputField bash;
	public InputField fullBash;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void promptPing(){
		StopAllCoroutines ();
		StartCoroutine ("promptPingCoroutine");
		//prompted = true;
	}

	public void commandPing(bool bashFull){
		//bashType 1 is full, 0 is small
		if (bashFull == false) {
			bash.text += "\nPING localhost:22 (22) with \nOptions: 56(84) bytes of data:" +
				"\n--- PING statistics ---" +
				"\n 64 packets transmitted, 64 recieved, 0% packet loss, time 12ms" +
				"\n\nOptions:" +
				"\tPort Scan ('nmap')" +
				"\tSSL Connection ('s_client')\n";
		}
	}

	public void pingResponse(){
		StopAllCoroutines ();
		StartCoroutine ("pingResponseCoroutine");
	}

	IEnumerator promptPingCoroutine(){
		string prompt = "Use 'help' or 'ping' for help";
		pingInfo.text = "";

		foreach(char character in prompt){
			pingInfo.text += character;
			yield return new WaitForSeconds (charSpeed);
		}
	}

	IEnumerator pingResponseCoroutine(){
		string prompt = firewallDescription + "\nOptions: \nPort Scan ('nmap')\nSSL Connection ('s_client')";
		pingInfo.text = "";

		foreach (char character in prompt) {
			pingInfo.text += character;
			yield return new WaitForSeconds (charSpeed);
		}
	}

}