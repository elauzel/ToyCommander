#pragma strict

var rotationsPerMinute : float = 10.0;

function Start () {

}


function Update(){
	transform.Rotate(6.0*rotationsPerMinute*Time.deltaTime,0,0);
}
    