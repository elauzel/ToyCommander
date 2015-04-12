using UnityEngine;
using System.Collections;

public class HelicopterSpin : MonoBehaviour {
	public int rotationSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("Update time on HelicopterSpin:" + Time.deltaTime);
		transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed*60);
	}
}
