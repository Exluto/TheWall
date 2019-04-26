using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	ObjectPooler _objectPooler;

	private void Start() {
		_objectPooler = ObjectPooler.Instance;
	}

	void FixedUpdate() {
		_objectPooler.SpawnFromPool("Laser", transform.position, Quaternion.identity);
	}
}
