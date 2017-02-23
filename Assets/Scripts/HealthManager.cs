using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

public int maxHealth;
public static int playerHealth;
Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();

		playerHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "" + playerHealth;
	}

	public static void KillPlayer(int damageToGive) {
		playerHealth -= damageToGive;
	}

	public void FullHealth() {
		playerHealth = maxHealth;
	}
}
