/*
    Justin Lou
    4/05/18
    Firewall Port Control
	Checks if the player can pass through the firewall
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firewallPortControl : MonoBehaviour {

	public List<int> openPorts;
	public List<int> playerUnlockedPorts;

	public bool solid;

	public Collider firewallCollider;

	public firewallMaterialChange firewallMaterialChange;

	void Start () {
		//block = checkPorts (openPorts, playerUnlockedPorts);
	}

	void Update () {
		firewallSolid (solid);
	}

	//Checks ports, returns 1 if player can access port
	bool checkPorts (List<int> openPorts, List<int> playerUnlockedPorts){

		//List<int> matchedPorts;
		bool firewallOpen = false;

		foreach(int openPort in openPorts){
			foreach(int unlockedPort in openPorts){
				if (openPort == unlockedPort) {
					//matchedPorts.Add (openPort);
					firewallOpen = true;
				}
			}
		}

		return (firewallOpen);
	}

	//Changes the firewall to be solid or not solid
	void firewallSolid (bool solid){
		firewallCollider.enabled = solid;
		firewallMaterialChange.blockFirewall (solid);
	}
}