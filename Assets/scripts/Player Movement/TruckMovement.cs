using UnityEngine;
using System.Collections;

public class TruckMovement : MonoBehaviour {
	public float speedGas = 4f;
	public float speedTurn = 4f;
	public float speedRotation = 2f;
	private Rigidbody body;
	private int slowDownMore;

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
		slowDownMore = 1;
		
		if (Input.GetKey (KeyCode.W)) {
			PlayerMovement.moveWith (body, speedGas, true);
			slowDownMore = 3;
		}
		
		if (Input.GetKey (KeyCode.S)) {
			PlayerMovement.moveWith (body, -speedGas, true);
			slowDownMore = 3;
		}
		
		if (Input.GetKey (KeyCode.A)) {
			// PlayerMovement.rotateWithThreshhold (body, -speedRotation, -speedGas*slowDownMore, true);
			PlayerMovement.rotateWith(body, -speedRotation, false);
		} 
		
		if (Input.GetKey (KeyCode.D)) {
			// PlayerMovement.rotateWithThreshhold (body, speedRotation, -speedGas*slowDownMore, true);
			PlayerMovement.rotateWith(body, speedRotation, false);
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
