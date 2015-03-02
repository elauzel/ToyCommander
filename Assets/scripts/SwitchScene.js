#pragma strict

function Start () {

}

function Update () {

}

function OnGUI () { 
	if (Input.GetMouseButtonDown(0))
  		Application.LoadLevel("01 - Game Menu"); 
}