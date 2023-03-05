using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   Vector2 initialPosition;
   public float distanceRange = 25.0f;

   private void Start() {
      initialPosition = transform.position;
   }

   private void OnCollisionEnter2D(Collision2D collision) 
   {    
      Destruct();
      if(gameObject.tag == "EnemyBullet" && collision.collider.CompareTag("Player")) {
         AnalyticsTracker.enemyBulletsHit += 1;
      }
   }

   void FixedUpdate() {
      float distance = Vector2.Distance(initialPosition,transform.position);
      if(gameObject.tag == "PlayerBullet") distanceRange *= 2;
      if(distance > distanceRange) {
         Destruct();
      }
   }

   private void Destruct() 
   {
      Destroy(gameObject);
   }
}