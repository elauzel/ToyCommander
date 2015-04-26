using UnityEngine;
using System.Collections;


public class PlayerHealth : Photon.MonoBehaviour {
	public int health;
	public GameObject obj;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate() {
		Debug.Log("FixedUpdate time on PlayerHealth:" + Time.deltaTime);
	}

	// Update is called once per frame
	void Update () {
		// Debug.Log("Update time on PlayerHealth:" + Time.deltaTime);
	}

	[RPC] public void ChangeHealth(int amount) {
		health -= amount;
		checkDeath ();
	}

	public void checkDeath() {
		if (health <= 0) Dead ();
	}

	void Dead() {
		if (GetComponent<PhotonView> ().isMine) {
			ResetCameraAndTimer ();
		}

		print ("Died at " + Time.deltaTime + "!");
		PhotonNetwork.Destroy (gameObject);		
	}

	void ResetCameraAndTimer () {
		if (gameObject.tag == "Player") {
			NewNetwork nn = GameObject.FindObjectOfType<NewNetwork> ();
			nn.standbyCamera.SetActive (true);
			nn.respawnTimer = 3f;
		}
	}

	void OnGUI() {
		if (GetComponent<PhotonView> ().isMine && gameObject.tag == "Player") {
			CheckForSuicide ();
		}

	}

	void CheckForSuicide () {
		if (GUI.Button (new Rect (Screen.width - 100, 0, 100, 40), "Suicide")) {
			Dead ();
		}
	}
}
