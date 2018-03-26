using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour {
	private float attackFreq = 1f;
	private float nextAttack = 0f;
	private GameObject player;
	private JonahController _jonahController;
	private Transform _rayOrigin;
	[Header("Sound")]
	private AudioSource audioSrc;
	public AudioClip attackSound;
	[Range(0, 1)] public float volume;

	// Use this for initialization
	void Start () {
		// second audioSrc is for attack
		audioSrc = GetComponents<AudioSource>()[1];
		player = GameObject.FindGameObjectWithTag ("Player");
		_jonahController = player.GetComponent<JonahController>();
		_rayOrigin = transform.Find("RayCastOrigin").gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rayAttack = new Vector3(transform.localScale.x * -1f, 0f);
		RaycastHit2D attackHit = Physics2D.Raycast(_rayOrigin.position, rayAttack);
		Debug.DrawRay(_rayOrigin.position, rayAttack, Color.red);
		if (attackHit != null)
		{
			if (attackHit.collider.CompareTag("Player") && attackHit.distance < 1 && nextAttack < Time.time)
			{
				attack();
			}
		}	
	}
	
	void attack()
	{
		audioSrc.PlayOneShot(attackSound, volume);
		nextAttack = Time.time + attackFreq;
		_jonahController.takeDamage();
	}

}
