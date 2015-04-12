using UnityEngine;
using System.Collections;

public class HelicopterMovement : MonoBehaviour {
	public float speedGas = 1.5f;
	public float speedTurn = 3f;
	public float speedRotation = 0.75f;
	private Rigidbody body;
	
	// Use this for initialization
	void Start () {
		Debug.Log("Start time on Helicopter:" + Time.deltaTime);
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("Update time on Helicopter:" + Time.deltaTime);
	}
	
	void FixedUpdate ()	{
		Debug.Log("FixedUpdate time on Helicopter:" + Time.deltaTime);
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
			PlayerMovement.rotate (body, -speedRotation);
		} 
		
		if (Input.GetKey (KeyCode.D)) {
			PlayerMovement.rotate (body, speedRotation);
		}
		
		if (Input.GetKey (KeyCode.Space)) {
			PlayerMovement.floatWith (body, speedGas);
		}
		
		if (Input.GetKey (KeyCode.LeftShift)) {
			PlayerMovement.floatWith (body, -speedGas);
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			PlayerMovement.reposition (body);
		}
	}
}
