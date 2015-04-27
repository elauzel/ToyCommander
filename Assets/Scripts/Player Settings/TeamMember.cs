using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TeamMember : Photon.MonoBehaviour {
	public Text score;
	public int teamID = 0;

	int getTeamID {
		get { return teamID; }
	}

	[RPC] void SetTeamID(int id) {
		teamID = id;
	}

//	[RPC] void ChangeScore(int team) {
//		if (team == 1) {
//			redLivesLeft -=1;
//		} else {
//			blueLivesLeft -=1;
//		}
//
//		score.text = "Red Team: " + redLivesLeft + "     " + "Blue Team: " + blueLivesLeft;
//	}
//
//
//
//	void OnGUI() {
//
//	}
}
