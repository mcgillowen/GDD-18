using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public enum GameState
	{
		Development,
		Production
	}
	
	[Header("Player Settings")]
	public int PlayerHealth = 2;
	public float PlayerSpeed = 2f;
	public int HitAmount = 3;
	public float HitDistance = 0.5f;

	[Header("Enemy Settings")]
	public GameObject[] EnemyTypes;

	[Header("Game Settings")]
	public Level[] Levels = new Level[0];
	public GameState CurrentGameState = GameState.Development;


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
