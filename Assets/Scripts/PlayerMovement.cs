using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed = 0f; 
    public float orientation; 
    

    public Rigidbody2D player_rigid_body;
    private float thrustPower = 0.9f; 

    public int limit = 3;

    public PlayerWeapon weapon;

    private static long health = 100;
    public bool isDead = false;
    public int numberOfEnemiesKilled = 0;
    public bool isInvulnerable = false;

    public void resetHealth()
    {
        health = 100;
    }

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

    public void increaseEnemyKills(){
        numberOfEnemiesKilled+=1;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (!isInvulnerable) reduceHealth();
        Debug.Log(health);
        if(health == 0) {
            Destroy(gameObject);
            StatisticsManager.buildAnaltyicsDataObjAndPush(0,1,"DeathByEnemy","0%",0,"player_termination","enemy");
            StatisticsManager.buildAnaltyicsDataObjAndPush(numberOfEnemiesKilled,1,"NumEnemiesKilled","0%",0,"numEnemiesKilled","enemy");
        }
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

    public void restart()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        resetHealth();
   }

    void gameOver()
    {
        Invoke ("restart", 5);
    }


    
    void Start(){
        player_rigid_body = this.GetComponent<Rigidbody2D>();
        // player_rigid_body.velocity = Vector3.right * 2;
        
        
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(orientation);

        enableRotation(); 

        if(numberOfEnemiesKilled == limit)
        {
            gameOver();
        }


        // if (Input.GetKey("up") || Input.GetKey(KeyCode.W)) {
        //     Vector2 force = new Vector2(-thrustPower * Mathf.Sin(Mathf.Deg2Rad * orientation), thrustPower * Mathf.Cos(Mathf.Deg2Rad * orientation)); 
        //     player_rigid_body.AddForce(force);
        // }

        // if (Input.GetKey("down")) {

        // }

        // if (Input.GetKey("right") || Input.GetKey(KeyCode.D)) {
        //     Vector2 force = new Vector2(thrustPower * Mathf.Cos(Mathf.Deg2Rad * orientation), thrustPower * Mathf.Sin(Mathf.Deg2Rad * orientation)); 
        //     player_rigid_body.AddForce(force);
        // }

        // if (Input.GetKey("down") || Input.GetKey(KeyCode.S)) {
        //     Vector2 force = new Vector2(thrustPower * Mathf.Sin(Mathf.Deg2Rad * orientation), -thrustPower * Mathf.Cos(Mathf.Deg2Rad * orientation)); 
        //     player_rigid_body.AddForce(force);
        // }
        
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
