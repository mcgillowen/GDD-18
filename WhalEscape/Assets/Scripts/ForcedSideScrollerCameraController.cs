using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	public float SpeedX = 0f;
	public float SpeedY = 0f;
	public GameObject Jonah;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3(transform.position.x + SpeedX, transform.position.y + SpeedY);
		if (!IsVisibleToCamera(Jonah.transform))
		{
			Debug.Log("Jonah is Dead");
		}
	}
	
	public static bool IsVisibleToCamera(Transform transform)
	{
		Vector3 visTest = Camera.main.WorldToViewportPoint(transform.position);
		Debug.Log(visTest.ToString());
		return (visTest.x >= 0 && visTest.y >= 0) && (visTest.x <= 1 && visTest.y <= 1) && visTest.z >= 0;
	}
}
