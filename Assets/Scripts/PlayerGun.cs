using UnityEngine;
using System.Collections;

public class PlayerGun : MonoBehaviour
{

	// Use this for initialization
	public GameObject bullet;
	public GameObject target;
	public bool isFiring;

	public float nextFire;
	public float fireRate;

	public float bulletSpeed;
	public float bulletSize;
	public float bulletWeight;

	void Start ()
	{
		nextFire = 0.0f;
		fireRate = 0.02f;
		bulletSpeed = 200f;
		bulletSize = 1.0f;
		bulletWeight = 0.1f;
		isFiring = false;
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire) {
			nextFire = Time.time + fireRate; 
			fireGun ();
		}

	}



	void fireGun () {
		// Should just make bullets not collide with person, will fix
		Vector3 origin;
		float originX, originY;
		Vector3 pos = target.transform.position - this.transform.position;
		if (pos.x > 0) {
			originX = this.transform.position.x + 0.2f;
			origin = new Vector3(originX, this.transform.position.y, 0.0f);
		} else {
			originX = this.transform.position.x - 0.2f;
			origin = new Vector3(originX, this.transform.position.y, 0.0f);
		}
		GameObject newBullet = Instantiate(bullet, origin, Quaternion.identity) as GameObject;

		Vector2 force = new Vector2(pos.x, pos.y).normalized * bulletSpeed;
		newBullet.GetComponent<Rigidbody2D>().mass = bulletWeight;
		newBullet.transform.localScale = new Vector3(bulletSize, bulletSize, bulletSize);
		newBullet.GetComponent<Rigidbody2D>().AddForce(force);
	}
}

