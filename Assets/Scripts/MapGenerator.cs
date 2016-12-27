using UnityEngine;
using System.Collections;

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

	public void SpawnChunk (Vector3 roadPosition) {
		SpawnBuildingInternal (roadPosition, true);
		SpawnBuildingInternal (roadPosition, false);
		SpawnRoadInternal (roadPosition);
	}

	void SpawnBuildingInternal (Vector3 roadPosition, bool isLeft) {
		GameObject building = (GameObject) Instantiate (buildings [Random.Range (0, buildings.Length)]);
		building.GetComponent<Renderer>().material = buildingMaterials[Random.Range (0, buildingMaterials.Length)];

		if (!isLeft) {
			building.transform.position = new Vector3(building.transform.position.x,
			                                          building.transform.position.y,
			                                          -building.transform.position.z);

			building.transform.eulerAngles = new Vector3(building.transform.eulerAngles.x,
			                                             building.transform.eulerAngles.y + 180,
			                                             building.transform.eulerAngles.z);
		}

		building.transform.position += roadPosition;

		building.AddComponent<MapCleaner>();
	}

	void SpawnRoadInternal (Vector3 roadPosition) {
		GameObject roadCreated = (GameObject) Instantiate (road);
		roadCreated.transform.position = roadPosition;

		roadCreated.AddComponent<MapCleaner>();
	}

	void SpawnFenceInternal (Vector3 roadPosition) {

	}
}
