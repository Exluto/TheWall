using UnityEngine;
using System.Collections;

// Destroys the game object it is attached to after the given timeframe
public class DestroyAfterTime : MonoBehaviour 
{
    public float DestoryAfterTime = 1.0f;

    void Start () 
    {
        Destroy(gameObject, DestoryAfterTime);
    }	
}