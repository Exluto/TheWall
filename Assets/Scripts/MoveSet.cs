using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSet : MonoBehaviour {


	public float moveSpeed; 
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	public Transform firePoint;
	public GameObject laserBeam;
	
	// Use this for initialization
	void Start () {	
	}

	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Space) && grounded) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
		}
		
		if(Input.GetKey (KeyCode.D)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		if(Input.GetKey (KeyCode.A)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		if(GetComponent<Rigidbody2D>().velocity.x > 0)
			transform.localScale = new Vector3(1f, 1f, 1f);
		else if(GetComponent<Rigidbody2D>().velocity.x < 0)
			transform.localScale = new Vector3 (-1f, 1f, 1f);

		if(Input.GetKeyDown(KeyCode.Z)) {
		Instantiate(laserBeam, firePoint.position, firePoint.rotation);
		}
	}
}
