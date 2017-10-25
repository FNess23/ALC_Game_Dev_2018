using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Flashlight : MonoBehaviour {

	public bool lightOn;

	Light light;

	// Use this for initialization
	void Start () {
		light = GetComponent<Light> ();
		// Set Light default to ON
		lightOn = true;
		light.enabled = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		// Toggle light on/off when F key is pressed.
		if (Input.GetKeyUp (KeyCode.F) && lightOn) {
			lightOn = false;
			light.enabled = false;
		}

		else if (Input.GetKeyUp (KeyCode.F) && !lightOn){
			lightOn= true;
			light.enabled = true;
		}
	
	}
}
