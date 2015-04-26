using UnityEngine;
using System.Collections;

public class RaycastShooting : MonoBehaviour {

	public GameObject bulletHolePrefab;
	public PlayerHealth health;
	public float reloadTimer = 0;
	public int damagePerBullet = 100;
	public int bullets = 32;

	private Transform shootPos;	
	private RaycastHit hit; // variable to hold the object that is hit
	private Ray firedRay; // the ray that will be shot
	private bool canShoot = true;
	//private bool reload = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		if (HoldingFireButton ()) {
			Fire ();
		}
	}
	
	void Update() {
		print ("Time to reload:" + reloadTimer);
		if (reloadTimer > 0) {
			reloadTimer -= Time.deltaTime;
			RespawnIfAble ();
		} 
		
		if (bullets <= 0 && reloadTimer <= 0) {
			reloadTimer = 5;
		}
	}

	void RespawnIfAble ()
	{
		if (reloadTimer <= 0) {
			//reload = true;
			bullets = 32;
			reloadTimer = 0;
			print (bullets);
		}
	}

	static bool HoldingFireButton () {
		return Input.GetButton ("Fire1");
	}

	void Fire () {
		if (canShoot && bullets > 0) {
			print ("Firing");
			centerScreenAndFire ();
			checkForCollisions ();
			bullets -= 1;
			canShoot = false;
			print ("Bullets: " + bullets);
			StartCoroutine (Wait (0.1F));
		}
	}

	void centerScreenAndFire () {
		// The Vector2 class holds the position for a point with only x and y coordinates
		// The center of the screen is calculated by dividing the width and height by half
		Vector2 screenCenterPoint = new Vector2 (Screen.width / 2, Screen.height / 2);
		// The method ScreenPointToRay needs to be called from a camera
		// Since we are using the MainCamera of our scene we can have access to it using the Camera.main
		firedRay = Camera.main.ScreenPointToRay (screenCenterPoint);
	}

	void checkForCollisions () {
		if (collision ()) {
			placeBulletHole ();
			print ("Hit " + hit.collider.transform.gameObject.name+ "!");

			try {
				updateHealth ();
			}
			catch {
				Debug.Log("Couldn't update health!");
			}
		}
	}

	bool collision () {
		return Physics.Raycast (firedRay, out hit, Camera.main.farClipPlane);
		
	}
	
	void placeBulletHole () {
		// We need a variable to hold the position of the prefab
		// The point of contact with the model is given by the hit.point
		Vector3 bulletHolePosition = hit.point + hit.normal * 0.01f;
		
		// We need a variable to hold the rotation of the prefab
		// The new rotation will be a match between the quad vector forward axis and the hit normal
		Quaternion bulletHoleRotation = Quaternion.FromToRotation(-Vector3.right, hit.normal);
		
		GameObject.Instantiate(bulletHolePrefab, bulletHolePosition, bulletHoleRotation);
	}
	
	void updateHealth () {
		health = hit.collider.transform.gameObject.GetComponent<PlayerHealth> ();
		
		TeamMember tm = hit.collider.transform.gameObject.GetComponent<TeamMember> ();
		TeamMember myTm = this.GetComponent<TeamMember> ();
		
		
		if (tm == null || tm.teamID == 0 || myTm ==null || myTm.teamID == 0 || 
		    tm.teamID != myTm.teamID)
			health.GetComponent<PhotonView> ().RPC ("ChangeHealth", PhotonTargets.AllBuffered, damagePerBullet);
	}
	
	IEnumerator Wait (float waitTime) {
		yield return new WaitForSeconds(waitTime);
		canShoot = true;
	}
}
