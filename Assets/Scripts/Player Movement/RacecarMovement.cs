using UnityEngine;
using System.Collections;

public class RacecarMovement : MonoBehaviour {
	public float speedGas = 10f;
	public float speedTurn = 10f;
	public float speedRotation = 10f;
	private float speed;
	private int slowDownMore;
	
	// Use this for initialization
	void Start () {
		Debug.Log("Start time on Car:" + Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("Update time on Car:" + Time.deltaTime);
		speed = rigidbody.velocity.magnitude;
	}
	
	void FixedUpdate ()	{
		Debug.Log("FixedUpdate time on Car:" + Time.deltaTime);
		InputMovement();
	}
	
	public void InputMovement() {
		slowDownMore = 1;

		if (Input.GetKey (KeyCode.W)) {
			rigidbody.AddRelativeForce(Vector3.forward * -speedGas);
			slowDownMore = 3;
		} 

		if (Input.GetKey (KeyCode.S)) {
			rigidbody.AddRelativeForce(Vector3.back * -speedGas);
			slowDownMore = 3;
		}
		
		if (Input.GetKey (KeyCode.A)) {
			if (speed > .5) { // if the car is moving
				rigidbody.AddRelativeForce(Vector3.back * -speedGas / 100 * slowDownMore); // slow it down more if you have the gas on
				rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles + new Vector3(0f, -speedRotation/2, 0f));
			}
		} 

		if (Input.GetKey (KeyCode.D)) {
			if (speed > .5) { // if the car is moving
				rigidbody.AddRelativeForce(Vector3.back * -speedGas / 100 * slowDownMore); // slow it down more if you have the gas on
				rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles + new Vector3(0f, speedRotation/2, 0f));
			}
		}
		
		if (Input.GetKey (KeyCode.Space)) {
			rigidbody.AddRelativeForce(Vector3.up * speedGas);
		}

		if (Input.GetKey (KeyCode.LeftShift)) {
			rigidbody.AddRelativeForce(Vector3.down * speedGas / 2);
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rigidbody.transform.rotation = Quaternion.identity;
		}
	}
}
