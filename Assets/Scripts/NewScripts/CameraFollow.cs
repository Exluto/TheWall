using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	
	[SerializeField]
	private float _offsetX;
	
	[SerializeField]
	private float _offsetY;

	public Transform _playerTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

		Vector3 temp = transform.position;

		temp.x = _playerTransform.transform.position.x;
		temp.y = _playerTransform.transform.position.y;

		temp.x += _offsetX;
		temp.y = _offsetY;

		transform.position = temp;
		
	}
}
