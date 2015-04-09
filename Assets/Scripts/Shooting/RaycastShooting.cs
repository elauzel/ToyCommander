using UnityEngine;
using System.Collections;

public class RaycastShooting : MonoBehaviour {

	public GameObject bulletHolePrefab; // bullet hole prefab to instantiate
	public int damagePerBullet = 100;

	private Ray ray; // the ray that will be shot
	private RaycastHit hit; // variable to hold the object that is hit
	PlayerHealth healthC;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			// The Vector2 class holds the position for a point with only x and y coordinates
			// The center of the screen is calculated by dividing the width and height by half
			Vector2 screenCenterPoint = new Vector2(Screen.width/2, Screen.height/2);

			// The method ScreenPointToRay needs to be called from a camera
			// Since we are using the MainCamera of our scene we can have access to it using the Camera.main
			ray = Camera.main.ScreenPointToRay(screenCenterPoint);

			if(Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
			{	// A collision was detected please deal with it

				// We need a variable to hold the position of the prefab
				// The point of contact with the model is given by the hit.point
				Vector3 bulletHolePosition = hit.point + hit.normal * 0.01f;

				// We need a variable to hold the rotation of the prefab
				// The new rotation will be a match between the quad vector forward axis and the hit normal
				Quaternion bulletHoleRotation = Quaternion.FromToRotation(-Vector3.right, hit.normal);
				
				GameObject hole = (GameObject)GameObject.Instantiate(bulletHolePrefab, bulletHolePosition, bulletHoleRotation);

				print (hit.collider.transform.gameObject.name);

				try {
					healthC = hit.collider.transform.gameObject.GetComponent<PlayerHealth> ();
					//healthC.ChangeHealth(damagePerBullet);
					healthC.GetComponent<PhotonView>().RPC ("ChangeHealth",PhotonTargets.All,damagePerBullet);
				}
				catch
				{

				}
			}
		}
	}
}
