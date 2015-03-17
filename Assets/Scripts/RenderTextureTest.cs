using UnityEngine;
using System.Collections;

public class RenderTextureTest : MonoBehaviour {
	public float refresh = 0.01666666666666666666666666666667f;

	// Use this for initialization
	void Start () {
		InvokeRepeating( "SimulateRenderTexure", 0f, refresh );
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SimulateRenderTexure() {		
		renderer.material.mainTexture = RenderTextureScript.Capture();
	}
}