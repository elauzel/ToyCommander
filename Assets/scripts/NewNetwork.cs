﻿using UnityEngine;
using System.Collections;

public class NewNetwork : Photon.MonoBehaviour {
	GameObject player;


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
	
		player = PhotonNetwork.Instantiate("Player - Truck", Vector3.zero, Quaternion.identity, 0);
	
		player.GetComponent<TruckMovement> ().enabled = true;
		player.GetComponentInChildren<Camera>().enabled = true;

}
}
