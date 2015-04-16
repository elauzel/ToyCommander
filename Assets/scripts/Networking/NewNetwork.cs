using UnityEngine;
using System.Collections;

public enum PlayerType { Helicopter,Plane,Tank,Racecar,Truck }

public class NewNetwork : Photon.MonoBehaviour {
	public PlayerType type;
	public float x = 0;
	public float y = 0;
	public float z = 0;
	public float respawnTimer = 0;
	public GameObject standbyCamera;
	
	private GameObject player;
	private Vector3 location ;
	private bool hasPickedTeam = false;
	private bool joined = false;
	private int teamID = 0;
	
	// Use this for initialization
	void Start () {

		location = new Vector3 (x, y, z);
		Debug.Log("Start time on NewNetwork:" + Time.deltaTime);
		PhotonNetwork.ConnectUsingSettings("0.1");
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("Update time on NewNetwork:" + Time.deltaTime);
		if (respawnTimer > 0) {
			respawnTimer -= Time.deltaTime;

			if (respawnTimer <= 0) {
				OnJoinedRoom();
				SpawnPlayerAt (location, teamID);
			}
		}
	}
	
	void OnGUI()
	{
		if (hasPickedTeam == false && joined == true) {
			if (GUILayout.Button("Red Team") ) 
				SpawnPlayerAt(location, 1);			

			if (GUILayout.Button("Blue Team") ) 
				SpawnPlayerAt(location, 2);

			if (GUILayout.Button("Random") ) 
				SpawnPlayerAt(location, Random.Range(1,3));
		}

		if (joined == false)
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}
	
	void OnJoinedLobby()
	{
		joined = true;
		PhotonNetwork.JoinRandomRoom();
	}
	
	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Can't join random room!");
		PhotonNetwork.CreateRoom(null);
	} 
	
	void OnJoinedRoom()
	{
		location = new Vector3 (x, y, z);
		//Vector3 location = new Vector3 (x, y, z);
		//SpawnPlayerAt (location);
	}
	
	void SpawnPlayerAt (Vector3 location, int teamID)
	{
		this.teamID = teamID;

		hasPickedTeam = true;

		player = PhotonNetwork.Instantiate ("Player - " + type.ToString(), location, Quaternion.identity, 0);
		standbyCamera.SetActive (false);

		getPlayerControls ();
		
		player.GetComponent<RaycastShooting> ().enabled = true;
		player.GetComponent<PlayerHealth> ().enabled = true;
		player.transform.FindChild ("Main Camera").gameObject.SetActive (true);
		player.GetComponentInChildren<Camera> ().enabled = true;
		player.GetComponent<PhotonView> ().RPC ("SetTeamID", PhotonTargets.AllBuffered, teamID);
	}

	void getPlayerControls ()
	{
		switch (type) {
			case PlayerType.Helicopter:
				player.GetComponent<HelicopterMovement> ().enabled = true;
				break;
			case PlayerType.Plane:
				player.GetComponent<PlaneMovement> ().enabled = true;
				break;
			case PlayerType.Truck:
				player.GetComponent<TruckMovement> ().enabled = true;
				break;
			case PlayerType.Tank:
				player.GetComponent<TankMovement> ().enabled = true;
				break;
			case PlayerType.Racecar:
				player.GetComponent<RacecarMovement> ().enabled = true;
				break;
		}
	}	
}