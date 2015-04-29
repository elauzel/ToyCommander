using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewNetwork : Photon.MonoBehaviour {
	public PlayerType type;
	public GameObject characterSelectCamera;
	public GameObject bedroomStandbyCamera;
	public GameObject livingRoomStandbyCamera;
	public GameObject kitchenStandbyCamera;
	public GameObject currentStandbyCamera;
	public float x = 0;
	public float y = 0;
	public float z = 0;
	public float respawnTimer = 0;
	
	private GameObject player;
	private Vector3 location ;
	private int teamID = 0;
	private bool hasPickedTeam = false;
	private bool joined = false;
	private bool firstSpawn = true;
	private float retryTimer = 2;
	private bool connected = false;
	int character;
	int level;
	public static bool hasCharacter;
	public static bool hasLevel;
	int mylevel;


	
	
	public enum PlayerType {

		Helicopter,Plane,Tank,Racecar,Truck
	}
	
	// Use this for initialization
	void Start () {
		location = new Vector3 (x, y, z);
		Debug.Log("Start time on NewNetwork:" + Time.deltaTime);
		PhotonNetwork.ConnectUsingSettings("0.1");
	}
	
	// Update is called once per frame
	void Update () {
		if (!connected)
			retryTimer -= Time.deltaTime;
		if (retryTimer <= 0) {
			PhotonNetwork.Disconnect ();
			print ("Tried to disconnect"); 
			retryTimer = 2; 
			PhotonNetwork.ConnectUsingSettings ("0.1");  
			print ("Tried to reconnect"); 
		}
		if (respawnTimer > 0) {
			respawnTimer -= Time.deltaTime;
			RespawnIfAble ();
		}
	}

	public void CharacterChosen(int character)
	{
		this.character = character;
		print("Character Chosen" + character);
		if (character == 1) 
			type = PlayerType.Truck;
		else if (character == 2)
			type = PlayerType.Tank;
		else if (character == 3)
			type = PlayerType.Plane;
		else if (character == 4)
			type = PlayerType.Helicopter;
		else
			type = PlayerType.Racecar;

		hasCharacter = true;
		//tempSpawn ();
		
	}

//	public void mylevelChoice(int level)
//	{
//		mylevel = level;
//	}

	public void levelChosen(int level)
	{
		this.level = level;
		print("Level Chosen: " + level);
		if (level == 1) {
			location = new Vector3((float)62.07,(float)5.67,(float)41.83);
			currentStandbyCamera = bedroomStandbyCamera;
		}
		if (level == 2) {
			location = new Vector3((float)-27.85,(float)20.571,(float)-298.65);
			currentStandbyCamera = kitchenStandbyCamera;
		}
		if (level == 3) {
			location = new Vector3((float)102.7,(float)10.82,(float)-131.86);
			currentStandbyCamera = livingRoomStandbyCamera;
		}
		hasLevel = true;
		currentStandbyCamera.SetActive (true);
		
	}
	
	
	void RespawnIfAble () {
		if (respawnTimer <= 0) {
			OnJoinedRoom ();
			SpawnPlayerAt (location, teamID); 
		}
	}	
	
	void OnGUI() {

		if (hasCharacter && hasLevel && hasPickedTeam == false && joined == true) {
			ShowTeamButtons ();
		}
		
		if (joined == false)
			GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}
	
	void ShowTeamButtons () {
		if (GUILayout.Button ("Red Team"))
			SpawnPlayerAt (location, 1);
		if (GUILayout.Button ("Blue Team"))
			SpawnPlayerAt (location, 2);
		if (GUILayout.Button ("Random"))
			SpawnPlayerAt (location, Random.Range (1, 3));
	}
	
	void OnJoinedLobby() {
		joined = true;
		connected = true;
		PhotonNetwork.JoinRandomRoom();
	}
	
	void OnPhotonRandomJoinFailed() {
		Debug.Log("Can't join random room!");
		PhotonNetwork.CreateRoom(null);
	} 
	
	void OnJoinedRoom() {
		//location = new Vector3 (x, y, z);
	}

//	void tempSpawn ()
//	{
//		player = PhotonNetwork.Instantiate ("Player - " + type.ToString(), location, Quaternion.identity, 0);
//		player.GetComponent<PhotonView> ().RPC("levelIncrement",PhotonTargets.AllBuffered,mylevel);
//		PhotonNetwork.Destroy (player);
//	}
	
	void SpawnPlayerAt (Vector3 location, int teamID) {
		this.teamID = teamID;
		hasPickedTeam = true;
		player = PhotonNetwork.Instantiate ("Player - " + type.ToString(), location, Quaternion.identity, 0);
		
		if (firstSpawn == false) {
			player.GetComponent<PhotonView> ().RPC("PlayerRespawn",PhotonTargets.AllBuffered, teamID);
			
		} else {
			firstSpawn = false;
		}
		
		currentStandbyCamera.SetActive (false);
		getPlayerControls ();
		
		player.GetComponent<RaycastShooting> ().enabled = true;
		player.GetComponent<PlayerHealth> ().enabled = true;
		player.transform.FindChild ("Main Camera").gameObject.SetActive (true);
		player.GetComponentInChildren<Camera> ().enabled = true;
		player.GetComponent<PhotonView> ().RPC ("SetTeamID", PhotonTargets.AllBuffered, teamID);
		
		//		if (teamID == 1)
		//			player.transform.FindChild ("RedTeam").gameObject.SetActive (true);
		//		else
		//			player.transform.FindChild ("BlueTeam").gameObject.SetActive (true);
	}
	
	void getPlayerControls () {
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