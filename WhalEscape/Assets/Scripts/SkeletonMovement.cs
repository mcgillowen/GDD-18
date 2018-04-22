using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour {
	
	[Range(0, 5)]
	public float Speed;
	private Rigidbody2D _rigidbody2D;
	private Transform _rayOrigin;
	// Use this for initialization
	void Start () {
		_rayOrigin = transform.Find("RayCastOrigin").gameObject.transform;
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
		RaycastHit2D hit = Physics2D.Raycast(_rayOrigin.position, ray, 3f);
		
		//Debug.DrawRay(_rayOrigin.position, ray);
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
}
