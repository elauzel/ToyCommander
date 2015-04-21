@script AddComponentMenu ("Camera-Control/Mouse Look")
private enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
private enum AerialVehicle { yes = 0, no = 1 }

var player : GameObject;

var aerial = AerialVehicle.yes;
var axes = RotationAxes.MouseXAndY;

var sensitivityX : float = 15;
var sensitivityY : float = 15;

var minimumX : float = -360;
var maximumX : float = 360;

var minimumY : float = -60;
var maximumY : float = 60;

var rotationX : float = 0;
var rotationY : float = 0;

private var originalRotation : Quaternion;

function Update () {
	if (axes == RotationAxes.MouseXAndY) {
		xQuaternion = clampInput('x');
		yQuaternion = clampInput('y');
		transformRotation(xQuaternion * yQuaternion);
	}
	else if (axes == RotationAxes.MouseX) {
		xQuaternion = clampInput('x');
		transformRotation(xQuaternion);
	}
	else {
		yQuaternion = clampInput('y');
		transformRotation(yQuaternion);
	}
}

function Start () {
	if (rigidbody)
		rigidbody.freezeRotation = true;
	originalRotation = transform.localRotation;
}

function clampInput(axis : String) : Quaternion {
	if (axis == 'x') {
		rotationX += Input.GetAxis("Mouse X") * sensitivityX;
		rotationX = ClampAngle (rotationX, minimumX, maximumX);
		return Quaternion.AngleAxis (rotationX, Vector3.up);
	} else {
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		rotationY = ClampAngle (rotationY, minimumY, maximumY);
		return Quaternion.AngleAxis (rotationY, Vector3.left);
	}
}

static function ClampAngle (angle : float, min : float, max : float) : float {
	if (angle < -360.0)
		angle += 360.0;
	if (angle > 360.0)
		angle -= 360.0;
	return Mathf.Clamp (angle, min, max);
}

function transformRotation(quatern : Quaternion) {
	transform.localRotation = originalRotation * quatern;
	transformIfAerial(quatern);
}

function transformIfAerial(quatern : Quaternion) {
	if (AerialVehicle.yes) {
		player.rigidbody.AddRelativeTorque(Vector3(rotationX * Input.GetAxis ("Horizontal"), rotationY * Input.GetAxis ("Vertical"), 0));
	}
}