using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class TeamMember : Photon.MonoBehaviour {
	int _teamID = 0;

	
	public int teamID {
		get { return _teamID;}
	}
	
	[RPC] void SetTeamID(int id) {
		_teamID = id;
	}
	
	[RPC] 
	void PlayerRespawn(int team) {
		if (team == 1) {
			GameScore.redLivesLeft -= 1;
			if (GameScore.redLivesLeft <= 0){
				//CheckGameWon();
			}
				

		} else  {
			GameScore.blueLivesLeft -= 1;
			if (GameScore.blueLivesLeft <= 0){
				//CheckGameWon();
			}

		}
		
	}

	[RPC]
	public void levelIncrement(int level)
	{
		if (level == 1) {
			LvlSelecWait.bedroom += 1;
			print ("Inside Bedroom incrementor");
		}

			if (level == 2)
				LvlSelecWait.livingRoom += 1;
		if (level == 3)
			LvlSelecWait.kitchen += 1;
	}


//	void CheckGameWon() { 
//		if (GameScore.redLivesLeft <= 0) {
//			print ("Red Team Lost");
//			GameWon (1);
//		}
//		
//		if (GameScore.blueLivesLeft <= 0) {
//			print ("Blue Team Lost");
//			GameWon (2);
//		}
//	}
//	
//	void GameWon(int teamDeath) {
//		if (teamDeath == 1) {
//			resetGame();
//		} else {
//			resetGame();
//		}
//	}
//	
//	void resetGame()
//	{
//		GameScore.redLivesLeft = GameScore.teamLives;
//		GameScore.blueLivesLeft = GameScore.teamLives;
//		//GaneScore.CharacterSelection.SetActive (true);
//		GameScore.inGameUI.SetActive (false);
//	}
}
