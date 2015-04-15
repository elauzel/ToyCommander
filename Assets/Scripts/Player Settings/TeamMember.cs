using UnityEngine;
using System.Collections;

public class TeamMember : MonoBehaviour {

	int _teamID = 0;

	public int teamID {
		get { return _teamID;}
	}
	[RPC]
	void SetTeamID(int id)
	{
		_teamID = id;
	}
}
