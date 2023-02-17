using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   Vector2 initialPosition;
   public float distanceRange = 10.0f;

   private void Start() {
      initialPosition = transform.position;
   }

   private void OnCollisionEnter2D(Collision2D collision) 
   {    
      Destruct();
   }

   void FixedUpdate() {
      float distance = Vector2.Distance(initialPosition,transform.position);
      if(distance > distanceRange) {
         Destruct();
      }
   }

   private void Destruct() 
   {
      Destroy(gameObject);
   }
}