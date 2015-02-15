using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

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

		if (Input.GetKey ("up")) {
			rigidbody.AddRelativeForce(Vector3.up * 50);
		}

		if (Input.GetKey ("down")) {
			rigidbody.AddRelativeForce(Vector3.up * -10);
		}

		if (Input.GetKey ("left")) {
			rigidbody.transform.rotation = Quaternion.identity;
		}

	}
}
