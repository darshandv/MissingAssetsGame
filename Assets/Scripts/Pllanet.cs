using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    public float force_of_push;
    public bool isBlackHole = false;
    public float eventHorizon = 10f;
    // private void OnTriggerEnter2D(Collider2D collider2D) {
    //     if (collider2D.gameObject.name != "Triangle") return;
    //     StartCoroutine(ExecuteEffect(collider2D));
    // }

    // private void ExecuteEffect(Collider2D collider2D) {

    // }

    // public Rigidbody2D player_rigid_body; 
    // // Start is called before the first frame update

    void OnTriggerStay2D(Collider2D ship) {
        if (ship.name.Contains("Player")) {
            float x_error = transform.position.x - ship.transform.position.x;
            float y_error = transform.position.y - ship.transform.position.y;
            float magnitude = Mathf.Pow((Mathf.Pow(x_error, 2f) + Mathf.Pow(y_error, 2f)), 0.5f);

            if(isBlackHole) {
                float distance = Vector2.Distance(transform.position,ship.transform.position);
                if(distance <= eventHorizon) Destroy(ship.gameObject);
            }

            Vector2 unit_vector = new Vector2((force_of_push*x_error/magnitude), (force_of_push*y_error/magnitude));
            
            ship.attachedRigidbody.AddForce(unit_vector);
            // Debug.Log(force_of_push * unit_vector); 
        }
    }

}
