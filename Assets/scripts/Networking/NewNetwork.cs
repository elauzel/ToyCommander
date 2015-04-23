using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewNetwork : Photon.MonoBehaviour {
	public PlayerType type;
	public float x = 0;
	public float y = 0;
	public float z = 0;
	public float respawnTimer = 0;
	public GameObject standbyCamera;
	
	public Text score;


	private GameObject player;
	private Vector3 location ;
	private bool hasPickedTeam = false;
	private bool joined = false;
	private int teamID = 0;
	private int redLivesLeft = 3;
	private int blueLivesLeft = 3;
	private bool redWin = false;
	private bool blueWin = false;
	private bool changeScore = false;
	private bool firstSpawn = true;
	private PhotonView pv;
	int test = 0;

	// Use this for initialization
	void Start () {
		score.text = "Red Team: " + redLivesLeft + "     " + "Blue Team: " + blueLivesLeft;
		location = new Vector3 (x, y, z);
		Debug.Log("Start time on NewNetwork:" + Time.deltaTime);
		PhotonNetwork.ConnectUsingSettings("0.1");
	}
	
	// Update is called once per frame
	void Update () {


		if (respawnTimer > 0) {
			respawnTimer -= Time.deltaTime;
			
			if (respawnTimer <= 0) {
				OnJoinedRoom();
				SpawnPlayerAt(location, teamID);
				PhotonView photonView = this.photonView;
				}
				print (test);
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

		if (redWin == true) {
			score.text ="Red Team Wins!";
		}
		
		if (blueWin == true) {
			score.text ="Blue Team Wins!";
		}
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
	}
	
	void SpawnPlayerAt (Vector3 location, int teamID)
	{
		test +=1;

		this.teamID = teamID;
		
		hasPickedTeam = true;

		player = PhotonNetwork.Instantiate ("Player - " + type.ToString(), location, Quaternion.identity, 0);

		print (firstSpawn);
		if (firstSpawn == false) {
			photonView.RPC("PlayerRespawn",PhotonTargets.AllBuffered, teamID);
		} else {
			firstSpawn = false;
		}

		//PlayerRespawn (teamID);
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
	
	public enum PlayerType{
		Helicopter,Plane,Tank,Racecar,Truck
	}
	
	[RPC] public void PlayerRespawn(int team)
	{
		if (team == 1) {
			redLivesLeft -= 1;
			CheckGameWon();
		} else  {
			blueLivesLeft -= 1;
			CheckGameWon();
		}
		
		score.text = "Red Team: " + redLivesLeft + "     " + "Blue Team: " + blueLivesLeft;
	}
	
	void CheckGameWon()
	{
		if (redLivesLeft <= 0) {
			print ("Red Team Lost");
			GameWon (1);
		}
		
		if (blueLivesLeft <= 0) {
			print ("Blue Team Lost");
			GameWon (2);
		}
	}
	
	void GameWon(int teamDeath)
	{
		if (teamDeath == 1) {
			blueWin = true;
			//Application.LoadLevel ("Level1");
		} else {
			redWin = true;
			//Application.LoadLevel ("Level1");
		}
	}
}