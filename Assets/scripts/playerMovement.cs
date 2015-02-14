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
			rigidbody.AddRelativeForce(Vector3.forward * 10);
		}
	}
}
