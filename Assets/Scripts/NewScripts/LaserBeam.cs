using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour, IPooledObject {

	public float _speed = 20f;
	public Rigidbody2D _rb;

	// Use this for initialization
	public void OnObjectSpawn () {
		_rb.velocity = transform.right * _speed;
	}
}
