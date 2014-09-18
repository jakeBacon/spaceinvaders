using UnityEngine;
using System.Collections;

public class AlienInstantiation : MonoBehaviour {

	public AudioClip GameIntro;
	public int initNumberOfAliens;
	public float minSpawnDelay;
	public float maxSpawnDelay;
	private GameObject AlienClone = null;
	private float nextAlienSpawnLeft = 0.0f;
	private float nextAlienSpawnUpper = 0.0f;
	private float nextAlienSpawnRight = 0.0f;
	private float nextAlienSpawnLower = 0.0f;

	// Use this for initialization
	void Start () {
		audio.clip = GameIntro;
		audio.Play();

		for (int i = 0; i < (initNumberOfAliens/4); i++) { // Left screen side
			AlienClone = Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(Random.Range(-25, -22), Random.Range(-13, 13)), Quaternion.identity) as GameObject;
		}
		for (int i = 0; i < (initNumberOfAliens/4); i++) { // Upper screen side
			AlienClone = Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(Random.Range(-25, 25), Random.Range(13, 11)), Quaternion.identity) as GameObject;
		}
		for (int i = 0; i < (initNumberOfAliens/4); i++) { // Right screen side
			AlienClone = Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(Random.Range(22, 25), Random.Range(-13, 13)), Quaternion.identity) as GameObject;
		}
		for (int i = 0; i < (initNumberOfAliens/4); i++) { // Lower screen side
			AlienClone = Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(Random.Range(-25, 25), Random.Range(-13, -11)), Quaternion.identity) as GameObject;
		} /**/
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextAlienSpawnLeft) { // Left screen side
			Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(Random.Range(-25, -22), Random.Range(-13, 13)), Quaternion.identity);
			nextAlienSpawnLeft = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
		}

		if (Time.time > nextAlienSpawnUpper) { // Upper screen side
			Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(Random.Range(-25, 25), Random.Range(13, 11)), Quaternion.identity);
			nextAlienSpawnUpper = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
		}

		if (Time.time > nextAlienSpawnRight) { // Right screen side
			Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(Random.Range(22, 25), Random.Range(-13, 13)), Quaternion.identity);
			nextAlienSpawnRight = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
		}

		if (Time.time > nextAlienSpawnLower) { // Lower screen side
			Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(Random.Range(-25, 25), Random.Range(-13, -11)), Quaternion.identity);
			nextAlienSpawnLower = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
		} /**/
	}
}