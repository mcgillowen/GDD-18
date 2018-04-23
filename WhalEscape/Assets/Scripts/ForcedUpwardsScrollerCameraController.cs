using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedUpwardsScrollerCameraController : MonoBehaviour
{
	public float SpeedY;
	public GameObject Jonah;
	private JonahController _jonahController;

	private Vector3 _cameraOffset;
	// Use this for initialization
	void Start ()
	{
		_jonahController = Jonah.GetComponent<JonahController>();
		_cameraOffset = new Vector3(0f, SpeedY, 0f);
	}
	
	// Update is called once per frame
	private void Update()
	{
		if (!IsVisibleToCamera(Jonah.transform))
		{
			_jonahController.Died();
		}
		
		_cameraOffset = new Vector3(Jonah.transform.position.x, transform.position.y + SpeedY, transform.position.z);
	}

	void LateUpdate ()
	{
		transform.position = _cameraOffset;
	}

	private static bool IsVisibleToCamera(Transform transform)
	{
		Vector3 visTest = Camera.main.WorldToViewportPoint(transform.position);
		//Debug.Log(visTest.ToString());
		return (visTest.x >= 0 && visTest.y >= 0) && (visTest.x <= 1 && visTest.y <= 1) && visTest.z >= 0;
	}
}
