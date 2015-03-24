#pragma strict

 var health = 100;

function Start () {
	
}

function Update () {
	
	if (health <= 0)
	{
		Dead();
	}
}

function ApplyDamage(TheDamage : int)
{
	health -= TheDamage;
}

function Dead()
{
	Destroy (gameObject);
}





