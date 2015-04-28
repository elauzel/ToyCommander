using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScore : MonoBehaviour {
	public static int redLivesLeft = 3;
	public static int blueLivesLeft = 3;
	private bool redWin = false;
	private bool blueWin = false;
	private Text score; 

	// Use this for initialization
	void Start () {
		score = GameObject.Find ("GameScore").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Red Team: " + redLivesLeft + "     " + "Blue Team: " + blueLivesLeft;
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
		} else {
			redWin = true;
		}
	}

	void OnGUI()
	{

	}
}
