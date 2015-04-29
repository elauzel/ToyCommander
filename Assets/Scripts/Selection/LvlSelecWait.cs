using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LvlSelecWait : MonoBehaviour {
	public static int bedroom;
	public static int livingRoom;
	public static int kitchen;
	public GameObject waitingUI;
	public GameObject inGameUI;

	private Text text;
	private Text countdownText;
	float countdown = 2;
	NewNetwork nn;

	// Use this for initialization
	void Start () {
		 nn = GameObject.FindObjectOfType<NewNetwork> ();
		text = waitingUI.GetComponent<Text>();
		countdownText = GameObject.Find ("Countdown").GetComponent<Text>();
		text.enabled = true;
		text.text = "Bedroom: " + bedroom + "   Living Room: " + livingRoom + "   Kitchen: " + kitchen;

	}
	
	// Update is called once per frame
	void Update () {
		if (countdown > 0) {
			text.text = "Bedroom: " + bedroom + "   Living Room: " + livingRoom + "   Kitchen: " + kitchen;
			countdown -= Time.deltaTime;
			countdownText.text = "Countdown: "+countdown;

		}

		if (countdown < 0) {
			countdownText.text = "Countdown: 0";


			if (NewNetwork.levelsPlayed == 2)// kitchen > livingRoom && kitchen > bedroom) {// kitchen wins
			
				nn.levelChosen (2);

			} else if (NewNetwork.levelsPlayed == 1) { // bedroom wins
				nn.levelChosen (1);

			} else {// living room wins
				nn.levelChosen (3);

			}
			waitingUI.SetActive (false);
			inGameUI.SetActive(true);

		}
		//





	void OnGUI()
	{
	}
}
