using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.GetComponent<MoveBehavior>().healthValue > 100) {
            Destroy(gameObject);
        } else {
            Destroy(collider2D.gameObject);
            Application.Quit();
        }
    }
}
