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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = firePoint.up*fireForce;
    }
}