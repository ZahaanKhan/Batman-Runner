using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	// Centeral Game controller
	public static GameController gameController;

	// Game Text
	public Text scoreText;
	public GameObject gameOverText;
	public Text highScoreText;

	// Game tools
	public bool gameOver = false;
	public int gameScore = 0;
	public int highScore = 0;


	// apply Singleton Pattern to ensure only one game controller
	void Awake() {
		if (gameController == null) {
			gameController = this;
		} else {
			Destroy(gameObject);
		}

	}

	// Use this for initialization
	void Start () {
		highScore = PlayerPrefs.GetInt("HighScore", highScore);

		scoreText.text = "Score: 0" ;
		highScoreText.text = "High Score: " + highScore;

		gameOverText.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		incrementScore ();

		if (gameOver == true && Input.GetMouseButton(0)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		highScoreText.text = "High Score: " + highScore;
	}

	public void GameOver() {

		if (gameScore > highScore) {
			highScore = gameScore;
			highScoreText.text = "High Score: " + highScore;
			PlayerPrefs.SetInt ("HighScore", highScore);
		}

		gameOverText.SetActive (true);
		highScoreText.enabled = true;

		gameOver = true;
	}

	public void incrementScore() {
		if (!gameOver) {
			gameScore++;
			scoreText.text = "Score: " + gameScore;
		}
	}
}
