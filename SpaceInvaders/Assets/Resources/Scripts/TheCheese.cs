using UnityEngine;
using System.Collections;

public class TheCheese : MonoBehaviour {

	public GUIText restartText;
	public GUIText gameOverText;
	private bool gameOver;
	private bool restart;
	private int score;

	// Use this for initialization
	void Start () {
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver) {
			restartText.text = "Press 'Circle' to try again.";
			restart = true;
		}
		
		if (restart) {
			if (Input.GetButton("PS4_O")) {
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	public void GameOver () {
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
