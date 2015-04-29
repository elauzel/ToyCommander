using UnityEngine;
using System.Collections;

public class PlaneMovement : MonoBehaviour {
	public float speedGas = 7f;
	public float speedConstant = 7f;
	public float speedRotation = 2f;
	private Rigidbody body;

	// Use this for initialization
	void Start () {
		Debug.Log("Start time on Plane:" + Time.deltaTime);
		body = GetComponent<Rigidbody>();
		PlayerMovement.moveForward (body, -speedGas, false);
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("Update time on Plane:" + Time.deltaTime);
	}
	
	void FixedUpdate ()	{
		Debug.Log("FixedUpdate time on Plane:" + Time.deltaTime);
		InputMovement();
	}
	
	public void InputMovement() {

		if (Input.GetKey (KeyCode.W)) {
			speedGas+=40;
			resumeSpeed(-speedGas);
		}
		
		if (Input.GetKey (KeyCode.S)) {
			if (speedGas > speedConstant) {
				decelerate ();
			}
		}
		
		if (Input.GetKey (KeyCode.A)) {
			PlayerMovement.rotate (body, -speedRotation, 'y');
			resumeSpeed(-speedGas);
		} 
		
		if (Input.GetKey (KeyCode.D)) {
			PlayerMovement.rotate (body, speedRotation, 'y');
			resumeSpeed(-speedGas);
		}
		
		if (Input.GetKey (KeyCode.Space)) {
			PlayerMovement.floatWith (body, speedGas/30);
		}
		
		if (Input.GetKey (KeyCode.LeftShift)) {
			PlayerMovement.floatWith (body, -speedGas/30);
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			PlayerMovement.reposition (body);
		}
	}

	void decelerate ()
	{
		speedGas-=40;
		resumeSpeed (-speedGas);
	}

	void resumeSpeed (float thisSpeed)
	{
		PlayerMovement.stop (body);
		PlayerMovement.moveForward (body, thisSpeed, false);
	}
}

