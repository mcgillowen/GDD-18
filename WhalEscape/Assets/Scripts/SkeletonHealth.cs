using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DefaultNamespace;
using UnityEngine;

public class SkeletonHealth : MonoBehaviour, EnemyHealth {
	[Range(1,5)]
	public int health;


	public void takeDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			die();
		}
	}

	public void takeDamage()
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
