using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activationTrigger : MonoBehaviour {
	
	public GameObject activatedObject;
	public GameObject activatedObject0;
	public GameObject activatedObject1;
	public GameObject activatedObject2;
	public GameObject activatedObject3;
	public GameObject activatedObject4;
	public GameObject activatedObject5;
	public GameObject activatedObject6;

	public GameObject activatedLight;

	public GameObject deactivatedObject;

	public float delay;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		activatedObject.SetActive (true);
		activatedObject0.SetActive (true);
		//StartCoroutine (delayActivation (delay, activatedObject));
		StartCoroutine (delayActivation (delay*2, activatedObject1));
		StartCoroutine (delayActivation (delay*3, activatedObject2));
		StartCoroutine (delayActivation (delay*4, activatedObject3));
		StartCoroutine (delayActivation (delay*5, activatedObject4));
		StartCoroutine (delayActivation (delay*6, activatedObject5));
		StartCoroutine (delayActivation (delay*6, activatedObject6));

		StartCoroutine (delayActivation (delay*6, activatedLight));

		StartCoroutine (delayDeactivation (delay*6, deactivatedObject));
	}

	IEnumerator delayActivation(float delay, GameObject activatedObject)
	{
		yield return new WaitForSeconds(delay);
		activatedObject.SetActive (true);
		//activatedObject.enabled = true;
	}

	IEnumerator delayDeactivation(float delay, GameObject deactivatedObject)
	{
		yield return new WaitForSeconds(delay);
		deactivatedObject.SetActive (false);
	}

}