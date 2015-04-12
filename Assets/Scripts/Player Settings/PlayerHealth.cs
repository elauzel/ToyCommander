using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int health;
	public GameObject network;

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

		if (GetComponent<PhotonView>().instantiationId == 0) {
			Destroy(gameObject);
		} else {
			PhotonNetwork.Destroy(gameObject);
		}
	}
}
