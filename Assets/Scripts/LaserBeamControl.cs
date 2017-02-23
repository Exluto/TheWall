using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamControl : MonoBehaviour {

	public float speed;
	public MoveSet player;



	// Use this for initialization
	void Start () {
		player = FindObjectOfType<MoveSet>();

		if(player.transform.localScale.x < 0)
			speed = -speed;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if(GetComponent<Collider>().tag == "Lizard_0") {
			Destroy (gameObject);
		}
		Destroy (gameObject);
	}
}
