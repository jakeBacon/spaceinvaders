using UnityEngine;
using System.Collections;

public class AlienInstantiation : MonoBehaviour {

	public int initNumberOfAliens = 20;
	public float minSpawnDelay = 1.0f;
	public float maxSpawnDelay = 10.0f;
	private GameObject AlienClone = null;
	private float nextAlienSpawnLeft = 0.0f;
	private float nextAlienSpawnUpper = 0.0f;
	private float nextAlienSpawnRight = 0.0f;
	private float nextAlienSpawnLower = 0.0f;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < (initNumberOfAliens/4); i++) { // Left screen side
			AlienClone = Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(Random.Range(-8, -7), Random.Range(-7, 7)), Quaternion.identity) as GameObject;
		}
		for (int i = 0; i < (initNumberOfAliens/4); i++) { // Upper screen side
			AlienClone = Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(Random.Range(-8, 8), Random.Range(7, 8)), Quaternion.identity) as GameObject;
		}
		for (int i = 0; i < (initNumberOfAliens/4); i++) { // Right screen side
			AlienClone = Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(Random.Range(7, 8), Random.Range(-8, 8)), Quaternion.identity) as GameObject;
		}
		for (int i = 0; i < (initNumberOfAliens/4); i++) { // Lower screen side
			AlienClone = Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(Random.Range(-7, 8), Random.Range(-8, -7)), Quaternion.identity) as GameObject;
		} /**/
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextAlienSpawnLeft) {
			Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(Random.Range(-8, -7), Random.Range(-7, 7)), Quaternion.identity);
			nextAlienSpawnLeft = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
		}

		if (Time.time > nextAlienSpawnUpper) {
			Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(Random.Range(-8, 8), Random.Range(7, 8)), Quaternion.identity);
			nextAlienSpawnUpper = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
		}

		if (Time.time > nextAlienSpawnRight) {
			Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(Random.Range(7, 8), Random.Range(-8, 8)), Quaternion.identity);
			nextAlienSpawnRight = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
		}

		if (Time.time > nextAlienSpawnLower) {
			Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(Random.Range(-7, 8), Random.Range(-8, -7)), Quaternion.identity);
			nextAlienSpawnLower = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
		} /**/
	}
}