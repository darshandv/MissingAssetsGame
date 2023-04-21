using UnityEngine;

public class MachineGunEnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public Transform target;
    public EnemyHealthBarBehavior enemyHealthBarBehavior;
    int maxEnemyHealth = 100;
    int health = 100;

    // public PlayerMovement pm;
    public float bulletSpeed = 10f;
    public float fireRate = 0.1f;
    public int numBullets = 5;
    int damagePerBullet;
    public int numBulletsToDie = 5;

    private float timeUntilNextFire = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Config.numberofEnemies += 1;
        if (enemyHealthBarBehavior)
            enemyHealthBarBehavior.SetHealth(maxEnemyHealth, maxEnemyHealth);
        damagePerBullet = maxEnemyHealth / numBulletsToDie;
    }

    void Update()
    {
        if (timeUntilNextFire <= 0)
        {
            FireBullet();
            timeUntilNextFire = 1f / fireRate;
        }
        else
        {
            timeUntilNextFire -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerBullet"))
        {
            numBulletsToDie--;
            health = health - damagePerBullet;
            AnalyticsTracker.playerBulletsHit += 1;
            if (enemyHealthBarBehavior)
                enemyHealthBarBehavior.SetHealth(maxEnemyHealth, health);

            if (numBulletsToDie == 0)
            {
                AnalyticsTracker.enemiesKilled += 1;
                Destroy(gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            Vector3 aimDirection = new Vector2(target.position.x, target.position.y) - rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 90f;
            rb.rotation = aimAngle;
        }
    }

    void FireBullet()
    {
        if (!target)
            return;
        // Set bullet direction to point towards target
        Vector2 bulletDirection = (Vector2)target.position - (Vector2)bulletSpawnPoint.position;

        // Set the distance between the bullets
        float distanceBetweenBullets = 0.5f;

        // Calculate the starting position for the first bullet
        Vector3 startingPosition =
            bulletSpawnPoint.position
            - ((numBullets - 1) * distanceBetweenBullets * bulletSpawnPoint.right) / 2;

        // Vector2 direction = (target.position - bullet.transform.position).normalized;

        // Spawn the bullets in parallel with the calculated spacing
        for (int i = 0; i < numBullets; i++)
        {
            GameObject bullet = Instantiate(
                bulletPrefab,
                startingPosition + (i * distanceBetweenBullets * bulletSpawnPoint.right),
                bulletSpawnPoint.rotation
            );

            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = bulletDirection.normalized * bulletSpeed;
        }
    }
}
