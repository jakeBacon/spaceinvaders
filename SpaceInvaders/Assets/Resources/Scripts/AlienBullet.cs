using UnityEngine;
using System.Collections;

public class AlienBullet : MonoBehaviour {

	public AudioClip GameOver;
	public float speed = 4.0f;
	private Vector3 target;
	private TheCheese cheese;
	
	// Use this for initialization
	void Start () {
		this.target = this.transform.position + transform.up * 20;
		GameObject cheeseObject = GameObject.FindWithTag("TheCheese");
		if (cheeseObject != null) {
			cheese = cheeseObject.GetComponent<TheCheese>();
		}
		if (cheese == null) {
			Debug.Log("Kan ikke finde 'TheCheese' scriptet!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = this.transform.position;
		Vector3 newPosition = Vector3.MoveTowards(currentPosition, this.target, speed * Time.deltaTime);
		this.transform.position = newPosition;
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			AudioSource.PlayClipAtPoint(GameOver, transform.position);
			GameObject.Destroy(collision.gameObject);
			GameObject.Destroy(this.gameObject);
			cheese.GameOver();
		} else {
			GameObject.Destroy(this.gameObject, 2);
		}
	}
}
