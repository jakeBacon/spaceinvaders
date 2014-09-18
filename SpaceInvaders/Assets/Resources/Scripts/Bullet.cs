﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public AudioClip AlienDeath;
	public AudioClip playerFireSound;
	public float speed = 1.0f;
	private Vector3 target;

	// Use this for initialization
	void Start () {
		this.target = this.transform.position + transform.up * 20;
		audio.clip = playerFireSound;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = this.transform.position;
		Vector3 newPosition = Vector3.MoveTowards(currentPosition, this.target, speed * Time.deltaTime);
		this.transform.position = newPosition;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Alien")
		{
			AudioSource.PlayClipAtPoint(AlienDeath, transform.position);
			Rigidbody.Destroy(collision.gameObject);
			Rigidbody.Destroy(this.gameObject);
		} else {
			Rigidbody.Destroy(this.gameObject, 2);
		}
	}
}
