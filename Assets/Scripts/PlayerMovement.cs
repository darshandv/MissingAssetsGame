using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2f;
    public float orientation;

    public HealthBar healthBar;

    public Rigidbody2D player_rigid_body;
    public float thrustPower = 0.1f; // 0.05f for local testing, build yet to be decided

    public static int maxEnemiesLimit = 3;

    public PlayerWeapon weapon;

    public bool isDead = false;
    public static int numberOfEnemiesKilled = 0;
    public bool isInvulnerable = false;

    private static long health = 50;
    private static int regHealthReduction = 5;

    // Thrust
    public ThrustController tc;
    private bool isReducingThrust = false;
    private float thrustReductionStartTime = 0f;
    private bool isThrustKeyReleased = true;

    public bool thrustZero = false;

    public int missileDamage = 10;

    public static void resetHealth()
    {
        health = 100;
    }

    public static long getHealth()
    {
        return health;
    }

    public void reduceHealth(int value)
    {
        health = health - value;
        if (health <= 0)
        {
            isDead = true;
            // Analytics to be sent here
        }
    }

    public void increaseEnemyKills()
    {
        numberOfEnemiesKilled += 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isInvulnerable)
        {
            // reduceHealth(regHealthReduction);
            healthBar.SetHealth(getHealth());
            if (collision.collider.CompareTag("Enemy"))
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                // reduceHealth((int)(collision.relativeVelocity.magnitude));

                //apply force in the opposite direction
                // Get the colliding object's rigidbody2D component
                Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
                // Debug.Log(playerRigidbody);
                if (playerRigidbody != null)
                {
                    // Calculate the force to be applied in the opposite direction of the collision
                    Vector2 forceDirection = -collision.contacts[0].normal;
                    float forceMagnitude = collision.relativeVelocity.magnitude * 10;
                    Vector2 force = forceDirection * forceMagnitude;

                    // Apply the force to the colliding object's rigidbody2D component
                    playerRigidbody.AddForce(force, ForceMode2D.Impulse);
                }
            }
            else if (collision.gameObject.name.Contains("Asteroid"))
            {
                reduceHealth((int)(collision.relativeVelocity.magnitude));
            }
            else if (collision.collider.CompareTag("Missile"))
            {
                //enemy bullets
                reduceHealth(missileDamage);
                Debug.Log("MISSILE DAMAGE TRIGGERED");
            }
            else
            {
                //enemy bullets
                reduceHealth(regHealthReduction);
            }
        }
        Debug.Log(health);
        if (health <= 0)
        {
            Destroy(gameObject);
            if (collision.collider.CompareTag("EnemyBullet"))
            {
                AnalyticsTracker.sendMetric1("enemy");
                AnalyticsTracker.sendMetric6("enemy");
            }
            AnalyticsTracker.sendMetric2();
            AnalyticsTracker.sendMetric3();
            AnalyticsTracker.sendMetric4();
            AnalyticsTracker.sendMetric5();
            AnalyticsTracker.sendMetric7();
            AnalyticsTracker.sendMetric8();
            AnalyticsTracker.sendMetric9();
            AnalyticsTracker.sendMetric10();

            // StatisticsManager.buildAnaltyicsDataObjAndPush(0,1,"DeathByEnemy","0%",0,"player_termination","enemy");
            // StatisticsManager.buildAnaltyicsDataObjAndPush(numberOfEnemiesKilled,1,"NumEnemiesKilled","0%",0,"numEnemiesKilled","enemy");
        }
    }

    void enableRotation()
    {
        // Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(
            Input.mousePosition / (Screen.width / Screen.height)
        );

        Vector2 aimDirection = mousePosition - player_rigid_body.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        player_rigid_body.rotation = aimAngle;

        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
        orientation = aimAngle;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        resetHealth();
        healthBar.SetHealth(100);
    }

    void gameOver()
    {
        Invoke("restart", 5);
    }

    private void applyForceOnPlayer()
    {
        Vector2 force = new Vector2(
            -thrustPower * Mathf.Sin(Mathf.Deg2Rad * orientation),
            thrustPower * Mathf.Cos(Mathf.Deg2Rad * orientation)
        );
        player_rigid_body.AddForce(force, ForceMode2D.Impulse);
    }

    private void applyNegForceOnPlayer()
    {
        if (Config.isInPlanet)
            return;

        float brakeForce = thrustPower * 0.8f;
        Vector2 brakeDirection = -player_rigid_body.velocity.normalized;
        Vector2 force = brakeDirection * brakeForce;
        player_rigid_body.AddForce(force, ForceMode2D.Impulse);

        // Apply an additional deceleration force once the player's 
        // speed has been reduced to a certain threshold
        float brakeThreshold = 0.05f;
        if (player_rigid_body.velocity.magnitude < brakeThreshold)
        {
            float decelerationForce = brakeForce * 0.5f;
            Vector2 decelerationDirection = -player_rigid_body.velocity.normalized;
            Vector2 deceleration = decelerationDirection * decelerationForce;
            player_rigid_body.AddForce(deceleration, ForceMode2D.Impulse);
        }
    }

    private void allowLimitedThrust()
    {
        // Now you can continuously press W key and keep applying force to
        // change direction and movement. After every second the thrust reduces
        // if you long press W
        if (tc.getThrust() > 0.04)
        {
            if (thrustZero)
            {
                AnalyticsTracker.thrustZeroCounter++;
                thrustZero = false;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Reduce thrust instantly
                applyForceOnPlayer();
                tc.reduceThrust(
                    (
                        (Config.currentLevel == 3)
                            ? Config.thrustReductionAmountLevel3
                            : Config.thrustReductionAmount
                    ) * 0.1f
                );
                isThrustKeyReleased = false;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                // Reduce thrust continuously if key is held down
                applyForceOnPlayer();
                if (!isReducingThrust)
                {
                    isReducingThrust = true;
                    thrustReductionStartTime = Time.time;
                }
                if (Time.time - thrustReductionStartTime >= Config.thrustReductionDelay)
                {
                    tc.reduceThrust(Config.thrustReductionAmount * Time.deltaTime);
                }
                isThrustKeyReleased = false;
            }
            else if (!isThrustKeyReleased)
            {
                // Reset variables when key is released
                isReducingThrust = false;
                thrustReductionStartTime = 0f;
                isThrustKeyReleased = true;
            }
        }
        else
        {
            isThrustKeyReleased = true;
            thrustZero = true;
        }
        if (isThrustKeyReleased)
        {
            tc.increaseThrust(
                (
                    (Config.currentLevel == 3)
                        ? Config.thrustIncrementAmountLevel3
                        : Config.thrustIncrementAmount
                ) * Time.deltaTime
            );
        }
    }

    void Start()
    {
        healthBar.SetHealth(getHealth());
        player_rigid_body = this.GetComponent<Rigidbody2D>();
        // player_rigid_body.velocity = Vector3.right * 2;
        tc = new ThrustController();
        thrustPower = 0.12f; // 0.05f for local testing, build yet to be decided
        AnalyticsTracker.timeStampRecord = new DateTimeOffset(
            DateTime.UtcNow
        ).ToUnixTimeMilliseconds(); // To record first level time
    }

    // Update is called once per frame
    void Update()
    {
        if (!MenuBehavior.IsGamePaused)
        {
            //Debug.Log(orientation);

            enableRotation();

            // if(numberOfEnemiesKilled == maxEnemiesLimit)
            // {
            //     gameOver();
            // }

            if (Input.GetKey(KeyCode.S))
            {
                applyNegForceOnPlayer();
                // Debug.Log("S");
            }

            if (Config.useThrustControl)
            {
                allowLimitedThrust();
            }
            else
            {
                if (Input.GetKey(KeyCode.W))
                {
                    applyForceOnPlayer();
                }
            }
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

            // if (Input.GetMouseButton(0)) {
            //     Vector2 force = new Vector2(-thrustPower * Mathf.Sin(Mathf.Deg2Rad * orientation), thrustPower * Mathf.Cos(Mathf.Deg2Rad * orientation));
            //     player_rigid_body.AddForce(force);
            //     // StatisticsManager.buildAnaltyicsDataObjAndPush(level:0, type:"ThrustPress")
            // }

            if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.E)))
            {
                weapon.Fire();
            }

            if (player_rigid_body.velocity.magnitude > playerSpeed)
            {
                player_rigid_body.velocity = player_rigid_body.velocity.normalized * playerSpeed;
            }
        }
        AnalyticsTracker.health = health;
        AnalyticsTracker.thrust = tc.getThrust();
    }
}
