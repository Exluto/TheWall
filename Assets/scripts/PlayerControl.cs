using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;

    public float jumpHeight;
    public Transform GroundCheck;
    public float groundCheckRadius;
    public LayerMask whatisground;
    private bool grounded;

    [SerializeField]
    private float moveSpeed;


	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
		
	}

    void FixedUpdate ()
    {
        grounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, whatisground);
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown (KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0.0f);

        rb.AddForce(movement * speed);


	}
}
