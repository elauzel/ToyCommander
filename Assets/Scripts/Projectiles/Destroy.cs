using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
	public float lifetime = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake () {
		Destroy(this.gameObject, lifetime);
	}
}
