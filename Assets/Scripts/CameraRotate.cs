using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {

	public Transform target;
	float speed = 4.0f;

	void Update ()
	{
		transform.LookAt (target);

		if (Input.GetAxis ("Vertical") != 0) 
			transform.RotateAround (target.position, transform.right, Input.GetAxis ("Vertical") * speed);

		if (Input.GetAxis ("Horizontal") != 0)
			transform.RotateAround(target.position, Vector3.up, -Input.GetAxis("Horizontal") * speed); 

		if (GameObject.Find ("Main Camera").transform.position.y > 10.0f || GameObject.Find ("Main Camera").transform.position.y < -8.0f) {
		
			transform.RotateAround (target.position, transform.right, -Input.GetAxis ("Vertical") * speed);
		}
	}
}