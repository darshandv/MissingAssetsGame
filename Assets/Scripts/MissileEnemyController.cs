using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public class MissileEnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject missilePrefab;
    public Transform missileSpawnPoint;
    public Transform target;
    public float initialMissileSpeed = 0f;
    public float maxMissileSpeed = 50f;
    public float accelerationTime = 1f;
    public float fireRate = 2.0f;

    // public float pauseTime = 0.5f;

    private float currentMissileSpeed;
    private float timeUntilNextFire;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // currentMissileSpeed = initialMissileSpeed;
        // timeUntilNextFire = fireRate;
        InvokeRepeating("FireMissile", 0f, fireRate);
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

    async void FireMissile()
    {
        currentMissileSpeed = initialMissileSpeed;
        timeUntilNextFire = fireRate;
        GameObject missile = Instantiate(
            missilePrefab,
            missileSpawnPoint.position,
            Quaternion.LookRotation(Vector3.forward, target.position - missileSpawnPoint.position)
        );

        Rigidbody2D missileRigidbody = missile.GetComponent<Rigidbody2D>();
        missileRigidbody.velocity =
            (target.position - missileSpawnPoint.position).normalized * initialMissileSpeed;

        await Task.Delay(500);
        AccelerateMissile();
        Debug.Log("BEFORE:::::: AccelerateMissile invoked " + currentMissileSpeed);
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
