using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	private GameObject coin;
	private Vector3 cameraRelativePosition;

	// Use this for initialization
	void Start () {
		coin = GameObject.FindWithTag ("Coin");

		cameraRelativePosition = this.transform.position - coin.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = coin.transform.position + cameraRelativePosition;
	}
}
