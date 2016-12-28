using UnityEngine;
using System.Collections;

/**
 * @brief This script class detects an enterance of a coin to a road, and creates another road and 2 buildings on left and right of the generated road.
 * 
 * 
 */
public class MapGenerator : MonoBehaviour {
	public Material[] buildingMaterials;
	public GameObject[] buildings;
	public GameObject road;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Coin") {
			SpawnRoad(this.transform.position  + new Vector3(15.0f, 0.0f, 0.0f));
		}
	}

	public void SpawnRoad (Vector3 roadPosition) {
		SpawnBuildingInternal (roadPosition, true);
		SpawnBuildingInternal (roadPosition, false);
		SpawnPathInternal (roadPosition);
	}

	void SpawnBuildingInternal (Vector3 roadPosition, bool isLeft) {
		GameObject buildingCreated = (GameObject) Instantiate (buildings [Random.Range (0, buildings.Length)]);
		buildingCreated.GetComponent<Renderer>().material = buildingMaterials[Random.Range (0, buildingMaterials.Length)];

		if (!isLeft) {
			// Move the building to the opposite side of the road
			buildingCreated.transform.position = new Vector3(buildingCreated.transform.position.x,
			                                                 buildingCreated.transform.position.y,
			                                                 -buildingCreated.transform.position.z);

			buildingCreated.transform.eulerAngles = new Vector3(buildingCreated.transform.eulerAngles.x,
			                                             		buildingCreated.transform.eulerAngles.y + 180,
			                                             		buildingCreated.transform.eulerAngles.z);
		}

		buildingCreated.transform.position += roadPosition;

		buildingCreated.AddComponent<MapCleaner>();
	}

	void SpawnPathInternal (Vector3 roadPosition) {
		GameObject roadCreated = (GameObject) Instantiate (road);
		roadCreated.transform.position = roadPosition;

		roadCreated.AddComponent<MapCleaner>();
	}

	void SpawnFenceInternal (Vector3 roadPosition) {

	}
}
