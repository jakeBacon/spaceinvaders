using UnityEngine;
using System.Collections;

public class AlienInstantiation : MonoBehaviour {

	public GameObject gameObject = null;

	// Use this for initialization
	void Start () {
		int i = 0;
		int posX = 0;
		bool isPosXReset = false;
		while (i < 6) {
			gameObject = Instantiate(Resources.Load("Prefabs/Alien"), new Vector3(posX, 0, 0), Quaternion.identity) as GameObject;
			i++;
			posX += 2;
		}
		while (i >= 6 && i < 12) {
			if (isPosXReset == false)  {
				posX = 0;
				isPosXReset = true;
			}
			gameObject = Instantiate(Resources.Load("Prefabs/Alien"), new Vector3(posX, 2, 0), Quaternion.identity) as GameObject;
			i++;
			posX += 2;
		}
		while (i >= 12 && i < 18) {
			if (isPosXReset == true)  {
				posX = 0;
				isPosXReset = false;
			}
			gameObject = Instantiate(Resources.Load("Prefabs/Alien"), new Vector3(posX, 4, 0), Quaternion.identity) as GameObject;
			i++;
			posX += 2;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}