using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Patroly : MonoBehaviour {
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (new Vector3(0, moveSpeed, 0) * Time.deltaTime) ;				
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Floor")
		{
		moveSpeed *= -1;
		}
	}
}
