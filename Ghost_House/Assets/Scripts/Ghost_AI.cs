using UnityEngine;
using System.Collections;

public class Ghost_AI : MonoBehaviour {

	public float moveSpeed;

	public Transform target;

	public int damage;

	

	
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.name == "Player"){
			transform.LookAt(target);
			transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
		}	
	}
}
