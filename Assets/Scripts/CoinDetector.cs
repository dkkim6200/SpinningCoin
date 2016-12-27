using UnityEngine;
using System.Collections;

public class CoinDetector : MonoBehaviour {
	private MapGenerator mapGenerator;

	// Use this for initialization
	void Start () {
		mapGenerator = GetComponent<MapGenerator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Coin") {
			mapGenerator.SpawnChunk(this.transform.position  + new Vector3(15.0f, 0.0f, 0.0f));
		}
	}
}
