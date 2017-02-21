using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Bounce : MonoBehaviour {
	public float moveSpeed;
	public float moveSpeedy;
	
	public float DestroyAfterTime = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (new Vector2(moveSpeed, moveSpeedy) * Time.deltaTime) ;				
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Block")
			{
			moveSpeed *= -1;
		
			}
		if(col.gameObject.tag == "Floor")
			{
			moveSpeedy = --moveSpeedy;
			}
		if(moveSpeedy <1){
			moveSpeedy = 0;
			moveSpeed =0;
		} 
		if(moveSpeed < .001)
		Destroy(gameObject, DestroyAfterTime);
	}
}
