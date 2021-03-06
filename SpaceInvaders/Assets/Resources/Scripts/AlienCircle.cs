﻿using UnityEngine;
using System.Collections;

public class AlienCircle : MonoBehaviour {

	// Use this for initialization
	public int numPoints = 20;                      //number of points on radius to place prefabs
	public Vector3 centerPos = new Vector3(0,0,32);    //center of circle/elipsoid
	
	public GameObject pointPrefab = null;                  //generic prefab to place on each point
	public float radiusX,radiusY;                   //radii for each x,y axes, respectively
	
	public bool isCircular = false;                    //is the drawn shape a complete circle?
	public bool vertical = true;                    //is the drawb shape on the xy-plane?
	
	Vector3 pointPos;                               //position to place each prefab along the given circle/eliptoid
	//*is set during each iteration of the loop
	
	// Use this for initialization
	void Start () {
		for(int i = 0; i<numPoints;i++){
			//multiply 'i' by '1.0f' to ensure the result is a fraction
			float pointNum = (i*1.0f)/numPoints;
			
			//angle along the unit circle for placing points
			float angle = pointNum*Mathf.PI*2;
			
			float x = Mathf.Sin (angle)*radiusX;
			float y = Mathf.Cos (angle)*radiusY;
			
			//position for the point prefab
			if(vertical)
				pointPos = new Vector3(x, y)+centerPos;
			else if (!vertical){
				pointPos = new Vector3(x, 0, y)+centerPos;
			}
			
			//place the prefab at given position
			pointPrefab = Instantiate (Resources.Load("Prefabs/Alien"), pointPos, Quaternion.identity) as GameObject;
		}
		
		//keeps radius on both axes the same if circular
		if(isCircular){
			radiusY = radiusX;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float speed = 0.01f;
		//Vector3 alienMovementX = pointPrefab.transform.position;
		Vector3 alienMovementY = pointPrefab.transform.position;

		//alienMovementX.x = pointPrefab.transform.position.x - speed;
		alienMovementY.y = pointPrefab.transform.position.y - speed;

		pointPrefab.transform.position = alienMovementY;
		//pointPrefab.transform.position = alienMovementX;

		print (alienMovementY);
		//print (alienMovementY);
	}
}
