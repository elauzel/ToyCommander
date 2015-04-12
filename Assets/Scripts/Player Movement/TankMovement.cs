using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour {
	public float speedGas = 10f;
	public float speedRotation = 2f;
	private Rigidbody body;
	
	// Use this for initialization
	void Start () {
		Debug.Log("Start time on Tank:" + Time.deltaTime);
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("Update time on Tank:" + Time.deltaTime);
	}
	
	void FixedUpdate ()	{
		Debug.Log("FixedUpdate time on Tank:" + Time.deltaTime);
		InputMovement();
	}

	public void InputMovement() {

		if (Input.GetKey (KeyCode.W)) {
			PlayerMovement.moveWith (body, speedGas, true);
		}
		
		if (Input.GetKey (KeyCode.S)) {
			PlayerMovement.moveWith (body, -speedGas, true);
		}
		
		if (Input.GetKey (KeyCode.A)) {
			PlayerMovement.stop(body);
			PlayerMovement.rotate (body, -speedRotation);
		} 
		
		if (Input.GetKey (KeyCode.D)) {
			PlayerMovement.stop(body);
			PlayerMovement.rotate (body, speedRotation);
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