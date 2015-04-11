using UnityEngine;
using System.Collections;

public class HelicopterSpin : MonoBehaviour {
	public int rotationSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed*60);
	}
}
