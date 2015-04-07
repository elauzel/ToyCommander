using UnityEngine;
using System.Collections;

public class NewNetwork : Photon.MonoBehaviour {
	GameObject player;
	public float playerHealth = 100f;
	public float startX, startY, startZ;

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.1");
	}
	
	// Update is called once per frame
	void Update () {

		}

	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Can't join random room!");
		PhotonNetwork.CreateRoom(null);
	} 

	void OnJoinedRoom()
	{
	
		//player = PhotonNetwork.Instantiate("Player - Truck", Vector3.zero, Quaternion.identity, 0);
		//player = PhotonNetwork.Instantiate("Player - Truck", new Vector3(2f, 0.115f, 12f), Quaternion.identity, 0);
		player = PhotonNetwork.Instantiate("Player - Truck", new Vector3(startX, startY, startZ), Quaternion.identity, 0);

		player.GetComponent<TruckMovement> ().enabled = true;
		player.GetComponent<Shoot> ().enabled = true;
		player.GetComponentInChildren<Camera>().enabled = true;

}
	void onShot()
	{
		playerHealth -= 30f;
		if (playerHealth <= 0) {
			Destroy(gameObject);
		}
	}

}
