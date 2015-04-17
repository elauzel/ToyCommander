#pragma strict

var originX = 8.039191;
var originY = 6.189883;
var originZ = -13.6179;

var vehicle_counter = 1;

// 1 = truck
// 2 = tank
// 3 = plane
// 4 = heli
// 5 = racecar

//connects to PersistentGameIdentifier object
function Start () {
 var persistGameID : GameObject = GameObject.Find("PesistentGameIdentifier");
 }

function  moveLeft() {
	if (originX > -50) {
		originX -= 15;
		transform.position = Vector3(originX,originY,originZ);
		vehicle_counter += 1;
	}
}


function moveRight() {
	if (originX < 0) {
		originX += 15;
		transform.position = Vector3(originX,originY,originZ);
		vehicle_counter -= 1;
	}
}
//updates static variable in PersistentGameIdentifier object
function Update() {
DontDestroyObject.CharacterSelected = vehicle_counter;
}