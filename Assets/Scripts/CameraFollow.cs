using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	public float newX;
	public float newY;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		newX = player.transform.position.x;
		newY = player.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y < 0) { newY = 0; } else { newY = player.transform.position.y; }
		if (player.transform.position.x < -10.5f) { 
			newX = -10.5f; 
		} else if (player.transform.position.x > 10.5f) { 
			newX = 10.5f; 
		} else {
			newX = player.transform.position.x;
		}
		transform.position = new Vector3(newX, newY, -10);
	}
}
