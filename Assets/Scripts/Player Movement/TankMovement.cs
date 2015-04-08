using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour {
	public float speedGas = 10f;
	public float speedTurn = 10f;
	public float speedRotation = 10f;
	private float speed;
	private int slowDownMore;
	
	// Use this for initialization
	void Start () {
		Debug.Log("Start time on Tank:" + Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("Update time on Tank:" + Time.deltaTime);
		speed = rigidbody.velocity.magnitude;
	}
	
	void FixedUpdate ()	{
		Debug.Log("FixedUpdate time on Tank:" + Time.deltaTime);
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
			speed = 0;
			rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles + new Vector3(0f, -speedRotation/2, 0f));
		}
		
		if (Input.GetKey (KeyCode.D)) {
			speed = 0;
			rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles + new Vector3(0f, speedRotation/2, 0f));
		}
		
		if (Input.GetKey (KeyCode.Space)) {
			rigidbody.AddRelativeForce(Vector3.up * speedGas);
		}
		
		if (Input.GetKey (KeyCode.DownArrow)) {
			rigidbody.AddRelativeForce(Vector3.up * -speedGas);
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rigidbody.transform.rotation = Quaternion.identity;
		}
	}
}
