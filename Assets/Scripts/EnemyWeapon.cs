using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 1f;

    public void Fire(Transform target) 
    {
        if (target) {
            
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Vector2 direction = (target.position - bullet.transform.position).normalized;

            bullet.GetComponent<Rigidbody2D>().velocity = direction * fireForce;

        }
    }
}
