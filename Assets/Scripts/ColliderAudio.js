#pragma strict

var crashSound : AudioClip; // set this to your sound in the inspector

function OnCollisionEnter (collision : Collision) { // next line requires an AudioSource component on this gameobject 
audio.PlayOneShot(crashSound); } 