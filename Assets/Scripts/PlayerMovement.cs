using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {LEFT, RIGHT};
public class PlayerMovement : MonoBehaviour {

	public float speed = 5.0f;
	public float dashPower = 7.0f;
	public float jumpPower = 7.0f;

	private Transform _transform;
	private Rigidbody2D _rigidbody;
	private Direction playerDirection = Direction.RIGHT;
	

	public Direction PlayerDirection {
		get {
			return playerDirection;
		}
	}

	// Use this for initialization
	void Start () {
		_transform = GetComponent(typeof (Transform)) as Transform;
		_rigidbody = GetComponent(typeof (Rigidbody2D)) as Rigidbody2D;
		
	}
	
	// Update is called once per frame
	void Update () {
		MovePlayer();
		Jump();
		Dash();
	}

	void MovePlayer() {
		float translate = Input.GetAxis("Horizontal") * speed * Time.deltaTime; _transform.Translate(translate, 0, 0);
					if(translate > 0) {
				playerDirection = Direction.RIGHT;
					} else if (translate <0) {
				playerDirection = Direction.LEFT;
				
					if (Input.GetButtonUp("Horizontal") == true) 
						_rigidbody.velocity = new Vector2(0, 0); 
			
		}
	}
	void Dash() {
		if (Input.GetButtonDown("Fire2"))
            _rigidbody.velocity = new Vector2(dashPower, 0);
	
		else if(Input.GetButtonUp("Fire2"))
			_rigidbody.velocity = new Vector2(0, 0); 
			
	}
	void Jump() {
		if (Input.GetButtonDown("Jump"))
            _rigidbody.velocity = new Vector2(0, jumpPower);
	
		else if(Input.GetButtonUp("Jump"))
			_rigidbody.velocity = new Vector2(0, 0); 
		

	}

}

