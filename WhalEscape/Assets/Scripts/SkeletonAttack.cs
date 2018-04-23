using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour {
	private float attackFreq = 1f;
	private float nextAttack = 0f;
	private GameObject player;
	private JonahController _jonahController;
	private GameObject _rayOriginObject;
	private Transform _rayOrigin;

	[Header("Attack")]
	[Range(0.0f, 1.0f)] public float HitDistance;
	
	[Header("Sound")]
	private AudioSource audioSrc;
	public AudioClip attackSound;
	[Range(0, 1)] public float volume;

	// Use this for initialization
	void Start () {
		// second audioSrc is for attack
		audioSrc = GetComponents<AudioSource>()[0];
		player = GameObject.FindGameObjectWithTag ("Player");
		_jonahController = player.GetComponent<JonahController>();
		_rayOriginObject = transform.Find("RayCastOrigin").gameObject;
		_rayOrigin = _rayOriginObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rayAttack = new Vector3(transform.localScale.x * -1f, 0f);
		RaycastHit2D attackHit = Physics2D.Raycast(_rayOrigin.position, rayAttack, HitDistance);
		Debug.DrawRay(_rayOrigin.position, rayAttack, Color.red);
		if (attackHit.collider != null)
		{
			if (attackHit.collider.CompareTag("Player") && attackHit.distance < 1 && nextAttack < Time.time)
			{
				Attack();
			}
		}	
	}
	
	void Attack()
	{
		audioSrc.PlayOneShot(attackSound, volume);
		nextAttack = Time.time + attackFreq;
		_jonahController.TakeDamage();
	}

}
