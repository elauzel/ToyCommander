#pragma strict

var com: Vector3;
var rb: Rigidbody;

function Start() {
	// Expose center of mass to allow it to be set from the inspector.
	rb = GetComponent.<Rigidbody>();
	rb.centerOfMass = com;
}

function Update () {

}