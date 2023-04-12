using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public EnemyHealthBarBehavior enemyHealthBarBehavior;
    // Level 1 attributes
    public int level1Health = 100;
    public float level1MissileSpeed = 5f;
    public float level1FireRate = 1f;
    public int level1MissileDamage = 10;
    public float level1MovementSpeed = 1f;

    // Level 2 attributes
    public int level2Health = 200;
    public float level2MissileSpeed = 7f;
    public float level2FireRate = 0.8f;
    public int level2MissileDamage = 15;
    public float level2MovementSpeed = 1.5f;

    // Level 3 attributes
    public int level3Health = 300;
    public float level3MissileSpeed = 10f;
    public float level3FireRate = 0.6f;
    public int level3MissileDamage = 20;
    public float level3MovementSpeed = 2f;

    public GameObject missilePrefab;
    public GameObject bulletPrefab;

    // public GameObject rocketPrefab;
    public Transform spawnPoint;
    Transform target;

    int currentLevel = 1;
    private int currentHealth;
    private float currentMissileSpeed;

    // Define the fire rate in rounds per second
    public float fireRate = 0.7f;
    public float fireForce = 50f;

    private int missileDamage;
    private float movementSpeed;

    // private float timeUntilNextFire = 0f;
    public float rotationSpeed = 5.0f;

    public float initialMissileSpeed = 5.0f;
    public float initialBulletSpeed = 5.0f;
    public float initialRocketSpeed = 5.0f;

    // private float nextFireTime = 0.0f;

    public float moveSpeed = 3f; // The speed at which the boss moves towards the target
    public float timeUntilNextDodge = 0; // The time until the next dodge
    public float dodgeRate = 3f; // The rate at which the boss dodges attacks
    public float dodgeSpeed = 1f; // The speed at which the boss dodges attacks

    void Start()
    {
        enemyHealthBarBehavior.SetHealth(level1Health, level1Health);

        SetDifficultyLevel();

        target = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("Fire", fireRate, fireRate);

        // InvokeRepeating("Dodge", dodgeRate, dodgeRate);
    }

    void Fire()
    {
        // Choose a random attack pattern
        int attackPattern = Random.Range(1, 3);

        // Fire the appropriate attack
        switch (attackPattern)
        {
            case 1:
                FireMissile();
                break;
            case 2:
                FireBullet();
                break;
            // case 3:
            //     FireRocket();
            //     break;
        }
    }

    void Dodge()
    {
        // Generate a random dodge direction
        Vector2 dodgeDirection = new Vector2(
            Random.Range(-5f, 5f),
            Random.Range(-5f, 5f)
        ).normalized;

        // Move the boss enemy in the dodge direction
        transform.position += (Vector3)dodgeDirection * dodgeSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enemy hit");
        if (collision.collider.CompareTag("PlayerBullet"))
        {
            int damage = Random.Range(3, 6);
            currentHealth -= damage;
            Debug.Log("currentHealth: " + currentHealth);
            enemyHealthBarBehavior.SetHealth(level1Health,currentHealth);
        }
    }

    void Update()
    {
        if (target != null)
        {
            // Calculate the direction to the target
            Vector2 direction = target.position - transform.position;
            direction.Normalize();

            // Rotate the boss enemy towards the target
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                rotation,
                rotationSpeed * Time.deltaTime
            );

            transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
        }

        //Debug.Log("currentHealth: " + currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void SetDifficultyLevel()
    {
        switch (currentLevel)
        {
            case 1:
                currentHealth = level1Health;
                currentMissileSpeed = level1MissileSpeed;
                fireRate = level1FireRate;
                missileDamage = level1MissileDamage;
                movementSpeed = level1MovementSpeed;
                break;
            case 2:
                currentHealth = level2Health;
                currentMissileSpeed = level2MissileSpeed;
                fireRate = level2FireRate;
                missileDamage = level2MissileDamage;
                movementSpeed = level2MovementSpeed;
                break;
            case 3:
                currentHealth = level3Health;
                currentMissileSpeed = level3MissileSpeed;
                fireRate = level3FireRate;
                missileDamage = level3MissileDamage;
                movementSpeed = level3MovementSpeed;
                break;
            default:
                currentHealth = level1Health;
                currentMissileSpeed = level1MissileSpeed;
                fireRate = level1FireRate;
                missileDamage = level1MissileDamage;
                movementSpeed = level1MovementSpeed;
                break;
        }
    }

    void FireMissile()
    {
        currentMissileSpeed = initialMissileSpeed;
        // timeUntilNextFire = fireRate;
        GameObject missile = Instantiate(
            missilePrefab,
            spawnPoint.position, // add an offset to the spawn position
            spawnPoint.rotation * Quaternion.Euler(0f, 0f, 180f) // add 180 degree rotation
        );

        Rigidbody2D missileRigidbody = missile.GetComponent<Rigidbody2D>();
        missileRigidbody.velocity =
            (target.position - missile.transform.position).normalized * initialMissileSpeed;
    }

    // Fire bullet
    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);

        Vector2 direction = (target.position - bullet.transform.position).normalized;

        bullet.GetComponent<Rigidbody2D>().velocity = spawnPoint.up * fireForce;
    }

    // Fire rocket
    // void FireRocket()
    // {
    //     GameObject rocket = Instantiate(rocketPrefab, spawnPoint.position, spawnPoint.rotation);

    //     Rigidbody2D rocketRigidbody = rocket.GetComponent<Rigidbody2D>();
    //     rocketRigidbody.velocity = rocket.transform.up * initialRocketSpeed;
    // }
}
