using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void moveForward (Rigidbody body, float thisSpeed, bool truckOrTank)
	{
		if (truckOrTank) {
			body.AddRelativeForce (Vector3.left * thisSpeed);
		} else {
			body.AddRelativeForce (Vector3.back * thisSpeed);
		}
	}

	public static void moveLeft (Rigidbody body, float thisSpeed, bool truckOrTank)
	{
		if (truckOrTank) {
			body.AddRelativeForce (Vector3.back * thisSpeed);
		} else {
			body.AddRelativeForce (Vector3.left * thisSpeed);
		}
	}

	public static void maintainSpeed(Rigidbody body, float thisSpeed) {
		if (body.velocity.normalized.magnitude < thisSpeed)
			body.velocity = thisSpeed * body.velocity.normalized;
	}

	public static void stop (Rigidbody body)
	{
		body.velocity = Vector3.zero;
	}

	public static void rotateIfMoving (Rigidbody body, float threshHold, float rotateSpeed, char axis)
	{
		if (body.velocity.magnitude > threshHold) { // if the vehicle is moving beyond the threshhold
			rotate(body, rotateSpeed, axis);		
		}
	}

	public static void rotate(Rigidbody body, float thisSpeed, char axis) {
		Vector3 newAngles = getAngles (thisSpeed, axis);
		body.rotation = Quaternion.Euler (body.rotation.eulerAngles + newAngles);
	}

	static Vector3 getAngles (float thisSpeed, char axis)
	{
		Vector3 angles = Vector3.zero;
		switch (axis) {
		case 'x':
			angles = moveXAxis (thisSpeed);
			break;
		case 'y':
			angles = moveYAxis (thisSpeed);
			break;
		case 'z':
			angles = moveZAxis (thisSpeed);
			break;
		default:
			Debug.Log("Invalid axis!");
			break;
		}

		return angles;
	}
	
	public static Vector3 moveXAxis (float thisSpeed)
	{
		return new Vector3 (thisSpeed, 0f, 0f);
	}
	
	public static Vector3 moveYAxis (float thisSpeed)
	{
		return new Vector3 (0f, thisSpeed, 0f);
	}
	
	public static Vector3 moveZAxis (float thisSpeed)
	{
		return new Vector3 (0f, 0f, thisSpeed);
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
