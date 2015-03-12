using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {
	public float speedGas = 10f;
	public float speedTurn = 10f;
	public float speedRotation = 10f;

	// Use this for initialization
	void Start () {
		Debug.Log("Start time on Car:" + Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("Update time on Car:" + Time.deltaTime);
	}

	void FixedUpdate ()	{
		Debug.Log("FixedUpdate time on Car:" + Time.deltaTime);
		InputMovement();
	}

	void InputMovement() {
		//		if (Input.GetKey(KeyCode.W))
		//			rigidbody.MovePosition(rigidbody.position + Vector3.forward * speed * Time.deltaTime);
		//		
		//		if (Input.GetKey(KeyCode.S))
		//			rigidbody.MovePosition(rigidbody.position - Vector3.forward * speed * Time.deltaTime);
		//		
		//		if (Input.GetKey(KeyCode.D))
		//			rigidbody.MovePosition(rigidbody.position + Vector3.right * speed * Time.deltaTime);
		//		
		//		if (Input.GetKey(KeyCode.A))
		//			rigidbody.MovePosition(rigidbody.position - Vector3.right * speed * Time.deltaTime);
		
		if (Input.GetKey (KeyCode.W)) {
			rigidbody.AddRelativeForce(Vector3.forward * -speedGas);
		}
		
		if (Input.GetKey (KeyCode.A)) {
			rigidbody.AddRelativeForce(Vector3.left * speedTurn);
			rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles + new Vector3(0f, -speedRotation/2, 0f));
		}
		
		if (Input.GetKey (KeyCode.S)) {
			rigidbody.AddRelativeForce(Vector3.back * -speedGas);
			rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles + new Vector3(0f, -speedRotation/2, 0f));
		}
		
		if (Input.GetKey (KeyCode.D)) {
			rigidbody.AddRelativeForce(Vector3.right * speedTurn);
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
		
		// rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles + new Vector3(0f, speedRotation*Input.GetAxis("Mouse X"), 0f));
	}
}
