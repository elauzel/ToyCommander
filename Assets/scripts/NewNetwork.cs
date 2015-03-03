using UnityEngine;
using System.Collections;

public class NewNetwork : MonoBehaviour {
	TruckMovement tm = new TruckMovement();

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.1");
	}
	
	// Update is called once per frame
	void Update () {
		//if (photonView.isMine)
		//tm.InputMovement();
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
		GameObject monster = PhotonNetwork.Instantiate("Player - Truck", Vector3.zero, Quaternion.identity, 0);
		//Camera camera = monster.GetComponentInChildren<Camera> ();
		//CharacterCamera camera = monster.GetComponent<CharacterCamera>();
		//camera.enabled = true;

	}


}
