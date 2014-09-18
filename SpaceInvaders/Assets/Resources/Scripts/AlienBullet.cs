using UnityEngine;
using System.Collections;

public class AlienBullet : MonoBehaviour {

	public AudioClip GameOver;
	public float speed = 4.0f;
	private Vector3 target;
	
	// Use this for initialization
	void Start () {
		this.target = this.transform.position + transform.up * 20;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = this.transform.position;
		Vector3 newPosition = Vector3.MoveTowards(currentPosition, this.target, speed * Time.deltaTime);
		this.transform.position = newPosition;
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			AudioSource.PlayClipAtPoint(GameOver, transform.position);
			Rigidbody.Destroy(collision.gameObject);
			Rigidbody.Destroy(this.gameObject);
		}
	}
}
