using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public class MissileEnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject missilePrefab;
    public Transform missileSpawnPoint;
    public Transform target;
    public float initialMissileSpeed = 10f;
    public float maxMissileSpeed = 100f;
    public float accelerationTime = 1f;
    public float fireRate = 1.0f;
    public EnemyHealthBarBehavior enemyHealthBarBehavior;
    int maxEnemyHealth = 100;
    int health = 100;

    // public float pauseTime = 0.5f;

    private float currentMissileSpeed;
    private float timeUntilNextFire;

    public int numOfBulletsDie = 5;
    int damagePerBullet;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // currentMissileSpeed = initialMissileSpeed;
        // timeUntilNextFire = fireRate;
        Config.numberofEnemies += 1;
        InvokeRepeating("FireMissile", 0f, fireRate);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerBullet"))
        {
            AnalyticsTracker.playerBulletsHit += 1;
            numOfBulletsDie--;

            if (numOfBulletsDie == 0)
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

    void FireMissile()
    {
        currentMissileSpeed = initialMissileSpeed;
        timeUntilNextFire = fireRate;
        GameObject missile = Instantiate(
            missilePrefab,
            missileSpawnPoint.position, // add an offset to the spawn position
            missileSpawnPoint.rotation * Quaternion.Euler(0f, 0f, 180f) // add 180 degree rotation
        );
        // missile.transform.localScale = new Vector3(-1, 1, 1); // flip horizontally

        Rigidbody2D missileRigidbody = missile.GetComponent<Rigidbody2D>();
        missileRigidbody.velocity =
            (target.position - missile.transform.position).normalized * initialMissileSpeed;
        Debug.Log(
            missileRigidbody.velocity
                + " "
                + (target.position - missile.transform.position).normalized
                + " "
                + (target.position - missile.transform.position)
        );
        // await Task.Delay(500);
        // AccelerateMissile();
        // Debug.Log("BEFORE:::::: AccelerateMissile invoked " + currentMissileSpeed);
    }

    void AccelerateMissile()
    {
        Debug.Log("AccelerateMissile invoked");
        float elapsedTime = 0f;
        float startSpeed = 0f;
        float targetSpeed = maxMissileSpeed;
        while (elapsedTime < accelerationTime)
        {
            currentMissileSpeed = Mathf.Lerp(
                startSpeed,
                targetSpeed,
                Mathf.Pow(elapsedTime / accelerationTime, 2)
            );
            elapsedTime += Time.deltaTime;
        }
        currentMissileSpeed = targetSpeed;
    }
}
