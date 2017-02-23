using UnityEngine;
using System.Collections;

// Destroys the game object it is attached to after the given timeframe
public class DestroyAfterCol : MonoBehaviour 
{
    

    void Start () 
    {}
  void OnCollisionEnter2D (Collision2D col)
         {
           //Check collision name
          
           if(col.gameObject.tag == "EnemyBoss")
           {
            Destroy(gameObject);
           }
         }
}