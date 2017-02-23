using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Direction bulletDirection = Direction.RIGHT;
	public float speed = 5.0f;
	public int damage = 5; 
	public float timer;

	private Transform _transform;

	// Use this for initialization
	void Start () {
		_transform = transform;		
	}
	
	// Update is called once per frame
	void Update () {
		MoveBullet();
		timer += 1.0F * Time.deltaTime;
		     if (timer >= 1.5)
     {
     GameObject.Destroy(gameObject);
     }
	}
	

	void MoveBullet () {
		int moveDirection = bulletDirection == Direction.LEFT ? -2 : 2;

		float translate = moveDirection * speed * Time.deltaTime;
		_transform.Translate(translate, 0, 0);
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.collider.tag == "Lizard") {
			collision.collider.gameObject.GetComponent<Enemy>().Damage(damage);
			Destroy(gameObject);
		}
	}
}
