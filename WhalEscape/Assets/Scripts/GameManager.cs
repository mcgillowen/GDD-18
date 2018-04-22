using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public enum DevelopmentState
	{
		Development,
		Production
	}

	public enum GameState
	{
		Start,
		Game,
		End
	}

	public enum LevelState
	{
		Start,
		Ready,
		End,
		Play
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

	public int CurrentLevel;
	public DevelopmentState CurrentDevState = DevelopmentState.Development;
	public GameState CurrentGameState = GameState.Game;


	private static GameManager _gameManager;
	private LevelState _levelState;
	private Vector3 _playerStartPosition;
	private bool _finishLevel;
	private bool _initLevel;

	private GameObject _canvas;
	private GameObject _startPanel;
	private GameObject _uiPanel;
	private GameObject _diePanel;
	private GameObject _player;
	private Text _startText;
	private Text _dieText;

	// Use this for initialization
	void Awake () {
		if (_gameManager == null)
		{
			_gameManager = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
		
		//just for playing the scene during debug
		if (CurrentGameState == GameState.Game) {
			CurrentLevel = 0;
			_initLevel = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		switch (CurrentGameState) {
			case GameState.Start:
				if (Input.GetButtonDown ("Hit")) {
					CurrentGameState = GameState.Game;
					CurrentLevel = 0;
					_initLevel = true;
					SceneManager.LoadScene (Levels[CurrentLevel].Name);
				}
				break;
			case GameState.Game:
				UpdateLevel ();
				break;
			case GameState.End:
				if (Input.GetButtonDown ("Hit")) {
					CurrentGameState = GameState.Start;
					SceneManager.LoadScene ("start_screen");
				}
				break;
		}
		
	}
	
	private void InitLevel () {
		if (CurrentGameState != GameState.Game)
			return;
		_canvas = GameObject.Find("UICanvas");
		_uiPanel = _canvas.transform.FindChild("UIPanel").gameObject;
		//_uiPanel = GameObject.Find ("UIPanel");
		_startPanel = _canvas.transform.FindChild("StartPanel").gameObject;
		//_startPanel = GameObject.Find ("StartPanel");
		GameObject startTextGameObject = GameObject.Find ("StartText");
		if (startTextGameObject != null)
			_startText = startTextGameObject.GetComponent<Text> ();
		GameObject canvas = GameObject.Find("UICanvas");
		_diePanel = canvas.transform.FindChild("DiePanel").gameObject;
		// _diePanel = GameObject.Find ("DiePanel");
		
		//Debug.Log(_diePanel.ToString());
		_diePanel.SetActive (true);
		if (_diePanel != null)
			_dieText = GameObject.Find ("DieText").GetComponent<Text> ();
		_player = GameObject.Find ("Jonah");
		if (_player != null)
			_playerStartPosition = _player.transform.position;
		else
			Debug.LogError ("Object with 'Player' name not found");
		
		InitLevelParameters(); 
		
	}

	private void InitLevelParameters()
	{
		_levelState = LevelState.Ready;
		if (_uiPanel != null)
			_uiPanel.SetActive (false);
		if (_startPanel != null)
			_startPanel.SetActive (true);
		if (_startText != null)
			_startText.gameObject.SetActive (true);
		if (_diePanel != null)
			_diePanel.SetActive (false);
		if (_player != null) {
			_player.transform.position = _playerStartPosition;
		    _player.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
		}
	}
	
	public bool CanPlay(){
		return CurrentGameState == GameState.Game && _levelState == LevelState.Play;
	}
	
	private void UpdateLevel(){
		if (_initLevel) {
 			InitLevel ();
			_initLevel = false;
		}
		switch (_levelState) {
			case LevelState.Ready:
				if (Input.GetButtonDown ("Hit")) {
					_levelState = LevelState.Start;
					_startPanel.SetActive (false);
					_startText.gameObject.SetActive (true);
				}
				break; 
			case LevelState.Start:
				_levelState = LevelState.Play;
				_uiPanel.SetActive(true);
				break;
			case LevelState.Play:
				break;
			case LevelState.End:
				if (Input.GetButtonDown ("Hit")) {
					if (_finishLevel) {
						_initLevel = true;
						CurrentLevel++;
						if (CurrentLevel < Levels.Length) {
							SceneManager.LoadScene (Levels[CurrentLevel].Name);
						} else {
							CurrentGameState = GameState.End;
							SceneManager.LoadScene ("end_screen");
						}
					} else {
						InitLevelParameters ();
					}
				}
				break;
		}
	}
	
	private void Win ()
	{
		InitLevel();
		_dieText.text = "You finished the level!\n\n<size=40>press jump button to continue</size>";
		_diePanel.SetActive (true);
		_levelState = LevelState.End;
		_uiPanel.SetActive (false);
		_finishLevel = true;
	}
	
	private void Lose () {
		//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		// InitLevel();
		_dieText.text = "Jonah died!\n\n<size=40>press jump button to continue</size>";
		_diePanel.SetActive (true);
		_levelState = LevelState.End;
		_uiPanel.SetActive (false);
		_finishLevel = false;
		
	}

	public void LevelFinished()
	{
		Win();
	}

	public void JonahDied()
	{
		Lose();
	}
}
