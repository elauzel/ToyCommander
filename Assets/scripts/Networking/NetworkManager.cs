using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	private const string roomName = "CTIS 322";
	private RoomInfo[] roomsList;
	private RoomOptions roomOptions;
	private TypedLobby classLobby;
	// private string playerPrefab = "Player - Truck";

	// Use this for initialization
	void Start() {
		Debug.Log("Start time on NetworkManager:" + Time.deltaTime);
		PhotonNetwork.ConnectUsingSettings("0.1");
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("Update time on NetworkManager:" + Time.deltaTime);
	}
	
	void OnGUI() {
		roomOptions = createRoomOptions ();
		classLobby = createLobby ();

		if (PhotonNetwork.connected) {
			connect ();
		} else {
			displayConnectionState ();
		}
	}

	static RoomOptions createRoomOptions ()
	{
		RoomOptions roomOptions = new RoomOptions ();
		roomOptions.isOpen = true;
		roomOptions.isVisible = true;
		roomOptions.maxPlayers = 16;
		return roomOptions;
	}

	static TypedLobby createLobby ()
	{
		return new TypedLobby ("Class Lobby", LobbyType.Default);
	}

	static void displayConnectionState ()
	{
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}

	void connect ()
	{
		if (PhotonNetwork.room == null) {
			createRoom ();
			joinRoom ();
		}
	}

	void createRoom ()
	{
		if (startServerButton ()) {
			// PhotonNetwork.CreateRoom(roomName + System.Guid.NewGuid().ToString("N"), true, true, 5);
			PhotonNetwork.CreateRoom (roomName, roomOptions, classLobby);
		}
	}

	static bool startServerButton ()
	{
		return GUI.Button (new Rect (100, 100, 250, 100), "Start Server");
	}

	void joinRoom ()
	{
		if (roomsList != null) {
			for (int i = 0; i < roomsList.Length; i++) {
				joinFirstRoom (i);
			}
		}
	}

	void joinFirstRoom (int roomNumber)
	{
		if (roomExistsInList (roomNumber))
			PhotonNetwork.JoinRoom (roomsList [roomNumber].name);
	}

	bool roomExistsInList (int roomNumber)
	{
		return GUI.Button (new Rect (100, 250 + (110 * roomNumber), 250, 100), "Join " + roomsList [roomNumber].name);
	}
	
	void OnReceivedRoomListUpdate() {
		Debug.Log("Received Room List Update: " + Time.deltaTime);
		roomsList = PhotonNetwork.GetRoomList();
	}

	void OnJoinedRoom() {
		Debug.Log("Connected to Room: " + Time.deltaTime);
		spawnPlayer ();
	}

	static void spawnPlayer ()
	{
		//PhotonNetwork.Instantiate(playerPrefab, Vector3.up * 5, Quaternion.identity, 0);
		// PhotonNetwork.Instantiate(playerPrefab.name, Vector3.up * 5, Quaternion.identity, 0);
	}
}
