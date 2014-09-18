using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GUIText ScoreGUI;
	public GUIText restartText;
	public GUIText gameOverText;
	public float cooldown;
	public GameObject Bullet;
	private float nextFire = 1.0f;
	private bool fireReload = false;
	private bool gameOver;
	private bool restart;
	private int score;

	// Use this for initialization
	void Start () {
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";
		score = 0;
		UpdateScore();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;

		if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0) {
			transform.position = new Vector2(pos.x + Input.GetAxis("Horizontal"), pos.y + Input.GetAxis("Vertical"));
		}
		
		if ((Input.GetKey(KeyCode.Space) || Input.GetButton("PS4_L1") || Input.GetButton("PS4_R1")) && Time.time >= nextFire) {
			Shot();
		}

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

	bool Shot() {
		if (Time.time >= nextFire) {
			nextFire = Time.time + cooldown;
			fireReload = true;
			GameObject shot = (GameObject)Instantiate(Bullet, this.transform.position, this.transform.rotation);
		}
		return fireReload;
	}

	public void AddScore (int newScoreValue) {
		score += newScoreValue;
		UpdateScore(); 
	}
	
	void UpdateScore () {
		ScoreGUI.text = "Score: "+ score;
	}

	public void GameOver () {
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
