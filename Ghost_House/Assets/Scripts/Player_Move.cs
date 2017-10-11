using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour {
	public float moveSpeed;
	public float turnSpeed;
	public float jumpHeight;

	void Update () {
	var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
	var y = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;
	var j = Input.GetAxis("Jump") * Time.deltaTime * jumpHeight;


	transform.Translate(0,0,z);
	transform.Rotate(0,y,0);
	transform.Translate(0,j,0);
	}
}
