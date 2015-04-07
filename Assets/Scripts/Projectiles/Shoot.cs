using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	public Rigidbody projectile;
	public Transform shotPos;
	public float shotForce = 5f;
	public float moveSpeed = 0.5f;
	
	
	void Update ()
	{
		//float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
		//float v = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
		
		//transform.Translate(new Vector3(h, v, 0f));
		
		if(Input.GetButtonUp("Fire1"))
		{
			Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
			shot.AddForce(shotPos.forward * shotForce);
		}
	}
}