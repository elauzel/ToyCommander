#pragma strict

// variables are held throughout game scenes and are changed by the scripts 
// 	'moveCharacterSelection' and 'moveLevelSelection' respectively.

//use these two static variables to hold choices of player in previoyus scenes

static var CharacterSelected : int = 0;
// 1 = truck
// 2 = tank
// 3 = plane
// 4 = heli
// 5 = racecar

static var LevelSelected : int = 0;
// 1 = bedroom
// 2 = kitchen
// 3 = living room

// Make this game object and all its transform children
	// survive when loading a new scene.
function Awake () {
	DontDestroyOnLoad (transform.gameObject);
}
	
function Update () {

	print (LevelSelected);
	print (CharacterSelected);
}