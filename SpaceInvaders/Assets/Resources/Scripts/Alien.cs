using UnityEngine;
using System.Collections;

public class Alien : MonoBehaviour {

	public float horDistance = 5.0f;
	public float verDistance = 0.5f;
	public float speed = 2.0f;
	public GameObject bullet;
	public float minShootDelay = 3.0f;
	public float maxShootDelay = 7.0f;
	//private float startTime;
	//private Vector3 startingPosition;
	//private Vector3 target;
	private float nextShootTime = 0.0f;

	// Use this for initialization
	void Start () {
		//this.startTime = Time.time;

		//this.startingPosition = this.transform.position;
		//this.target = this.startingPosition + Vector3.up;

		this.nextShootTime = Random.Range(minShootDelay, maxShootDelay);
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.LookAt(Vector3.zero, Vector3.back);
		this.transform.RotateAround(Vector3.back, Vector3.back, 10 * Time.deltaTime);

/*
		Vector3 currentPosition = this.transform.position;
		Vector3 newPosition = Vector3.MoveTowards(currentPosition, this.target, speed * Time.deltaTime);
		this.transform.position = newPosition;

		print (this.target);

		if (newPosition == target)
		{
			if (newPosition.x == startingPosition.x)
			{
				if (((newPosition.y - startingPosition.y) / verDistance) % 2 == 0)
					this.target = newPosition + new Vector3(this.horDistance, 0, 0);
				else
					this.target = newPosition - new Vector3(0, this.verDistance, 0);
			}
			else
			{
				if (((newPosition.y - startingPosition.y) / verDistance) % 2 != 0)
					this.target = newPosition - new Vector3(this.horDistance, 0, 0);
				else
					this.target = newPosition - new Vector3(0, this.verDistance, 0);               
			}
		}
*/
		if (Time.time > nextShootTime)
		{
			Instantiate(bullet, this.transform.position, Quaternion.identity);
			nextShootTime = Time.time + Random.Range(minShootDelay, maxShootDelay);
		}
	}
}
