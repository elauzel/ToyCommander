using UnityEngine;
using System.Collections;

public class MoveCharacterSelection : MonoBehaviour {
	double originX = 210.1067;
	double originY = 57555.98;
	double originZ = -39992.7;
	
	int vehicle_counter = 1;

	public GameObject levelSelection;
	public GameObject CharacterSelection;

	// 1: truck
	// 2: tank
	// 3: plane
	// 4: heli
	// 5: racecar

	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void  moveLeft() {
		if (vehicle_counter > 1 && vehicle_counter <= 5) {
			originX += 15;
			 transform.position = new Vector3((float)originX,(float)originY,(float)originZ);
			vehicle_counter -= 1;
			print (vehicle_counter);
		}
	}
	
	
	void moveRight() {
		if (vehicle_counter >= 1 && vehicle_counter < 5) {
			originX -= 15;
			transform.position = new Vector3((float)originX,(float)originY,(float)originZ);
			vehicle_counter += 1;
			print (vehicle_counter);
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
		NewNetwork nn = GameObject.FindObjectOfType<NewNetwork> ();
		nn.CharacterChosen (vehicle_counter);
		levelSelection.SetActive (true);
		CharacterSelection.SetActive (false);

	
	}
}
