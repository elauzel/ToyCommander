﻿using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float rotationSpeed = 30f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate ()
	{
		if (Input.GetKey ("w")) {
			rigidbody.AddRelativeForce(Vector3.right * 40);
		}

		if (Input.GetKey ("a")) {
			rigidbody.AddRelativeForce(Vector3.forward * 20);
		}

		if (Input.GetKey ("s")) {
			rigidbody.AddRelativeForce(Vector3.right * -40);
		}

		if (Input.GetKey ("d")) {
			rigidbody.AddRelativeForce(Vector3.forward * -20);
		}

		if (Input.GetKey ("space")) {
			rigidbody.AddRelativeForce(Vector3.up * 50);
		}

		if (Input.GetKey ("down")) {
			rigidbody.AddRelativeForce(Vector3.up * -10);
		}

		if (Input.GetKey ("left")) {
			rigidbody.transform.rotation = Quaternion.identity;
		}

		rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles + new Vector3(0f, rotationSpeed*Input.GetAxis("Mouse X"), 0f));

	}
}
