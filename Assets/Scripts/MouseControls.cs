using UnityEngine;
using System.Collections;

public class MouseControls : MonoBehaviour
{

	public Vector3 pos;

	// Use this for initialization
	void Start ()
	{
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		target.z = 0;
		transform.position = Vector3.MoveTowards(pos, target, 100);
	}
}

