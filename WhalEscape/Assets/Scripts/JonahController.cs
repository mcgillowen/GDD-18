using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class JonahController : MonoBehaviour
{
	[Header("Player Settings")]
	public int Health;
	public float Speed;

	public int HitAmount = 3;
	public float HitDistance;

	[Header("Jump")]
	public Transform RayCastPosition;
	public float RayCastRadius;
	public LayerMask JumpLayerMask;
	public float JumpForce;

	private Rigidbody2D _rigidbody2D;

	private bool _hasStick = false;

	private GameObject _stick;
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

		if (_hasStick && Input.GetButtonDown("Hit"))
		{
			Debug.Log("Hit with stick");
			var hit = Physics2D.Raycast(transform.position, transform.forward, HitDistance);
			if (hit && hit.collider.CompareTag("Enemy"))
			{
				Debug.Log("Hit enemy with stick");
				Debug.Log(HitAmount.ToString());
				HitAmount--;
			}
		}

		if (HitAmount < 1)
		{
			DropStick();
		}

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Pickup"))
		{
			other.gameObject.SetActive(false);
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
		_stick.transform.position = transform.position + new Vector3(-1f, 0.5f, 0f);
		_stick.SetActive(true);
		_stick = null;
		_hasStick = false;
		HitAmount = 3;
	}

	public void takeDamage()
	{
		Health--;
		Debug.Log("Jonah took 1 damage");
	}
}
