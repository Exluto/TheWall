using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

	public static ObjectPool _instance;

	public GameObject _prefab;
	public int _amountPooled;
	List <GameObject> _pooledObjects;

	public bool _expandPool = false;


	void Awake() {
		if(_instance == null) {
			_instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		_pooledObjects = new List<GameObject>();

		for(int i = 0; i < _amountPooled; i++) {
			GameObject _obj = (GameObject)Instantiate(_prefab);
			_obj.SetActive(false);
			_pooledObjects.Add(_obj);
		}
	}

	public GameObject GetPoolObject() {
		for(int i = 0; i < _pooledObjects.Count; i++) {
			if(!_pooledObjects[i].activeInHierarchy) {
				return _pooledObjects[i];
			}
		}

		if(_expandPool) {
			 GameObject _obj = (GameObject)Instantiate(_prefab);
			_obj.SetActive(false);
			_pooledObjects.Add(_obj);
			return _obj;
		}
		return null;
	}
	
	
}
