using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class commandUpgrade : MonoBehaviour {

	public Collider colliderPlayer;
	public GameObject player;
	public List<string> playerUnlockedCommands;

	public GameObject self;

	public string command;

	// Use this for initialization
	void Start () {
		//playerUnlockedCommands = player.GetComponent<playerCommandControl> ().playerUnlockedCommands;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider colliderPlayer){
		//playerUnlockedCommands.Add (command);
		Destroy (self, 0.1f);
	}
}
