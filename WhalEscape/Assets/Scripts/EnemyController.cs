using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[Header("Enemy Settings")]
	public int Health;
	public float Speed;
	
	[Header("Patroll")]
	public Transform patrollRaycastPosition;
	
	private Rigidbody2D _rigidbody2D;
	private float attackFreq = 1f;
	private float nextAttack = 0f;
	private GameObject player;
	private JonahController _jonahController;
	
	// Use this for initialization
	void Start () {
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_rigidbody2D.velocity = Vector2.zero;
		player = GameObject.FindGameObjectWithTag ("Player");
		_jonahController = player.GetComponent<JonahController>();
	}
	
	// Update is called once per frame
	void Update () {

		



	}

	

}

