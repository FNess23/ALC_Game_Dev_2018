using UnityEngine;
using System.Collections;

public class Battery : MonoBehaviour {

	public int power = 4;

	public GameObject Flashlight;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player"){
			
			Flashlight.gameObject.GetComponentInChildren<Flashlight>().currentPower = power;
			
			Destroy(gameObject);
		}
	}
}
