using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DefaultNamespace;
using UnityEngine;

public class SkeletonHealth : MonoBehaviour, EnemyHealth {
	[Range(1,5)]
	public int health;
	[Header("Sound")]
	private AudioSource audioSrc;
	public AudioClip takeDamageSound;
	public AudioClip dieSound;
	[Range(0, 1)] public float volume;

	private void start()
	{
		// first audio source is for health
		audioSrc = GetComponents<AudioSource>()[0];
	}
	
	


	public void takeDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			die();
		}
		audioSrc.PlayOneShot(takeDamageSound, volume);
	}

	public void takeDamage()
	{
		health--;
		if (health <= 0)
		{
			die();
		}
		audioSrc.PlayOneShot(takeDamageSound, volume);

	}


	void die()
	{
		audioSrc.PlayOneShot(dieSound, volume);
		Destroy(this.gameObject);
	}

	
	
}
