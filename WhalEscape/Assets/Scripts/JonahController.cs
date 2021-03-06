﻿using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.XR.WSA;

public class JonahController : MonoBehaviour
{

	private GameManager _gameManager;
	
	[Header("Player Settings")]
	public int Health;
	public float Speed;

	private int _initHealth;

	[Header("Jump")]
	public Transform JumpRayCastPosition;
	public float RayCastRadius;
	public LayerMask JumpLayerMask;
	public float JumpForce;

	[Header("Hit")]
	public Transform HitRayCastPosition;
	public int HitAmount = 3;
	public float HitDistance;

	private Rigidbody2D _rigidbody2D;
	private Collider2D _collider2D;

	private Animator _animator;

	private bool _hasStick = false;

	private GameObject _stick;
	
	[Header("Sounds")] 
	[Range(0, 1)] public float SoundVolume;
	public AudioClip TakeDamageSound;
	public AudioClip DieSound;
	public AudioClip AttackSound;
	public AudioClip JumpSound;

	private AudioSource _takeDamageAudioSrc;
	private AudioSource _attackAudioSrc;
	private AudioSource _moveAudioSrc;
	// Use this for initialization
	void Start ()
	{
		GameObject gameManagerObject = GameObject.Find ("GameManager");
		if (gameManagerObject != null)
			_gameManager = gameManagerObject.GetComponent<GameManager> ();
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_collider2D = GetComponent<BoxCollider2D>();
		_animator = GetComponent<Animator>();
		_rigidbody2D.velocity = Vector2.zero;
		if (_gameManager.CurrentDevState == GameManager.DevelopmentState.Production)
		{
			Health = _gameManager.PlayerHealth;
			Speed = _gameManager.PlayerSpeed;
			HitAmount = _gameManager.HitAmount;
			HitDistance = _gameManager.HitDistance;
		}
		
		_takeDamageAudioSrc = GetComponents<AudioSource>()[0];
		_attackAudioSrc = GetComponents<AudioSource>()[1];
		_moveAudioSrc = GetComponents<AudioSource>()[2];

		_initHealth = Health;
	}
	
	// Update is called once per frame
	void Update ()
	{	
		
		if (_gameManager != null && !_gameManager.CanPlay ()) {
			return;
		}
		
		float horizontalMovementAxis = Input.GetAxis("Horizontal");
		
		Vector2 velocity = new Vector2(horizontalMovementAxis * Speed, 0) {y = _rigidbody2D.velocity.y};
		_rigidbody2D.velocity = velocity;

		if (Mathf.Abs(horizontalMovementAxis) > 0)
		{
			_animator.SetBool("Walking", true);
		} else {
			_animator.SetBool("Walking", false);
		}
		
		Vector3 scale = transform.localScale;
		if (velocity.x > 0) {
			scale.x = Mathf.Abs(scale.x);
		} else if (velocity.x < 0) {
			scale.x = -Mathf.Abs(scale.x);
		}
		transform.localScale = scale;

		bool isGrounded = Physics2D.OverlapCircle(JumpRayCastPosition.position, RayCastRadius, JumpLayerMask) &&
		                  _rigidbody2D.velocity.y < 0.001;
		if (isGrounded && Input.GetButtonDown("Jump"))
		{
			_moveAudioSrc.PlayOneShot(JumpSound, SoundVolume);
			_rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
			_animator.SetTrigger("Jump");
		}

		if (transform.position.y < -2)
		{
			Health = 0;
			Died();
		}

		if (_hasStick && Input.GetButtonDown("Hit"))
		{
			Debug.Log("Hit with stick");
			var rayVec = new Vector2(transform.right.x * transform.localScale.x, 0f);
			var hit = Physics2D.Raycast(HitRayCastPosition.position, rayVec, HitDistance);
			_animator.SetTrigger("Attack");
			if (hit.collider && hit.collider.CompareTag("Enemy"))
			{
				_attackAudioSrc.PlayOneShot(AttackSound, SoundVolume);
				EnemyHealth enemyHealth = (EnemyHealth)hit.collider.GetComponent(typeof(EnemyHealth));
				enemyHealth.TakeDamage();
				HitAmount--;
			}
		}

		if (HitAmount < 1)
		{
			DropStick();
		}

		if (Health < 0)
		{
			
			Died();
		}

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Checkpoint"))
		{
			other.gameObject.SetActive(false);
			_gameManager.LevelFinished();
		}

		if (other.CompareTag("Stick"))
		{
			other.gameObject.SetActive(false);
			_hasStick = true;
			_stick = other.gameObject;
		}
	}

	private void DropStick()
	{
		_stick.transform.position = transform.position + new Vector3(-0.5f * transform.localScale.x, 0.5f, 0f);
		_stick.SetActive(true);
		_stick = null;
		_hasStick = false;
		HitAmount = 3;
	}

	public void TakeDamage()
	{
		_takeDamageAudioSrc.PlayOneShot(TakeDamageSound, SoundVolume);
		Health--;
		_animator.SetTrigger("Hit");
		Debug.Log("Jonah took 1 damage");
	}

	public void Died()
	{
		Debug.Log("Jonah Died");
		_animator.SetBool("Dead", true);
		Health = _initHealth;
		_gameManager.JonahDied();
	}
}
