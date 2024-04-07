using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   Vector2 initialPosition;
   public float lifeTime = 3f;

   private void Start() {
      initialPosition = transform.position;
      Debug.Log("bullet started now");
      Destroy(gameObject, lifeTime);
   }

   private void OnCollisionEnter2D(Collision2D collision) 
   {    
      Destroy(gameObject);
      if(gameObject.tag == "EnemyBullet" && collision.collider.CompareTag("Player")) {
         AnalyticsTracker.enemyBulletsHit += 1;
      }
   }

   // void FixedUpdate() {
   //    float distance = Vector2.Distance(initialPosition,transform.position);
   //    if(gameObject.tag == "PlayerBullet") {
   //       distanceRange *= 2;
   //       Debug.Log("Player bullet"+distanceRange);
   //    } 
   //    if(distance > distanceRange) {
   //       Destruct();
   //    }
   // }

   // private void Destruct() 
   // {
   //    Destroy(gameObject);
   // }
}