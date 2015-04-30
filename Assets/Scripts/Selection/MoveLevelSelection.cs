using UnityEngine;
using System.Collections;

public class MoveLevelSelection : Photon.MonoBehaviour {
	double originX = 530.4583;
	double originY = 58904.51;
	double originZ = -38604.6;
	
	int level_counter = 1;

	public GameObject levelSelection;
	public GameObject CharacterSelection;
	public GameObject waitingUI;


	// 1 = bedroom
	// 2 = kitchen
	// 3 = living room
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void  moveLeft() {
		if (level_counter > 1 && level_counter <= 3) {
			originX += 15;
			transform.position = new Vector3((float)originX,(float)originY,(float)originZ);
			level_counter -= 1;
			print (level_counter);
		}
	}
	
	
	void moveRight() {
		if (level_counter >= 1 && level_counter < 3) {
			originX -= 15;
			transform.position = new Vector3((float)originX,(float)originY,(float)originZ);
			level_counter += 1;
			print (level_counter);
		}
	}
	
	void OnGUI() {

			if (GUI.Button (new Rect (Screen.width / 2 + 100, Screen.height / 2, 100, 50), "Next")) {
				moveRight();
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 200, Screen.height / 2, 100, 50), "Back")) {
				moveLeft();
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 200, 100, 50), "Confirm")) {
				chosen();
			}
		}


	void chosen()
	{

		//NewNetwork nn = GameObject.FindObjectOfType<NewNetwork> ();
		//nn.mylevelChoice (level_counter);

		GameObject.Find ("Level - Level Select").SetActive (false);
		waitingUI.SetActive (true);
		//GetComponent<PhotonView>().RPC ("levelIncrement", PhotonTargets.AllBuffered, level_counter);
		if (NewNetwork.levelsPlayed == 1)
			LvlSelecWait.bedroom += 1;
		else
			if (NewNetwork.levelsPlayed == 2)
				LvlSelecWait.livingRoom += 1;
		else
			LvlSelecWait.kitchen += 1;
	}


}
