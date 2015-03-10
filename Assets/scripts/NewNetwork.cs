using UnityEngine;
using System.Collections;

public class NewNetwork : Photon.MonoBehaviour {
	GameObject monster;


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
	
		monster = PhotonNetwork.Instantiate("Player - Truck", Vector3.zero, Quaternion.identity, 0);


		//PhotonView photonView = monster.GetComponent<PhotonView>();

		//if (!photonView.isMine) {
		monster.GetComponent<TruckMovement> ().enabled = true;

		monster.GetComponentInChildren<Camera>().enabled = true;
		//monster.GetComponentInChildren("Main Camera").animation.gameObject.SetActive (true);
		//}

		//Camera camera = monster.GetComponentInChildren<Camera> ();
		//CharacterCamera camera = monster.GetComponent<CharacterCamera>();
		//camera.enabled = true;

	


}
}
