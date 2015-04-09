using UnityEngine;
using System.Collections;

public class PlaneMovement : MonoBehaviour {
	public float speedGas = 10f;
	public float speedTurn = 10f;
	public float speedRotation = 10f;
	private float speed;
	
	// Use this for initialization
	void Start () {
		Debug.Log("Start time on Plane:" + Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("Update time on Plane:" + Time.deltaTime);
		speed = rigidbody.velocity.magnitude;
	}
	
	void FixedUpdate ()	{
		Debug.Log("FixedUpdate time on Plane:" + Time.deltaTime);
		accelerate ();
		InputMovement();
	}

	void accelerate() {
		rigidbody.AddRelativeForce(Vector3.forward * speedGas);
	}
	
	public void InputMovement() {
		
		if (Input.GetKey (KeyCode.A)) {
			rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles + new Vector3(0f, -speedRotation/2, 0f));
		} 
		
		if (Input.GetKey (KeyCode.D)) {
			rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles + new Vector3(0f, speedRotation/2, 0f));
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