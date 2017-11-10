using UnityEngine;
using System.Collections;

public class GhostStun : MonoBehaviour {

	bool lightCheck;
	Flashlight flash;
	public GameObject ghost;

	void Start () {
		// lightCheck = GetComponent<Flashlight>().lightOn;
		flash = gameObject.GetComponentInChildren<Light>().GetComponentInChildren<Flashlight>();
		print("Obj"+flash);
		flash.setlightOn();
		print("Start" + flash.islightOn());
	
	}
	
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		print(other.gameObject.name);
		print ("Collider" + flash);
		if(other.gameObject.name == "Ghost" && flash == true){
			print("Ghost is stunned!");

			other.GetComponent<Ghost_AI>().moveSpeed = 0f;
			StartCoroutine(Wait(5));
		}
	}

	IEnumerator Wait(float time){
		yield return new WaitForSeconds (time);
		ghost.GetComponent<Ghost_AI>().moveSpeed = 5f;
		print("Ghost is unstunned");

	}
}
