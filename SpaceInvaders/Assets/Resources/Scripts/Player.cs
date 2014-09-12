using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject bullet;
	public float cooldown = 1.0f; // minimum time between bullets
	private float nextFire = 1.0f; // next time when a bullet can be fired

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = this.transform.position;
		
		if (Input.GetKey(KeyCode.Space) && Time.time >= nextFire) {
			nextFire += cooldown;
			Instantiate(bullet, this.transform.position, Quaternion.identity);
		}
		if (Input.GetKey(KeyCode.LeftArrow) && pos.x > -6.0f)
			this.transform.position = new Vector3(pos.x - 0.1f, pos.y, pos.z);
		if (Input.GetKey(KeyCode.RightArrow) && pos.x < 6.0f)
			this.transform.position = new Vector3(pos.x + 0.1f, pos.y, pos.z);
	}
}
