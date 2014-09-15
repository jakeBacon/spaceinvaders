using UnityEngine;
using System.Collections;

public class AlienCircle : MonoBehaviour {

	// Use this for initialization
	public int numPoints = 20;                      //number of points on radius to place prefabs
	public Vector3 centerPos = new Vector3(0,0,0);    //center of circle/elipsoid
	
	public bool isCircular = false;                    //is the drawn shape a complete circle?
	public bool vertical = true;                    //is the drawb shape on the xy-plane?
	
	public GameObject pointPrefab = null;                  //generic prefab to place on each point
	public float radiusX,radiusY = 8.0f;                   //radii for each x,y axes, respectively

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
		Vector3 alienMovementX = pointPrefab.transform.position;
		alienMovementX.x = pointPrefab.transform.position.x - (speed / 2);
		pointPrefab.transform.position = alienMovementX;

		print (alienMovementX);
	/*		for(int i = 0; i<numPoints;i++) {
			float speed = 1.0f;
			float pointNum = (i*1.0f)/numPoints;
			float angle = pointNum*Mathf.PI*2;

			float x = Mathf.Sin (angle)*radiusX;
			float y = Mathf.Cos (angle)*radiusY;
			radiusY = radiusX = speed * Time.time;		

			//position for the point prefab
			if(vertical)
				pointPos = new Vector3(x, y)+centerPos;
			else if (!vertical){
				pointPos = new Vector3(x, 0, y)+centerPos;
			}

			pointPrefab.transform.position = pointPos;*/
		
			//place the prefab at given position
			//pointPrefab = Instantiate (Resources.Load("Prefabs/Alien"), pointPos, Quaternion.identity) as GameObject;
		//}
	}
}
