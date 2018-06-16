using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firewallCommands : MonoBehaviour {

	public Renderer firewallRenderer;
	public Transform camera;

	public firewallPingControl firewallPingControl;
	public firewallPortControl firewallPortControl;
	private bool prompted;
	public bool keyDisabled;

	private Vector3 firewallDir;
	private float playerFirewallAngle;
	public float threshold = 30;

	public GameObject bash;
	public GameObject fullBash;
	string command;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		firewallDir = transform.position - camera.position;
		playerFirewallAngle = Vector3.Angle (firewallDir, camera.forward);

		if (playerFirewallAngle < threshold){
			//Check console commands
			command = bash.GetComponent<bashControl> ().command;
			if (command == "ping"){
				firewallPingControl.pingResponse ();
				firewallPingControl.commandPing (false);
			} else if (command == "nmap"){
				firewallPortControl.nmap ();
				firewallPortControl.commandNmap (false);
			} else if (command == "s_client"){
				firewallPortControl.s_client ();
				firewallPortControl.commandSclient (false);
			}

			//Ping Control
			if (prompted == false) {
				firewallPingControl.promptPing ();
				prompted = true;
			}

			if (Input.GetKeyDown (KeyCode.E) && prompted == true && keyDisabled == false) {//Ping
				firewallPingControl.pingResponse ();
			} else if (Input.GetKeyDown (KeyCode.N) && keyDisabled == false) {//Portscan
				firewallPortControl.nmap ();
			} else if (Input.GetKeyDown (KeyCode.C) && keyDisabled == false) {//SSL Connect
				firewallPortControl.s_client ();
			}


		}
	}
}
