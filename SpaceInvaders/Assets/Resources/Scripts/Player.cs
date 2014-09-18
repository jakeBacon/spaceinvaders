using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float cooldown = 0.1f; // minimum time between bullets
	public GameObject Bullet;
	private float nextFire = 1.0f; // next time when a bullet can be fired

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;

		if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0) {
			transform.position = new Vector2(pos.x + Input.GetAxis("Horizontal"), pos.y + Input.GetAxis("Vertical"));
		}
		
		// Update is called once per frame
		if ((Input.GetKey(KeyCode.Space) || Input.GetButton("PS4_L1") || Input.GetButton("PS4_R1")) && Time.time >= nextFire) {
				nextFire += cooldown;
				GameObject shot = (GameObject)Instantiate(Bullet, this.transform.position, this.transform.rotation);
		}
	}
}
