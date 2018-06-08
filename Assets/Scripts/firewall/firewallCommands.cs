using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firewallCommands : MonoBehaviour {

	public Renderer firewallRenderer;
	public Transform camera;

	public firewallPingControl firewallPingControl;
	public firewallPortControl firewallPortControl;
	private bool prompted;

	private Vector3 firewallDir;
	private float playerFirewallAngle;
	public float threshold = 30;
	//int i = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		firewallDir = transform.position - camera.position;
		playerFirewallAngle = Vector3.Angle (firewallDir, camera.forward);

		if (playerFirewallAngle < threshold){
			//i += 1;
			//Debug.Log (i);

			//Ping Control
			if (prompted == false) {
				firewallPingControl.promptPing ();
				prompted = true;
			}

			if (Input.GetKeyDown (KeyCode.E) && prompted == true) {
				firewallPingControl.pingResponse ();
			}

			//Portscan
			if (Input.GetKeyDown (KeyCode.N)) {
				firewallPortControl.nmap ();
			}

			//SSH Connect
			if (Input.GetKeyDown (KeyCode.C)) {
				firewallPortControl.s_client ();
			}


		}
	}
}
