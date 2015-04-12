using UnityEngine;
using System.Collections;

public class TruckMovement : MonoBehaviour {
	public float speedGas = 4f;
	public float speedRotation = 2f;
	private Rigidbody body;

	// Use this for initialization
	void Start () {
		Debug.Log("Start time on Truck:" + Time.deltaTime);
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("Update time on Truck:" + Time.deltaTime);
	}

	void FixedUpdate ()	{
		Debug.Log("FixedUpdate time on Truck:" + Time.deltaTime);
		InputMovement();
	}

	
	// model is rotated 270 degrees from Blender to face the right direction
	public void InputMovement() {
		
		if (Input.GetKey (KeyCode.W)) {
			PlayerMovement.moveWith (body, speedGas, true);
		}
		
		if (Input.GetKey (KeyCode.S)) {
			PlayerMovement.moveWith (body, -speedGas, true);
		}
		
		if (Input.GetKey (KeyCode.A)) {
			PlayerMovement.moveWith (body, -speedGas/25, true); // slow it down the more you have the gas on
			PlayerMovement.rotateIfMoving(body, 0.5f, -speedRotation);
		} 
		
		if (Input.GetKey (KeyCode.D)) {
			PlayerMovement.moveWith (body, -speedGas/25, true); // slow it down the more you have the gas on
			PlayerMovement.rotateIfMoving(body, 0.5f, speedRotation);
		}
		
		if (Input.GetKey (KeyCode.Space)) {
			PlayerMovement.floatWith (body, speedGas);
		}
		
		if (Input.GetKey (KeyCode.LeftShift)) {
			PlayerMovement.floatWith (body, -speedGas/2);
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			PlayerMovement.reposition (body);
		}
	}
}
