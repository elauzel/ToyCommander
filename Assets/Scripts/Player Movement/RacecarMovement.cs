using UnityEngine;
using System.Collections;

public class RacecarMovement : MonoBehaviour {
	public float speedGas = 2.5f;
	public float speedTurn = 5f;
	public float speedRotation = 2.5f;
	private Rigidbody body;
	
	// Use this for initialization
	void Start () {
		Debug.Log("Start time on Car:" + Time.deltaTime);
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("Update time on Car:" + Time.deltaTime);
	}
	
	void FixedUpdate ()	{
		Debug.Log("FixedUpdate time on Car:" + Time.deltaTime);
		InputMovement();
	}

	public void InputMovement() {
		
		if (Input.GetKey (KeyCode.W)) {
			PlayerMovement.moveWith (body, speedGas, false);
		}
		
		if (Input.GetKey (KeyCode.S)) {
			PlayerMovement.moveWith (body, -speedGas, false);
		}
		
		if (Input.GetKey (KeyCode.A)) {
			PlayerMovement.moveWith (body, -speedGas/25, false); // slow it down the more you have the gas on
			PlayerMovement.rotateIfMoving(body, 0.5f, -speedRotation);
		} 
		
		if (Input.GetKey (KeyCode.D)) {
			PlayerMovement.moveWith (body, -speedGas/25, false); // slow it down the more you have the gas on
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