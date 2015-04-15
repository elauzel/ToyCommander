﻿using UnityEngine;
using System.Collections;

public class PlaneMovement : MonoBehaviour {
	public float speedGas = 7f;
	public float speedConstant = 55f;
	public float speedRotation = 2f;
	private Rigidbody body;

	// Use this for initialization
	void Start () {
		Debug.Log("Start time on Plane:" + Time.deltaTime);
		body = GetComponent<Rigidbody>();
		accelerate(speedConstant);
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("Update time on Plane:" + Time.deltaTime);
	}
	
	void FixedUpdate ()	{
		Debug.Log("FixedUpdate time on Plane:" + Time.deltaTime);
		InputMovement();
	}

	void accelerate(float thisSpeed) {
		rigidbody.AddRelativeForce(Vector3.forward * thisSpeed);
	}
	
	public void InputMovement() {

		if (Input.GetKey (KeyCode.W)) {
			speedGas++;
			PlayerMovement.moveWith (body, -speedGas, false);
		}
		
		if (Input.GetKey (KeyCode.S)) {
			speedGas--;
			PlayerMovement.moveWith (body, speedGas, false);
			//PlayerMovement.maintainSpeed (body, speedConstant);
		}
		
		if (Input.GetKey (KeyCode.A)) {
			PlayerMovement.rotate (body, -speedRotation, 'y');
		} 
		
		if (Input.GetKey (KeyCode.D)) {
			PlayerMovement.rotate (body, speedRotation, 'y');
		}
		
		if (Input.GetKey (KeyCode.Space)) {
			PlayerMovement.floatWith (body, speedGas);
		}
		
		if (Input.GetKey (KeyCode.LeftShift)) {
			PlayerMovement.floatWith (body, -speedGas/2);
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			PlayerMovement.reposition (body);
		}
	}
}

