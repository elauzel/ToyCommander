#pragma strict

var Effect : Transform;
var TheDamage = 100;

private var lineTransform : Vector3;
private var startTransform : Vector3;

function Start () {

}

function Update () {

	var hit :RaycastHit;
	var ray : Ray = Camera.main.ScreenPointToRay(Vector3(Screen.width*0.5, Screen.height*0.5, 0));
	
	if (Input.GetMouseButtonDown(0))
	{
		var particleClone = Instantiate(Effect, hit.point, Quaternion.LookRotation(hit.normal));
		//Destroy(particleClone.gameObject, 2);
		hit.transform.SendMessage("ApplyDamage", TheDamage, SendMessageOptions.DontRequireReceiver);
		//Debug.DrawRay(startTransform, lineTransform, Color.red);
	}
}

