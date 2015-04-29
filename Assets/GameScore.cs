using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScore : Photon.MonoBehaviour {
	public int teamLives = 3;
	public static int redLivesLeft;
	public static int blueLivesLeft;
	private bool redWin = false;
	private bool blueWin = false;
	private Text score; 

	
	public  GameObject levelSelection;
	public  GameObject CharacterSelection;
	public  GameObject inGameUI;
	private float timerCalc;
	public int nextGameTimer = 5;
	string winner;
	bool activeTimer;

	// Use this for initialization
	void Start () {
		redLivesLeft = teamLives;
		blueLivesLeft = teamLives;
		score = GameObject.Find ("GameScore").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Red Team: " + redLivesLeft + "     " + "Blue Team: " + blueLivesLeft;
		CheckGameWon ();

		if (blueWin && !activeTimer) {
			winner = "Blue Team Wins!";
			timerCalc = nextGameTimer;
			activeTimer = true;
		}
		if (redWin && !activeTimer) {
			winner = "Red Team Wins!";
			timerCalc = nextGameTimer;
			activeTimer = true;
		}

		if (timerCalc > 0) {
			timerCalc -= Time.deltaTime;
			score.text = winner + "   Next Game: " + timerCalc;
			if (timerCalc < 0){
				score.text = winner + "   Next Game: " + 0;
				resetGame();
			}
		}

	}

	void CheckGameWon() { 
		if (redLivesLeft <= 0) {
			print ("Red Team Lost");
			GameWon (1);
		}
		
		if (blueLivesLeft <= 0) {
			print ("Blue Team Lost");
			GameWon (2);
		}
	}
	
	void GameWon(int teamDeath) {
		if (teamDeath == 1) {
			blueWin = true;
			//resetGame();
		} else {
			redWin = true;
			//resetGame();
		}
	}

	void resetGame()
	{
		NewNetwork.hasLevel = false;
		NewNetwork.hasCharacter = false;
		LvlSelecWait.bedroom = 0;
		LvlSelecWait.kitchen = 0;
		LvlSelecWait.livingRoom = 0;
		PhotonNetwork.LoadLevel (4);
//		redLivesLeft = teamLives;
//		blueLivesLeft = teamLives;
//		NewNetwork.hasCharacter = false;
//		NewNetwork.hasLevel = false;
//		CharacterSelection.SetActive (true);
//		inGameUI.SetActive (false);
//		PhotonNetwork.DestroyAll ();
	}

	void OnGUI()
	{

	}
}
