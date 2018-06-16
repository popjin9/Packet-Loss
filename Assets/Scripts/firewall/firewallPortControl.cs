/*
    Justin Lou
    4/05/18
    Firewall Port Control
	Checks if the player can pass through the firewall
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firewallPortControl : MonoBehaviour {

	public GameObject player;
	public List<int> playerUnlockedPorts;

	public List<int> openPorts;
	public List<int> matchedPorts;

	public bool solid;
	public Collider firewallCollider;

	public firewallMaterialChange firewallMaterialChange;

	//Text
	public Text pingInfo;
	public Renderer firewallRenderer;
	private float charSpeed = 0.05f;

	public InputField bash;
	public InputField fullBash;

	void Start () {
		playerUnlockedPorts = player.GetComponent<playerPortControl> ().playerUnlockedPorts;
		firewallSolid (true);
	}

	void Update () {
		
	}

	public void commandNmap(bool bashFull){
		//bashType 1 is full, 0 is small
		if (bashFull == false) {
			bash.text += "Starting Nmap 7.12 ( https://nmap.org )" +
			"\nNmap Scan Report for localhost" +
			"\nHost is up (0.0000020s latency)." +
			"\nNot shown: 1112 closed ports" +
			"\nPORT\tSTATE\tCONNECT\n";

			foreach (int openPort in openPorts) {
				bash.text += (openPort + "\t\topen\t\tUnknown\n");
			}

			bash.text += "\nNmap done: 1 ip address (1 host up) scanned in 0.11 seconds\n";
		}
	}

	public void nmap(){
		string prompt = "";
		prompt = "nmap: Network Scan Report\nPORT\tSTATE\t\tCONNECT\n";

		foreach (int openPort in openPorts) {
			prompt += (openPort + "\topen\tUnknown\n");
		}

		StopAllCoroutines ();
		StartCoroutine ("nmapPrint", prompt);
	}

	IEnumerator nmapPrint(string prompt){
		pingInfo.text = "";

		foreach (char character in prompt) {
			pingInfo.text += character;
			yield return new WaitForSeconds (charSpeed);
		}
	}

	public void commandSclient(bool bashFull){
		playerUnlockedPorts = player.GetComponent<playerPortControl> ().playerUnlockedPorts;
		solid = checkPorts (openPorts, playerUnlockedPorts);
		firewallSolid (solid);

		//bashType 1 is full, 0 is small
		if (bashFull == false) {
			if (solid == false) {
				bash.text += "\nConnection Successful (00003)\n\n";
			} else if (solid == true) {
				bash.text += "\nError: Unable to connect\n\n";
			}
		}
	}

	public void s_client(){
		playerUnlockedPorts = player.GetComponent<playerPortControl> ().playerUnlockedPorts;
		solid = checkPorts (openPorts, playerUnlockedPorts);
		firewallSolid (solid);

		if (solid == false) {
			string prompt = "SSL Connection Successful!";

			StopAllCoroutines ();
			StartCoroutine ("s_clientPrint", prompt);
		} else {
			string prompt = "Error 503: Unable to connect";

			StopAllCoroutines ();
			StartCoroutine ("s_clientPrint", prompt);
		}

	}

	IEnumerator s_clientPrint(string prompt){
		pingInfo.text = "";

		foreach (char character in prompt) {
			pingInfo.text += character;
			yield return new WaitForSeconds (charSpeed);
		}
	}

	//Checks ports, returns 1 if player can access port
	bool checkPorts (List<int> openPorts, List<int> playerUnlockedPorts){

		//List<int> matchedPorts;
		bool firewallBlocked = true;

		foreach(int openPort in openPorts){
			foreach(int unlockedPort in playerUnlockedPorts){
				if (openPort == unlockedPort && openPort != 0) {
					matchedPorts.Add (openPort);
					firewallBlocked = false;
				}
			}
		}

		return (firewallBlocked);
	}

	//Changes the firewall to be solid or not solid
	void firewallSolid (bool solid){
		firewallCollider.enabled = solid;
		firewallMaterialChange.blockFirewall (solid);
	}
}