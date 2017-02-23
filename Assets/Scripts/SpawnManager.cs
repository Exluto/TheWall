using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	public HealthManager manageHealth;
	public GameObject enemy;
	public float spawnTime = 3f;
	public Transform[] spawnPoints;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Spawn () {
		if(HealthManager.playerHealth <= 0f) {
			return;
		}

		int spawnPointsIndex = Random.Range (0,spawnPoints.Length);

		Instantiate (enemy, spawnPoints[spawnPointsIndex].position, spawnPoints[spawnPointsIndex].rotation);
	}
}
