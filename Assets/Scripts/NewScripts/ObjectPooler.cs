using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

	[System.Serializable]
	public class Pool {
		public string _tag;
		public GameObject _prefab;
		public int _size;
	}

	public static ObjectPooler Instance;

	public List<Pool> _pools;
	public Dictionary<string, Queue<GameObject>> _poolDictionary;

	private void Awake() {
		Instance = this;
	}

	// Use this for initialization
	void Start () {

		_poolDictionary = new Dictionary<string, Queue<GameObject>>();

		foreach (Pool pool in _pools) {
			Queue<GameObject> objectPool = new Queue<GameObject>();

			for (int i = 0; i < pool._size; i++) {
				GameObject obj = Instantiate(pool._prefab);
				obj.SetActive(false);
				objectPool.Enqueue(obj);
			}
			_poolDictionary.Add(pool._tag, objectPool);
		}
	}
	
	public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation) {

		if(!_poolDictionary.ContainsKey(tag)) {
			Debug.LogWarning("Pool with tag " + tag + " doesn't exist");
			return null;
		}

		GameObject objectToSpawn = _poolDictionary[tag].Dequeue();

		objectToSpawn.SetActive(true);
		objectToSpawn.transform.position = position;
		objectToSpawn.transform.rotation = rotation;

		IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();

		if(pooledObj != null) {
			pooledObj.OnObjectSpawn();
		}

		_poolDictionary[tag].Enqueue(objectToSpawn);

		return objectToSpawn;
	}
}
