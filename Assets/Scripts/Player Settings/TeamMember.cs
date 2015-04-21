using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TeamMember : Photon.MonoBehaviour {
	public Text score;
	int redLivesLeft = 3;
	int blueLivesLeft = 3;

	int _teamID = 0;

	public int teamID {
		get { return _teamID;}
	}
	[RPC]
	void SetTeamID(int id)
	{
		_teamID = id;
	}


	[RPC]
	void ChangeScore(int team)
	{
		if (team == 1) {
			redLivesLeft -=1;
		} else {
			blueLivesLeft -=1;
		}

		score.text = "Red Team: " + redLivesLeft + "     " + "Blue Team: " + blueLivesLeft;
	}



	void OnGUI()
	{
		

	}
}
