using UnityEngine;

public class MachineGunEnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public Transform target;
    public PlayerMovement pm;
    public float bulletSpeed = 10f;
    public float fireRate = 0.1f;
    public float bulletSpread = 5f;

    private float timeUntilNextFire = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        Destroy(gameObject);
        pm.increaseEnemyKills();
    }

    private void FixedUpdate()
    {
        if (target)
        {
            Vector3 aimDirection = new Vector3(rb.position.x, rb.position.y, 0f) - target.position;

            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = aimAngle;
        }
    }

    void FireBullet()
    {
        // Set bullet direction to point towards target
        Vector2 bulletDirection = (Vector2)target.position - (Vector2)bulletSpawnPoint.position;

        // Set the number of bullets to fire in parallel
        int numBullets = 5;

        // Set the distance between the bullets
        float distanceBetweenBullets = 0.5f;

        // Calculate the starting position for the first bullet
        Vector3 startingPosition =
            bulletSpawnPoint.position
            - ((numBullets - 1) * distanceBetweenBullets * bulletSpawnPoint.right) / 2;

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
