using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {
	public int damageGiven;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.name == "Character1_0") { 
			HealthManager.KillPlayer(damageGiven);
		}
	}
}
