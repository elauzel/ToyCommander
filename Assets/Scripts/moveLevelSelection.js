#pragma strict

var originX = 11.90448;
var originY = -10.12773;
var originZ = -20.35211;

var World_counter = 1;

// 1 = bedroom
// 2 = kitchen
// 3 = living room


function  moveLeft(){
	if (World_counter < 3){
		originX -= 15;

transform.position = Vector3(originX,originY,originZ);

World_counter += 1;

}
}


function moveRight(){
	if (World_counter > 1){
		originX += 15;

transform.position = Vector3(originX,originY,originZ);

World_counter -= 1;

}
}