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
		
		//player = PhotonNetwork.Instantiate("Player - Truck", Vector3.zero, Quaternion.identity, 0);
		//player = PhotonNetwork.Instantiate("Player - Truck", new Vector3(2f, 0.115f, 12f), Quaternion.identity, 0);
		player = PhotonNetwork.Instantiate("Player - Tank", new Vector3(2f, 1f, 12f), Quaternion.identity, 0);
		
		player.GetComponent<TruckMovement> ().enabled = true;
		player.GetComponent<RaycastShooting1> ().enabled = true;
		player.GetComponent<PlayerHealth1> ().enabled = true;
		//((MonoBehaviour)player.GetComponent("RaycastShooting") ).enabled = true;
		//((MonoBehaviour)player.GetComponent("PlayerHealth") ).enabled = true;
		player.GetComponentInChildren<Camera>().enabled = true;
		
	}
	
	public void OnPlayerDeath()
	{
		PhotonView photonView = PhotonView.Get(this);
		photonView.RPC("Dead", PhotonTargets.All);
		
	}
	
	
}