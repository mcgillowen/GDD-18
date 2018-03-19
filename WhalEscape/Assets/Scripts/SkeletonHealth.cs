using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SkeletonHealth : MonoBehaviour {
	[Range(1,5)]
	public int health;


	void takeDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			die();
		}
	}

	void takeDamage()
	{
		health--;
		if (health <= 0)
		{
			die();
		}
	}


	void die()
	{
		Destroy(this.gameObject);
	}

	
	
}
