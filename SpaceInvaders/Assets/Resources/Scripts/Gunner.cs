﻿using UnityEngine;
using System.Collections;

public class Gunner : MonoBehaviour {
	
	public float cooldown = 0.1f; // minimum time between bullets
	public GameObject Bullet;
	private Rigidbody bulletClone = null;
	private float nextFire = 1.0f; // next time when a bullet can be fired
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		if ((Input.GetKey(KeyCode.Space) || Input.GetButton("PS4_L1") || Input.GetButton("PS4_R1")) && Time.time >= nextFire) {
			nextFire += cooldown;
			bulletClone = Instantiate(Resources.Load ("Prefabs/Bullet"), pos, transform.rotation) as Rigidbody;
			bulletClone.velocity = transform.TransformDirection(new Vector3 (0, 0, 20));
			GameObject shot = (GameObject)Instantiate(Bullet, this.transform.position, this.transform.rotation);
		}
		
		//print (pos);
	}	
}
