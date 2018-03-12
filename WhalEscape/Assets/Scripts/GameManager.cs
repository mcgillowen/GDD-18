using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[Header("Player Settings")]
	public int PlayerHealth;
	public int PlayerSpeed;

	[Header("Enemy Settings")]
	public GameObject[] EnemyTypes;

	[Header("Game Settings")]
	public Level[] Levels = new Level[0];


	private static GameManager _gameManager;
	
	// Use this for initialization
	void Awake () {
		if (_gameManager == null)
		{
			_gameManager = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
