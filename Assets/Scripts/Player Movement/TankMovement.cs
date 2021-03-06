﻿using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour {
	public float speedGas = 10f;
	public float speedRotation = 2f;
	private Rigidbody body;
	
	// Use this for initialization
	void Start () {
		Debug.Log("Start time on Tank:" + Time.deltaTime);
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("Update time on Tank:" + Time.deltaTime);
	}
	
	void FixedUpdate ()	{
		Debug.Log("FixedUpdate time on Tank:" + Time.deltaTime);
		InputMovement();
	}

	// model is rotated 270 degrees from Blender to face the right direction
	public void InputMovement() {

		if (Input.GetKey (KeyCode.W)) {
			PlayerMovement.moveForward (body, speedGas, true);
			PlayerMovement.rotate(body, speedRotation/19, 'y'); // fixes veering
		}
		
		if (Input.GetKey (KeyCode.S)) {
			PlayerMovement.moveForward (body, -speedGas, true);
			PlayerMovement.rotate(body, -speedRotation/19, 'y'); // fixes veering
		}
		
		if (Input.GetKey (KeyCode.A)) {
			PlayerMovement.moveForward (body, -speedGas, true); // slow it down the more you have the gas on
			PlayerMovement.rotate(body, -speedRotation, 'y');
		} 
		
		if (Input.GetKey (KeyCode.D)) {
			PlayerMovement.moveForward (body, -speedGas, true); // slow it down the more you have the gas on
			PlayerMovement.rotate(body, speedRotation, 'y');
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			PlayerMovement.reposition (body);
		}
	}
}