using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RaycastShooting : MonoBehaviour {
	
	public GameObject bulletHolePrefab; // bullet hole prefab to instantiate
	public PlayerHealth health;
	public float reloadTimer = 0;
	public int damagePerBullet = 10;
	public float totalBullets = 128;
	public float bulletsDisplayed = 128;
	public float bullets = 32;
	private float totalBulletsCalc;
	
	private Transform shootPos;
	private Ray firedRay; // the ray that will be shot
	private RaycastHit hit; // variable to hold the object that is hit
	private GameObject AmmoBox;
	private Vector3 position;
	private bool canShoot = true;
	public AudioClip machineGunFire;
	public AudioClip machineGunReload;
	private Image ammoVisual;
	private Text ammoText;
	
	// Use this for initialization
	void Start () {
		totalBulletsCalc = totalBullets;
		//fixes to ammo gui issues as well as null exception for ammo boxes with no shots fired
		ammoVisual = GameObject.Find ("VisualAmmo").GetComponent<Image>();
		ammoText = GameObject.Find("AmmoText").GetComponent<Text>();

		ammoVisual.fillAmount = totalBulletsCalc/160;
		ammoText.text = "Ammo: " + bullets + "/" + Mathf.Max(0,totalBullets-32);
	}
	
	void Update() {
		//print (reloadTimer);
		if (reloadTimer > 0) {
			reloadTimer -= Time.deltaTime;
			ReloadIfAble ();
		}
		
		if (bullets <= 0 && reloadTimer <= 0) {
			//audio.Stop();
			reloadTimer = 4;
		}


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (FireButtonHeld ()) {
			Fire ();
		}
	}	
	
	void playReload() {
		audio.clip = machineGunReload;
		audio.Play ();
	}

	void ReloadIfAble () {
		if (reloadTimer <= 0 && totalBullets > 0) {
			totalBullets -= 32;
			if (totalBullets > 0)
				bullets = 32;
			reloadTimer = 0;
			UpdateAmmoUI();
			print ("Bullets: " + bullets);
		}
	}
	
	static bool FireButtonHeld () {
		return Input.GetButton ("Fire1");
	}
	
	void Fire () {
		if (bullets == 0 && totalBullets > 0) {
			playReload();
		}

		if (canShoot && bullets > 0 && totalBullets > 0) {
			//print ("Shooting");
			centerScreenAndFire ();
			
			ammoVisual = GameObject.Find ("VisualAmmo").GetComponent<Image>();
			ammoText = GameObject.Find("AmmoText").GetComponent<Text>();
			
			audio.clip = machineGunFire;
			audio.Play ();
			
			checkForCollisions ();
			bullets -= 1;
			totalBulletsCalc -= 1;
			canShoot = false;
			
			UpdateAmmoUI();
			
			//print (bullets);
			StartCoroutine (Wait (0.1F));
		}
	}
	
	IEnumerator Wait (float waitTime) {
		
		yield return new WaitForSeconds(waitTime);
		audio.Stop ();
		canShoot = true;
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
			//print ("Hit " + hit.collider.transform.gameObject.name + "!");
			try {
				updateHealth ();
			} catch {
				//Debug.Log("Couldn't update health!");
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
		
		if (NotOnTeams (tm, myTm) || DifferentTeams (tm, myTm))
			health.GetComponent<PhotonView> ().RPC ("ChangeHealth", PhotonTargets.AllBuffered, damagePerBullet);
	}
	
	static bool NotOnTeams (TeamMember one, TeamMember two) {
		return one == null || one.teamID == 0 || two == null || two.teamID == 0;
	}
	
	static bool DifferentTeams (TeamMember one, TeamMember two) {
		return one.teamID != two.teamID;
	}
	
	void OnCollisionEnter(Collision collision) {
		AmmoBox = collision.gameObject;
		
		if(AmmoBox.tag == "AmmoBox"){
			PhotonNetwork.Destroy(AmmoBox);
			position = AmmoBox.transform.position;
			totalBullets = 160;
			bullets = 32;
			totalBulletsCalc = totalBullets;
			UpdateAmmoUI();
			Invoke("ItemReinstantiate", 15.0f);
		}
	}
	
	void ItemReinstantiate () {		
		PhotonNetwork.Instantiate("Powerup - AmmoBox", position, Quaternion.Euler(0,0,90),0);
		//print ("Item has been Instantiated");
	}
	
	void UpdateAmmoUI() {
		ammoVisual.fillAmount = totalBulletsCalc/160;
		ammoText.text = "Ammo: " + bullets + "/" + Mathf.Max(0,totalBullets-32);

	}
}