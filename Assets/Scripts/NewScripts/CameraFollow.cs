using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	
	public Transform _playerTransform;
	public Vector3 _offset;

	
	// Update is called once per frame
	void LateUpdate () {

		transform.position = _playerTransform.position + _offset;
		
	}
}
