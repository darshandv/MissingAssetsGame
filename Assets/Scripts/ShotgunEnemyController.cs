using UnityEngine;

public class ShotgunEnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public Transform target;
    public float bulletSpeed = 100f;
    public float bulletLifetime = 3f;
    public float damage = 10f;
    public float cooldownTime = 5f;

    private float timeUntilNextFire = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Subtract the actual time passed between frames from timeUntilNextFire
        timeUntilNextFire -= Time.deltaTime;

        if (timeUntilNextFire <= 0)
        {
            FireBullet();
            timeUntilNextFire = cooldownTime;
        }
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
        GameObject bullet = Instantiate(
            bulletPrefab,
            bulletSpawnPoint.position,
            bulletSpawnPoint.rotation
        );

        // set bullet direction to point towards target
        Vector2 bulletDirection = (Vector2)target.position - (Vector2)bulletSpawnPoint.position;

        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = bulletDirection.normalized * bulletSpeed;
        // bulletRigidbody.angularVelocity = 0f;
    }
}
