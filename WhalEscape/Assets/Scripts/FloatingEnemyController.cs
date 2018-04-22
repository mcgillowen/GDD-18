using System;
using UnityEngine;

using Random = UnityEngine.Random; 

public class FloatingEnemyController : MonoBehaviour
{

	[Header("Sinusoidal Movement")]
	public float Amplitude;
	public float Angle;
	public float Speed;
	public float MovementRadius;

	[Header("Starting Position")]
	public Transform StartPosition;

	private float _amplitude;
	private float _speed;
	// Use this for initialization
	void Start ()
	{
		transform.position = StartPosition.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		var positionX = transform.position.x;
		var positionY = transform.position.y;

		_amplitude = Random.Range(0f, Amplitude);

		if (StartPosition.position.x + MovementRadius < positionX + Speed || 
		    StartPosition.position.x - MovementRadius > positionX + Speed)
		{
			Speed *= -1;
		}
		
		
		_speed = Random.Range(0f, Speed);

		positionX += _speed;
		positionY += _amplitude * (float) Math.Sin(Angle * positionX);

		transform.position = new Vector3(positionX, positionY, transform.position.z);
	}
}
