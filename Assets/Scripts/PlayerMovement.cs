using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody2D rigidBody;
	public float speed;
	public float maxSpeed;
	public bool isGrounded;
	public float velocity;

	public int playerJumps;

	public float moveX;

	// Use this for initialization
	void Start () {
		isGrounded = true;
		moveX = 0.0f;
		rigidBody = gameObject.GetComponent<Rigidbody2D>();
		speed = 10;
		maxSpeed = 10;
		velocity = rigidBody.velocity.magnitude;
		rigidBody.gravityScale = 3f;
		rigidBody.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {

		if (Input.GetKeyDown(KeyCode.W) && playerJumps > 0) {
			rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
			rigidBody.AddForce(new Vector2(0, 750), ForceMode2D.Force);
			playerJumps--;
			//Debug.Log("Pressed W");
		}

		if (Input.GetKey(KeyCode.A)) {
			rigidBody.AddForce(new Vector2(-speed * 10, 0), ForceMode2D.Force);
		}
		if (Input.GetKey(KeyCode.D)) {
			rigidBody.AddForce(new Vector2(speed * 10, 0), ForceMode2D.Force);
		}

		if (rigidBody.velocity.x > maxSpeed || -rigidBody.velocity.x > maxSpeed)
		{
			float xVel = rigidBody.velocity.normalized.x * maxSpeed;
			rigidBody.velocity = new Vector2(xVel, rigidBody.velocity.y);
		}
		velocity = rigidBody.velocity.magnitude;

		//if (Input.GetAxis
		//moveX = Input.GetAxis("Horizontal");
		//rigidBody.AddForce(new Vector2(
		//rigidBody.velocity = new Vector2(moveX * speed, -rigidBody.gravityScale);
		//Vector3 newPos = Vector3.Lerp(
		//transform.position.x = new Vector2();

		//rigidBody.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * speed, 0.8f), Mathf.Lerp(0, Input.GetAxis("Vertical") * speed, 0.8f));
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Level") {
			isGrounded = true;
			resetJumps();
			//Debug.Log("Ground!");
		}
	}

	void resetJumps() {
		playerJumps = 2;
	}

}
