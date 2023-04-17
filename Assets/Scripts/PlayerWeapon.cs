using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 50f;


    public void Fire() 
    {
        AnalyticsTracker.playerBullets += 1;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0f, 0f, 270f));
        bullet.GetComponent<Rigidbody2D>().velocity = firePoint.up*fireForce;
    }
}