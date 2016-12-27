using UnityEngine;
using System.Collections;

public class MapCleaner : MonoBehaviour {
	public const float MAP_DELETION_THRESHOLD = 30.0f;

	private GameObject coin;

	// Use this for initialization
	void Start () {
		coin = GameObject.FindWithTag ("Coin");
	}
	
	// Update is called once per frame
	void Update () {
		if ((this.transform.position - coin.transform.position).magnitude > MAP_DELETION_THRESHOLD) {
			Destroy(gameObject);
		}
	}
}
