using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public AudioClip AlienDeath;
	public AudioClip playerFireSound;
	public float speed = 1.0f;
	public int scoreValue;
	private Player player;
	private Vector3 target;

	// Use this for initialization
	void Start () {
		this.target = this.transform.position + transform.up * 30;
		audio.clip = playerFireSound;
		audio.Play();
		GameObject playerObject = GameObject.FindWithTag("Player");
		if (playerObject != null) {
			player = playerObject.GetComponent<Player>();
		}
		if (player == null) {
			Debug.Log("Kan ikke finde 'Player' scriptet!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = this.transform.position;
		Vector3 newPosition = Vector3.MoveTowards(currentPosition, this.target, speed * Time.deltaTime);
		this.transform.position = newPosition;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Alien") {
			AudioSource.PlayClipAtPoint(AlienDeath, transform.position);
			GameObject.Destroy(collision.gameObject);
			GameObject.Destroy(this.gameObject);
		} else {
			GameObject.Destroy(this.gameObject, 2);
		}
		player.AddScore(scoreValue);
	}
}
