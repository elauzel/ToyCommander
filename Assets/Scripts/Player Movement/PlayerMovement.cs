using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void moveWith (Rigidbody body, float thisSpeed, bool isTruck)
	{
		if (isTruck) {
			body.AddRelativeForce (Vector3.left * thisSpeed);
		} else {
			body.AddRelativeForce (Vector3.back * thisSpeed);
		}
	}

	public static void rotateWith (Rigidbody body, float thisSpeed, bool stopFirst)
	{
		if (stopFirst) {
			body.velocity = Vector3.zero; // stop the vehicle
		}

		body.rotation = Quaternion.Euler (body.rotation.eulerAngles + moveYAxis (thisSpeed));
	}

	public static void rotateWithThreshhold (Rigidbody body, float slowSpeed, float rotateSpeed, bool isTruck)
	{
		if (body.velocity.magnitude > 0.5f) { // if the vehicle is moving
			moveWith (body, slowSpeed, isTruck); // slow it down more if you have the gas on
			rotateWith(body, rotateSpeed, false);
		}
	}
	
	public static Vector3 moveYAxis (float thisSpeed)
	{
		return new Vector3 (0f, thisSpeed, 0f);
	}
	
	public static void floatWith (Rigidbody body, float thisSpeed)
	{
		body.AddRelativeForce (Vector3.up * thisSpeed);
	}
	
	public static void reposition (Rigidbody body)
	{
		body.transform.rotation = Quaternion.identity;
	}
}
