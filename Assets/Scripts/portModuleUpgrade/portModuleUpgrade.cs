using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portModuleUpgrade : MonoBehaviour {

	public Collider colliderPlayer;
	public GameObject player;
	public List<int> playerUnlockedPorts;

	public GameObject self;

	public int portNum;

	// Use this for initialization
	void Start () {
		playerUnlockedPorts = player.GetComponent<playerPortControl> ().playerUnlockedPorts;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider colliderPlayer){
		playerUnlockedPorts.Add (portNum);
		Destroy (self, 0.1f);
	}
}
