using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour {

	public bool lightOn = true;
	// Flashlight power capacity
	public int maxPower = 4;
	// Usable flashlight power
	public int currentPower;

	public int batDrainAmt;
	
	public float batDrainDelay;

	Light light;

	public Text batteryText;

	// Use this for initialization
	void Start () {
		//Add power to flashlight
		currentPower = maxPower;
		print("Power = " + currentPower);
		light = GetComponent<Light> ();
		// Set Light default to ON
		lightOn = true;
		print("Turn light on when Flashlight is initiated")
		light.enabled = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		// Toggle light on/off when F key is pressed.
		if (Input.GetKeyUp (KeyCode.F) && lightOn) {
			print("Light Off");
			lightOn = false;
			light.enabled = false;
		}

		else if (Input.GetKeyUp (KeyCode.F) && !lightOn){
			print("Light On");
			lightOn = true;
			light.enabled = true;
		}


		batteryText.text = currentPower.ToString();

		if(currentPower = 0){
			StartCoroutine(BatteryDrain(batDrainDelay,batDrainAmt));
		}
	}
	public void setlightOn(){
		lightOn = true;
	}

	public bool islightOn(){
		return lightOn;
	}

	IEmumerator BatteryDrain(float delay, int amount){
		yield return new WaitForSeconds(delay);
		currentPower -= amount;
		if(currentPower <= 0){
			currentPower = 0;
			print("Battery is dead");
			light.enabled = false;
		}
	}
}
