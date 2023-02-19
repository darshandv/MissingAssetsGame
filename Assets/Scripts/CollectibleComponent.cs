using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleComponent : MonoBehaviour
{
    public static int TotalComponents = 0; // total number of collectible components in the level
    public static int CollectedComponents = 0; // number of collected components

    void Start() {
        TotalComponents++;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            CollectedComponents++; 
            Destroy(gameObject); 
            if (CollectedComponents >= TotalComponents) {
                EndLevel(); 
            }
        }
        // Debug.Log("Collected items: " + CollectedComponents+" $$$ "+TotalComponents);
    } 

    void EndLevel() {
        // TODO: put your code here to end the level (e.g. load the next scene)
    }
}
