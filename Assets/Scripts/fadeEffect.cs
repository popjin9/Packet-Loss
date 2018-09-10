using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeEffect : MonoBehaviour {
	
	public Image imageToFade;
	public Text textToFade;

	public float fadeTime = 3f;
	public float waitTime = 6f;
	public float startDelay = 6f;
	public bool startVisible = false;
	public float maxAlpha = 1;

	Color colorToFadeTo;


	// Use this for initialization
	void Start () {

		//Set inital image alphas
		if (startVisible == false) {
			fade (0, 0);//Set images to 0
		} else {
			fade (0, maxAlpha);//Set images to 1
		}

		//Delay and fade
		if (startDelay != 0) {
			StartCoroutine (delay ());//Start delay
		} else {
			startFade ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void startFade() {
		if (startVisible == false) {
			StartCoroutine (startTimer ());//Start Timer for fade out
			fade (fadeTime, maxAlpha);//Fade images in
		} else {
			fade (fadeTime, 0);//Fade images out
		}
	}

	void fade (float fadeTime, float alpha) {
		colorToFadeTo = new Color (1f, 1f, 1f, alpha);
		imageToFade.CrossFadeColor (colorToFadeTo, fadeTime, true, true);
		textToFade.CrossFadeColor (colorToFadeTo, fadeTime, true, true);
	}

	IEnumerator startTimer()
	{
		yield return new WaitForSeconds(waitTime);
		fade (fadeTime, 0);//Fade images out
	}

	IEnumerator delay()
	{
		yield return new WaitForSeconds(startDelay);
		startDelay = 0;
		startFade ();
	}
}
