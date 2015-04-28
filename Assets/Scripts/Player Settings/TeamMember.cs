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
		} else  {
			GameScore.blueLivesLeft -= 1;
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
}
