using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private void Start() {
      InvokeRepeating("Destruct", 20.0f, 20.0f);
   }
   private void OnCollisionEnter2D(Collision2D collision) 
   {    
        Destruct();
    }


   private void Destruct() 
   {
      Destroy(gameObject);
   }
}