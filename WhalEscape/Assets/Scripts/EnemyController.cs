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
	
	// Use this for initialization
	void Start () {
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_rigidbody2D.velocity = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {
		_rigidbody2D.velocity = new Vector2(Speed, _rigidbody2D.velocity.y);
		
		
		Vector3 scale = transform.localScale;
		
		if (_rigidbody2D.velocity.x > 0) {
			scale.x = -Mathf.Abs(scale.x);
		} else if (_rigidbody2D.velocity.x < 0) {
			scale.x = Mathf.Abs(scale.x);
		}
		transform.localScale = scale;
		Vector3 ray = new Vector3(-0.5f*transform.localScale.x, -0.5f);
		RaycastHit2D hit = Physics2D.Raycast(patrollRaycastPosition.position, ray);
		Debug.DrawRay(patrollRaycastPosition.position, ray);
		if (hit.collider != null) {
			if (hit.distance > 1 || hit.collider.CompareTag("Wall"))
			{
				Speed = -Speed;
			} 
			//Debug.Log(hit.collider.tag);
		}
		else
		{
			Speed = -Speed;
		}
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
//		if (other.CompareTag("Wall"))
//		{
//			Speed = -Speed;
//		}
	}
}

