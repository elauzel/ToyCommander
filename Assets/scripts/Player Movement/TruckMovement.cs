using UnityEngine;
using System.Collections;

public class TruckMovement : MonoBehaviour {
	public float speedGas = 10f;
	public float speedTurn = 10f;
	public float speedRotation = 10f;
	private float speed;
	private int slowDownMore;

	// Use this for initialization
	void Start () {
		Debug.Log("Start time on Truck:" + Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("Update time on Truck:" + Time.deltaTime);
		speed = rigidbody.velocity.magnitude;
	}

	void FixedUpdate ()	{
		Debug.Log("FixedUpdate time on Truck:" + Time.deltaTime);
		InputMovement();
	}

	public void InputMovement() {
		// model is rotated 270 degrees from Blender to face the right direction
		slowDownMore = 1;

		if (Input.GetKey (KeyCode.W)) {
			rigidbody.AddRelativeForce(Vector3.right * -speedGas);
			slowDownMore = 3;
		}

		if (Input.GetKey (KeyCode.S)) {
			rigidbody.AddRelativeForce(Vector3.left * -speedGas);
			slowDownMore = 3;
		}
		
		if (Input.GetKey (KeyCode.A)) {
			if (speed > .5) { // if the truck is moving
				rigidbody.AddRelativeForce(Vector3.left * -speedGas/100*slowDownMore); // slow it down more if you have the gas on
				rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles + new Vector3(0f, -speedRotation/2, 0f));
			}
		}
		
		if (Input.GetKey (KeyCode.D)) {
			if (speed > .5) { // if the truck is moving
				rigidbody.AddRelativeForce(Vector3.left * -speedGas/100*slowDownMore); // slow it down more if you have the gas on
				rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles + new Vector3(0f, speedRotation/2, 0f));
			}
		}
		
		if (Input.GetKey (KeyCode.Space)) {
			rigidbody.AddRelativeForce(Vector3.up * speedGas);
		}
		
		if (Input.GetKey (KeyCode.DownArrow)) {
			rigidbody.AddRelativeForce(Vector3.up * -speedGas);
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rigidbody.transform.rotation = Quaternion.identity;
		}
		
		// rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles + new Vector3(0f, speedRotation*Input.GetAxis("Mouse X"), 0f));
	}
}
