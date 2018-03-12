using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JonahController : MonoBehaviour
{
	[Header("Player Settings")]
	public int Health;
	public float Speed;

	[Header("Jump")]
	public Transform RayCastPosition;
	public float RayCastRadius;
	public LayerMask JumpLayerMask;
	public float JumpForce;

	private Rigidbody2D _rigidbody2D;
	// Use this for initialization
	void Start ()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_rigidbody2D.velocity = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update ()
	{

		float horizontalMovementAxis = Input.GetAxis("Horizontal");
		_rigidbody2D.velocity = new Vector2(Speed * horizontalMovementAxis, _rigidbody2D.velocity.y);

		bool isGrounded = Physics2D.OverlapCircle(RayCastPosition.position, RayCastRadius, JumpLayerMask);
		if (isGrounded && Input.GetButtonDown("Jump"))
		{
			_rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
			isGrounded = false;
		}

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Pickup"))
		{
			other.gameObject.SetActive(false);
		}
	}
}
