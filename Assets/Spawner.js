#pragma strict

var thePrefab : GameObject;
var timer : float = 3.0;

function Start () {

	var instance : GameObject = Instantiate(thePrefab, transform.position, transform.rotation);

}

function Update () {

	timer-=Time.deltaTime;

	if(timer<=0){
		timer = 3.0;
		var instance : GameObject = Instantiate(thePrefab, transform.position, transform.rotation);
	}

}