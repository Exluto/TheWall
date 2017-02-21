using UnityEngine;
using System.Collections;

public class EnemyLerp : MonoBehaviour {
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;

    private float journeyLength;
	
    void Start() {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);


		
    }
    void Update() {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);

				if(fracJourney >= 1f){
					startTime = Time.time; 
					Vector3 tempPostion = startMarker.position;
					startMarker.position = endMarker.position;
					endMarker.position = tempPostion;
				}
    }
}