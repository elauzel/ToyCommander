using UnityEngine;
using System.Collections;

public class PlayerHealth1 : MonoBehaviour {
	public int health = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
		{
			Dead();
		}
	}

	public static void ChangeHealth(int healthChange)
	{
		health = - healthChange;
	}

	public void Dead()
	{
		Destroy (gameObject);
	}
}
