using UnityEngine;
using System.Collections;

public class RaycastShooting : MonoBehaviour {

	public GameObject bulletHolePrefab; // bullet hole prefab to instantiate
	public PlayerHealth health;
	public int damagePerBullet = 100;

	private Ray firedRay; // the ray that will be shot
	private RaycastHit hit; // variable to hold the object that is hit


	// Use this for initialization
	void Start () {
		Debug.Log("Start time on RaycastShooting:" + Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		if (firing ()) {
			centerScreenAndFire ();
			checkForCollisions ();
		}
	}

	static bool firing ()
	{
		return Input.GetButtonDown ("Fire1");
	}

	void centerScreenAndFire ()
	{
		// The Vector2 class holds the position for a point with only x and y coordinates
		// The center of the screen is calculated by dividing the width and height by half
		Vector2 screenCenterPoint = new Vector2 (Screen.width / 2, Screen.height / 2);
		// The method ScreenPointToRay needs to be called from a camera
		// Since we are using the MainCamera of our scene we can have access to it using the Camera.main
		firedRay = Camera.main.ScreenPointToRay (screenCenterPoint);
	}

	void checkForCollisions ()
	{
		if (collision ()) {
			// A collision was detected please deal with it
			positionBulletHole ();
			rotateBulletHole ();
			placeBulletHole ();
			print (hit.collider.transform.gameObject.name);
			try {
				updateHealth ();
			}
			catch {
			}
		}
	}

	bool collision ()
	{
		return Physics.Raycast (firedRay, out hit, Camera.main.farClipPlane);
	}

	static void positionBulletHole ()
	{
		// We need a variable to hold the position of the prefab
		// The point of contact with the model is given by the hit.point
		//Vector3 bulletHolePosition = hit.point + hit.normal * 0.01f;
	}

	static void rotateBulletHole ()
	{
		// We need a variable to hold the rotation of the prefab
		// The new rotation will be a match between the quad vector forward axis and the hit normal
		//Quaternion bulletHoleRotation = Quaternion.FromToRotation(-Vector3.right, hit.normal);
	}

	static void placeBulletHole ()
	{
		//GameObject hole = (GameObject)GameObject.Instantiate(bulletHolePrefab, bulletHolePosition, bulletHoleRotation);
	}

	void updateHealth ()
	{
		health = hit.collider.transform.gameObject.GetComponent<PlayerHealth> ();
		health.GetComponent<PhotonView> ().RPC ("ChangeHealth", PhotonTargets.All, damagePerBullet);
	}
}
