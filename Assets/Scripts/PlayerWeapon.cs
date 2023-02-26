using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float initialBulletSpeed;
    public float maxBulletSpeed;
    public float bulletAcceleration;

    private float currentBulletSpeed;


    void Update()
    {
        // Increase the bullet speed over time
        currentBulletSpeed = Mathf.Clamp(
            currentBulletSpeed + bulletAcceleration * Time.deltaTime,
            initialBulletSpeed,
            maxBulletSpeed
        );
    }

    public void Fire()
    {
        initialBulletSpeed = 0.1f;
        maxBulletSpeed = 35f;
        bulletAcceleration = 0.1f;

        // Create a new instance of the bullet prefab at the bullet spawn point
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the rigidbody component of the bullet and set its initial velocity
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = firePoint.up * currentBulletSpeed;
    }
}
