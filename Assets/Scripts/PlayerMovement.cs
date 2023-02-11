using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed = 0f; 
    public float orientation; 
    

    public Rigidbody2D player_rigid_body;
    private float thrustPower = 1; 

    void enableRotation() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        Vector2 aimDirection = mousePosition - player_rigid_body.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        player_rigid_body.rotation = aimAngle;

        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation= Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
        orientation = aimAngle; 
    }
    
    void Start(){
        player_rigid_body = this.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(orientation);

        enableRotation(); 
        
        if (Input.GetMouseButton(0)) {
            Vector2 force = new Vector2(-thrustPower * Mathf.Sin(Mathf.Deg2Rad * orientation), thrustPower * Mathf.Cos(Mathf.Deg2Rad * orientation)); 
            player_rigid_body.AddForce(force);
        }
    }
}
