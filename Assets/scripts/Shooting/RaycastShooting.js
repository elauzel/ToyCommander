#pragma strict

//var Effect : Transform;
var TheDamage = 100;

private var lineTransform : Vector3;
private var startTransform : Vector3;

function Start () {

}

function Update () {
 	var direction = transform.TransformDirection(Vector3.forward);
	var hit : RaycastHit;
	
	//if (Physics.Raycast (localOffset, direction, hit, 300)) {
	//	Debug.DrawLine (localOffset, hit.point, Color.cyan);
		
		// - send damage to object we hit - \\
	hit.collider.SendMessageUpwards("ApplyDamage", TheDamage, SendMessageOptions.DontRequireReceiver);



	//var hit :RaycastHit;
	//var ray : Ray = Camera.main.ScreenPointToRay(Vector3(Screen.width*0.5, Screen.height*0.5, 0));
	
	//if (Input.GetMouseButtonDown(0))
	//{
		//var particleClone = Instantiate(Effect, hit.point, Quaternion.LookRotation(hit.normal));
		//Destroy(particleClone.gameObject, 2);
		//hit.transform.SendMessage("ApplyDamage", TheDamage, SendMessageOptions.DontRequireReceiver);
		//Debug.DrawRay(startTransform, lineTransform, Color.red);
	//}
}

