using UnityEngine;
using System.Collections;

public class PlayerHealth1 : MonoBehaviour {
	public int health;
	public GameObject network;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate()
	{
		print ("Update is called");
//		if (health < 1) {
//			print ("Is supposed to be dead");
//			Dead ();
//		} else {
//
//		}
	}
	// Update is called once per frame
	void Update () {



	}

	public  void ChangeHealth(int healthChange)
	{
		print ("Health Change happens here");
		health -= healthChange;
		print (health);
		checkDeath ();
	}

	public void checkDeath()
	{
		print ("Inside Check Death");
		if (health <= 0)
			print ("Inside If Statement WOOOOOOOOOOOOOOOOOOOOOOOOOOOOo");
		Dead ();
	}


	 void Dead()
	{
		print ("Supposed to be dead");

		if (GetComponent<PhotonView>().instantiationId == 0) {
			Destroy(gameObject);
		}
		else {
			PhotonNetwork.Destroy(gameObject);
		}

			

			
		}




//		NewNetwork other = network.GetComponent<NewNetwork>;
		//(NewNetwork) network.GetComponent<NewNetwork>;
		//other.OnPlayerDeath ();




}
