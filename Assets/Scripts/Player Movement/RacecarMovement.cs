using UnityEngine;
using System.Collections;

public class RacecarMovement : MonoBehaviour {
	public float speedGas = 2.5f;
	public float speedTurn = 5f;
	public float speedRotation = 2.5f;
	private Rigidbody body;
	private int slowDownMore;
	
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
		slowDownMore = 1;
		
		if (Input.GetKey (KeyCode.W)) {
			PlayerMovement.moveWith (body, speedGas, false);
			slowDownMore = 3;
		}
		
		if (Input.GetKey (KeyCode.S)) {
			PlayerMovement.moveWith (body, -speedGas, false);
			slowDownMore = 3;
		}
		
		if (Input.GetKey (KeyCode.A)) {
			// PlayerMovement.rotateWithThreshhold (body, -speedRotation, speedGas*slowDownMore, false);
			PlayerMovement.rotateWith(body, -speedRotation, false);
		} 
		
		if (Input.GetKey (KeyCode.D)) {
			// PlayerMovement.rotateWithThreshhold (body, speedRotation, speedGas*slowDownMore, false);
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