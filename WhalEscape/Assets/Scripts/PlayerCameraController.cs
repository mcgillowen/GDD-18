using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{

	public GameObject Jonah;

	private Vector3 _cameraOffset;
	
	// Use this for initialization
	void Start ()
	{
		_cameraOffset = transform.position - Jonah.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = Jonah.transform.position + _cameraOffset;
	}
}
