﻿/*
	Justin Lou z5218709
	25/04/18
	Firewall Material Change
	Changes the material between red, blue and black
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firewallMaterialChange : MonoBehaviour {
	
	public bool block; 
	public bool disabled;

	public Material firewallInnerBlue;
	public Material firewallOuterBlue;

	public Material firewallInnerRed;
	public Material firewallOuterRed;

	public Material firewallBlack;

	public Renderer firewallRenderer;

	public GameObject[] firewallInnerBlocks;
	public GameObject[] firewallOuterBlocks;

	// Use this for initialization
	void Start () {
		bool block = false;
		bool disabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (disabled == true) {//Sets firewall black if disabled
			changeMaterial (firewallInnerBlocks, firewallBlack);
			changeMaterial (firewallOuterBlocks, firewallBlack);
		} else if (block == false) {//Sets firewall Blue if not blocked
			changeMaterial (firewallInnerBlocks, firewallInnerBlue);
			changeMaterial (firewallOuterBlocks, firewallOuterBlue);
		} else if (block == true){//Sets firewall Red if blocked
			changeMaterial (firewallInnerBlocks, firewallInnerRed);
			changeMaterial (firewallOuterBlocks, firewallOuterRed);
		}
	}

	void changeMaterial (GameObject[] firewallArray, Material firewallMaterial){
		foreach(GameObject firewall in firewallArray){
			firewallRenderer = firewall.GetComponent<Renderer>();
			firewallRenderer.material = firewallMaterial;
		}
	}
}
