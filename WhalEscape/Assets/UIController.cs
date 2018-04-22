using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	
	private static GameManager _gameManager;
	private GameManager.LevelState _levelState;
	private Vector3 _playerStartPosition;
	private bool _finishLevel;
	private bool _initLevel;
	
	private GameObject _startPanel;
	private GameObject _uiPanel;
	private GameObject _diePanel;
	private GameObject _player;
	private Text _startText;
	private Text _dieText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
