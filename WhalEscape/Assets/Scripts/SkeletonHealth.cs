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

	private void Start()
	{
		// first audio source is for health
		audioSrc = GetComponents<AudioSource>()[0];
	}


	public void TakeDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			Die();
		}
		audioSrc.PlayOneShot(takeDamageSound, volume);
	}

	public void TakeDamage()
	{
		health--;
		if (health <= 0)
		{
			Die();
		}
		audioSrc.PlayOneShot(takeDamageSound, volume);

	}


	void Die()
	{
		audioSrc.PlayOneShot(dieSound, volume);
		Destroy(gameObject);
	}
	
}
