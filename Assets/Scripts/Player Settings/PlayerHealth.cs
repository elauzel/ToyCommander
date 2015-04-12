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


	 void Dead()
	{


		print ("Died at " + Time.deltaTime + "!");

		//String name = gameObject.name;
		while ( obj.GetComponent("Body") != null)
		   
			
			obj.gameObject.collider.enabled = false;
			


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
