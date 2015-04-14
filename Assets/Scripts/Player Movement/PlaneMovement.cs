using UnityEngine;
using System.Collections;

public class PlaneMovement : MonoBehaviour {
	public float speedConstant = 55f;
	public float speedRotation = 2f;
	private Rigidbody body;

	// Use this for initialization
	void Start () {
		Debug.Log("Start time on Plane:" + Time.deltaTime);
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("Update time on Plane:" + Time.deltaTime);
	}
	
	void FixedUpdate ()	{
		Debug.Log("FixedUpdate time on Plane:" + Time.deltaTime);
		PlayerMovement.moveWith(body, -speedConstant, false);
		InputMovement();
	}

	void accelerate() {
		if (speedConstant < 110) speedConstant++;
	}

	void decelerate() {
		if (speedConstant > 55) speedConstant--;
	}
	
	public void InputMovement() {

		if (Input.GetKey (KeyCode.W)) {
			//accelerate();
		}
		
		if (Input.GetKey (KeyCode.S)) {
			//decelerate();
		}
		
		if (Input.GetKey (KeyCode.A)) {
			PlayerMovement.rotate (body, -speedRotation, 'y');
		} 
		
		if (Input.GetKey (KeyCode.D)) {
			PlayerMovement.rotate (body, speedRotation, 'y');
		}
		
		if (Input.GetKey (KeyCode.Space)) {
			PlayerMovement.floatWith (body, speedConstant);
		}
		
		if (Input.GetKey (KeyCode.LeftShift)) {
			PlayerMovement.floatWith (body, -speedConstant/2);
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			PlayerMovement.reposition (body);
		}
	}
}

