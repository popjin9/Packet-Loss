/*
    Justin Lou
    4/05/18
    Firewall Port Control
	Checks of the player can pass through the firewall
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firewallPortControl : MonoBehaviour {

	bool block = false;
	bool disabled = false;

	List<int> openPorts;
	List<int> playerUnlockedPorts;

	void Start () {
		block = checkPorts (openPorts, playerUnlockedPorts);
	}

	void Update () {
		
	}

	//Checks ports, returns 1 if player can access port
	bool checkPorts (List<int> openPorts, List<int> playerUnlockedPorts){
		
		List<int> matchedPorts;
		bool firewallOpen = false;

		foreach(int openPort in openPorts){
			foreach(int unlockedPort in openPorts){
				if (openPort == unlockedPort) {
					//firewallOpen = true;
				}
			}
		}

		return (firewallOpen);
	}

	//
	void firewallAccessControl (){

	}
}