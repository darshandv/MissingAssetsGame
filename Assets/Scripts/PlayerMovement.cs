using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed = 0f; 
    public float orientation; 
    

    public Rigidbody2D player_rigid_body;
    private float thrustPower = 1; 

    public PlayerWeapon weapon;

    private static long health = 50;
    public bool isDead = false;

    public long getHealth()
    {
        return health;
    }
    
    public void reduceHealth()
    {
        health = health - 5;
        if(health == 0) {
            isDead = true;
            // Analytics to be sent here
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        reduceHealth();
        Debug.Log(health);
        if(health == 0) Destroy(gameObject);
    }
    
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
            // StatisticsManager.buildAnaltyicsDataObjAndPush(level:0, type:"ThrustPress")
        }

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            weapon.Fire();
        }
    }
}
