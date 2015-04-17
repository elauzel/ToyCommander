#pragma strict

var originX = 11.90448;
var originY = -10.12773;
var originZ = -20.35211;

var world_counter = 1;

// 1 = bedroom
// 2 = kitchen
// 3 = living room

//connects to PersistentGameIdentifier object
function Start () {
 var persistGameID : GameObject = GameObject.Find("PesistentGameIdentifier");
 }
 
function moveLeft() {
	if (world_counter < 3) {
		originX -= 15;
		transform.position = Vector3(originX,originY,originZ);
		world_counter += 1;
	}
}


function moveRight() {
	if (world_counter > 1) {
		originX += 15;
		transform.position = Vector3(originX,originY,originZ);
		world_counter -= 1;
	}
}

//updates static variable in PersistentGameIdentifier object
function Update() {
DontDestroyObject.LevelSelected = world_counter;
}