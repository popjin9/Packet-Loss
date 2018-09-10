/*
	Justin Lou
	9/06/18
	Bash Control
	Script to control the visibility and behaviour of the in game bash shell
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bashControl : MonoBehaviour {

	public InputField bash;
	public Text bashText;
	string consoleLogBuffer;
	string startPrompt;
	public string command;
	//public Transform mainCameraTransform;
	//public Camera mainCamera;

	//RaycastHit raycastFirewall;
	GameObject activeFirewall;

	// Use this for initialization
	void Start () {
		startPrompt = " <color=lime>operator@TCP-PCK:</color><color=blue>/mnt/c</color>$ ";
		bash.text = startPrompt;
		consoleLogBuffer = bash.text;
		
	}

	// Update is called once per frame
	void Update () {

		//Reset console
		if (command != "") {
			//Reset console
			bash.text += "\n" + startPrompt;
			consoleLogBuffer = bash.text;
			command = "";
		}

		/*
		//Searches for active firewalls
		Vector3 cameraCenter = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, mainCamera.nearClipPlane));
		
		if (Physics.Raycast (cameraCenter, mainCameraTransform.forward, out raycastFirewall, 1000)) {
			activeFirewall = raycastFirewall.transform.gameObject;
		}*/

		//Realigns text when text is over filled
		if (bash.text.Length > 1000) {
			bashText.alignment = TextAnchor.LowerLeft;
		}

		//Checks text and commands
		bash.ActivateInputField();
		if (bash.text.Length < consoleLogBuffer.Length) {
			bash.text = consoleLogBuffer;
		}
		bash.MoveTextEnd (false);

		//Remove tilde keys
		bash.text = bash.text.Replace ("`", "");

		if (Input.GetKeyDown (KeyCode.Return)) {
			command = bash.text.Replace (consoleLogBuffer, "");
			executeCommand (command);
			//Debug.Log (command);
			consoleLogBuffer = bash.text;

		}
	}

	void executeCommand(string command){
		//NOTE: COMMANDS NOT LISTED HERE WILL BE EXECUTED FROM FIREWALL COMMANDS

		if (command == "boot.exe") {
			bash.text += "\n" + "\nInitialising..." +
				"\nPCK bash, version 4.1.12(1)-indev (x84_64-pck-linux)" +
				"\nCore Module Self Check... Complete!" +
				"\nNetwork Module Self Check... Complete!" +
				"\nMovement Module Self Check... Complete!" +
				"\nCommand & Control Module Self Check... Failed!" +
				"\nMemory Self Check... Failed!" +
				"\n" +
				"\n40% Core Integrity. Server Connections Failed." +
				"\nNEW OBJECTIVE: LOAD BACKUP MODULE";
		}

		else if (command == "help") {
			bash.text += "\nPCK bash, version 4.1.12(1)-indev (x84_64-pck-linux)" +
			"\nUse man [command] to find out more about each command" +
			"\nhelp" +
			"\nping" +
			"\nnmap " +
			"\ns_client [-p port]";
			
			//Debug.Log ("help printed!");
		} else if (command == "ping") {
		} else if (command == "nmap") {
		} else if (command == "s_client") {
		}

		//Man descriptions
		else if (command == "man help") {
			bash.text += "\nGood joke.";
		} else if (command == "man man") {
			bash.text += 
			"\nNAME: man - an interface to the on-line reference manuals" +
			"\nDESCRIPTION: man is the system's manual pager. " +
			"Each page argument given to man is normally  the  name of a program, utility or function. " +
			"The manual page associated with each of these arguments is then found and displayed. " +
			"A section, if  provided, will direct man to look only in that section ofthe manual. " +
			"The default action is to search in all  of  the  availablesections, " +
			"following a pre-defined order and to show only the first page found, " +
			"even if page exists in several sections.";
		} else if (command == "man ping") {
			bash.text += 
			"\nNAME: ping - send ICMP ECHO_REQUEST to network hosts" +
			"\nDESCRIPTION: ping uses the ICMP protocol's mandatory ECHO_REQUEST datagram to elicit an ICMP ECHO_RESPONSE from a host or gateway. " +
			"ECHO_REQUEST datagrams (''pings'') have an IP and ICMP header, " +
			"followed by a struct timeval and then an arbitrary number of ''pad'' bytes used to fill out the packet. ";
		} else if (command == "man nmap") {
			bash.text +=
			"\nNAME: nmap — Network exploration tool and security / port scanner" +
			"\nSYNOPSIS: nmap [ <Scan Type> ...] [ <Options> ] { <target specification> }" +
			"\nDESCRIPTION: Nmap (“Network Mapper”) is an open source tool for network exploration and security auditing. " +
			"It was designed to rapidly scan large networks, although it works fine against single hosts. " +
			"Nmap uses raw IP packets in novel ways to determine what hosts are available on the network, " +
			"what services (application name and version) those hosts are offering, " +
			"what operating systems (and OS versions) they are running, " +
			"what type of packet filters/firewalls are in use, and dozens of other characteristics. " +
			"While Nmap is commonly used for security audits, " +
			"many systems and network administrators find it useful for routine tasks such as network inventory, " +
			"managing service upgrade schedules, and monitoring host or service uptime." +
			"The output from Nmap is a list of scanned targets, with supplemental information on each depending on the options used. " +
			"Key among that information is the “interesting ports table”. " +
			"That table lists the port number and protocol, service name, and state. " +
			"The state is either open, filtered, closed, or unfiltered. " +
			"Open means that an application on the target machine is listening for connections/packets on that port. " +
			"Filtered means that a firewall, filter, or other network obstacle is blocking the port so that Nmap cannot tell whether it is open or closed. " +
			"Closed ports have no application listening on them, though they could open up at any time. " +
			"Ports are classified as unfiltered when they are responsive to Nmap's probes, but Nmap cannot determine whether they are open or closed. " +
			"Nmap reports the state combinations open|filtered and closed|filtered when it cannot determine which of the two states describe a port. " +
			"The port table may also include software version details when version detection has been requested. When an IP protocol scan is requested " +
			"(-sO), Nmap provides information on supported IP protocols rather than listening ports." +
			"In addition to the interesting ports table, Nmap can provide further information on targets, " +
			"including reverse DNS names, operating system guesses, device types, and MAC addresses.";
		} else if (command == "man s_client") {
			bash.text += 
			"\nNAME: openssl-s_client, s_client - SSL/TLS client program" +
			"\nDESCRIPTION: The s_client command implements a generic SSL/TLS client which connects to a remote host using SSL/TLS. " +
			"It is a very useful diagnostic tool for SSL servers.";
		} 

		//If it doesn't match any commands
		else {
			bash.text += "\n'" + command + "' is not recognised as an internal or external command, operatable program or batch file.";
		}
	}
}