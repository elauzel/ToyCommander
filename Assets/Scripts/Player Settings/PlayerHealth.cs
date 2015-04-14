using UnityEngine;
using System.Collections;

public class PlayerHealth : Photon.MonoBehaviour {
	public int health;
	public GameObject obj;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate()
	{
		Debug.Log("FixedUpdate time on PlayerHealth:" + Time.deltaTime);
	}

	// Update is called once per frame
	void Update () {
		// Debug.Log("Update time on PlayerHealth:" + Time.deltaTime);
	}

	[RPC]	public  void ChangeHealth(int amount)
	{
		print ("Health before change: " + health);
		health -= amount;
		print ("Health after change of " + amount + ": " + health);
		checkDeath ();
	}

	public void checkDeath()
	{
		if (health <= 0) Dead ();
	}

	void OnGUI()
	{
		if (GetComponent<PhotonView> ().isMine && gameObject.tag == "Player") {
			if (GUI.Button (new Rect (Screen.width -100, 0 , 100, 40), "Suicide")){
				Dead ();
			}
		}

	}


	 void Dead()
	{

		if (GetComponent<PhotonView> ().isMine) {
			if (gameObject.tag == "Player"){
				NewNetwork nn = GameObject.FindObjectOfType<NewNetwork>();

				nn.standbyCamera.SetActive(true);

				//GameObject.Find ("StandbyCamera").SetActive(true);
				nn.respawnTimer = 3f;
			}
		}
		print ("Died at " + Time.deltaTime + "!");
		
		//while ( obj.GetComponent("Body") != null)
			//obj.gameObject.collider.enabled = false;
		PhotonNetwork.Destroy (gameObject);


		//Component body = gameObject.GetComponent("Body"); 
		//body.GetComponent <MeshRenderer>().enabled = false;


		//if (!photonView.isMine) {
			//Destroy (gameObject);
		//} else {
			//if (GUI.Button(new Rect(10, 70, 50, 30), "Respawn"))
			//{

			//}
		//}

	}
}
