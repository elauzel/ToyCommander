using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	public Texture2D crosshairTexture;
	public float crosshairScale = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		//if not paused
		if(Time.timeScale != 0)
		{
			DrawCrosshair();
		}
	}

	void DrawCrosshair() {
		if(crosshairTexture!=null) {
			float left = (Screen.width-crosshairTexture.width*crosshairScale)/2;
			float top = (Screen.height-crosshairTexture.height*crosshairScale)/2;
			float width = crosshairTexture.width*crosshairScale;
			float height = crosshairTexture.height*crosshairScale;
			GUI.DrawTexture(new Rect(left ,top, width, height),crosshairTexture);
		} else
			Debug.Log("No crosshair texture set in the Inspector");
	}
}
