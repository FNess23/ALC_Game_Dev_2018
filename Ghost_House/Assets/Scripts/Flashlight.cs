using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour {
	public Light spotl;
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
		currentPower = 0;
		print("Power = " + currentPower);
		light = GetComponent<Light> ();
		// Set Light default to OFF
		lightOn = false;
		print("Turn light on when Flashlight is initiated");
		light.enabled = false;
		spotl.enabled = false;
	
	}
	long count =0;
	bool draining = false;
	void battery_Drain(){
		
		if (count%(60*batDrainDelay) == 0 && lightOn)
		{
			if(currentPower > 0)
				currentPower-=batDrainAmt;
			else{
				print("Battery Dead");
				lightOn = false;
				light.enabled = false;
				spotl.enabled = false;
				count = 0;
			}
		}
	}
	// Update is called once per frame
	void Update () {
		
		//print("Update");
		// Toggle light on/off when F key is pressed.
		if (Input.GetKeyUp (KeyCode.F) && lightOn ) {
			print("Light Off");
			lightOn = !lightOn;
			light.enabled = !light.enabled;
			spotl.enabled = !spotl.enabled;
		}

		else if (Input.GetKeyUp (KeyCode.F) && !lightOn && currentPower>0){
			print("Light On");
			lightOn = !lightOn;
			light.enabled = !light.enabled;
			spotl.enabled = !spotl.enabled;
		}


		batteryText.text = currentPower.ToString();
		
		//if(currentPower == 0){
		if(currentPower >0 && lightOn){
			if(!draining){
				StartCoroutine(BatteryDrain(batDrainDelay,batDrainAmt));
			}
			//if(count == 0)
				//battery_Drain();
		}
		else if(currentPower <= 0){
			lightOn = false;
			light.enabled = false;
			spotl.enabled = false;
		}
	}
	public void setlightOn(){
		lightOn = true;
	}

	public bool islightOn(){
		return lightOn;
	}

	IEnumerator BatteryDrain(float delay, int amount){
		if(lightOn){
			draining = true;
			yield return new WaitForSeconds(delay);
			print (currentPower);
			currentPower -= amount;
			//print(Time.time);
        	  //yield return new WaitForSecondsRealtime(5);
        	//print(Time.time);
			//print("lightOn:" + lightOn);
			
			if(currentPower <= 0){
				currentPower = 0;
				print("Battery is dead");
				light.enabled = false;
			}
			draining = false;
		}
		
	}
}
