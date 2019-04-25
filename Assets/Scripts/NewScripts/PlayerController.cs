using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float _moveSpeed;
	public float _jumpHeight;
	private float _moveInput;

	private Rigidbody2D _rb2D;
	private Animator _anim;

	private bool _isGrounded;
	public Transform _groundCheck;
	public LayerMask _groundMask;
	public float _groundCheckradius;

	private float _jumpTimeCounter;
	public float _jumpTime;
	private bool _isJumping; 

	// Use this for initialization
	void Start () {
		_rb2D = GetComponent<Rigidbody2D>();
		_anim = GetComponent<Animator>();
	}

	void FixedUpdate() {
		_moveInput = Input.GetAxis("Horizontal");
		_rb2D.velocity = new Vector2(_moveInput * _moveSpeed, _rb2D.velocity.y);
	}
	
	// Update is called once per frame
	void Update () {
		
		_isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckradius, _groundMask);

		if(_moveInput > 0) {
			transform.eulerAngles = new Vector3(0, 0, 0);
			_anim.SetFloat("Speed", _moveSpeed);
			// anim moving right
		} else if(_moveInput < 0) {
			transform.eulerAngles = new Vector3(0, 180, 0);
			_anim.SetFloat("Speed", _moveSpeed);
			// anim moving left
		} else {
			_anim.SetFloat("Speed", 0);
			// anim idle
		}

		if(_isGrounded == true && Input.GetKeyDown(KeyCode.Space)) {
			_isJumping = true;
			_jumpTimeCounter = _jumpTime;
			_rb2D.velocity = Vector2.up * _jumpHeight;
		}

		if(Input.GetKey(KeyCode.Space) && _isJumping == true) {
			if(_jumpTimeCounter > 0) {
				_rb2D.velocity = Vector2.up * _jumpHeight;
				_jumpTimeCounter -= Time.deltaTime;
			} else {
				_isJumping = false;
			}
		}

		if(Input.GetKeyUp(KeyCode.Space)) {
			_isJumping = false;
		}
	}
}
