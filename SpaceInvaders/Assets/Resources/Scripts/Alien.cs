using UnityEngine;
using System.Collections;

public class Alien : MonoBehaviour {

	public AudioClip AlienFire;
	public AudioClip GameOver;
	public float speed = 1.0f;
	public GameObject AlienBullet;
	public float minShootDelay = 3.0f;
	public float maxShootDelay = 7.0f;
	private Vector2 target;
	private float nextShootTime = 0.0f;

	// Use this for initialization
	void Start () {
		this.target = Vector2.zero;
		this.nextShootTime = Random.Range(minShootDelay, maxShootDelay);
		this.transform.LookAt(Vector3.zero, Vector3.left);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currentPosition = this.transform.position;
		Vector2 newPosition = Vector2.MoveTowards(currentPosition, this.target, speed * Time.deltaTime);
		this.transform.position = newPosition;

		if (Time.time > nextShootTime) {
			GameObject alienShot = (GameObject)Instantiate(AlienBullet, this.transform.position, this.transform.rotation);
			audio.clip = AlienFire;
			audio.Play();
			nextShootTime = Time.time + Random.Range(minShootDelay, maxShootDelay);
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			AudioSource.PlayClipAtPoint(GameOver, transform.position);
			GameObject.Destroy(collision.gameObject);
			GameObject.Destroy(this.gameObject);
		} else if (collision.gameObject.tag == "TheCheese") {
			AudioSource.PlayClipAtPoint(GameOver, transform.position);
			GameObject.Destroy(collision.gameObject);
		}
	}
}
