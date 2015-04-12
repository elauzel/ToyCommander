using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void moveWith (Rigidbody body, float thisSpeed, bool truckOrTank)
	{
		if (truckOrTank) {
			body.AddRelativeForce (Vector3.left * thisSpeed);
		} else {
			body.AddRelativeForce (Vector3.back * thisSpeed);
		}
	}

	public static void stop (Rigidbody body)
	{
		body.velocity = Vector3.zero;
	}

	public static void rotateIfMoving (Rigidbody body, float threshHold, float rotateSpeed)
	{
		if (body.velocity.magnitude > threshHold) { // if the vehicle is moving beyond the threshhold
			rotate(body, rotateSpeed);		
		}
	}

	public static void rotate(Rigidbody body, float thisSpeed) {
		body.rotation = Quaternion.Euler (body.rotation.eulerAngles + moveYAxis (thisSpeed));
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
