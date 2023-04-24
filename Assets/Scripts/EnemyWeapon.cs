using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletLife = 3f;
    public float fireForce = 1f;

    public void Fire(Transform target) 
    {
        if (target) {
            AnalyticsTracker.totalEnemyBullets += 1;
            
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet mc = bullet.GetComponent<Bullet>();
            mc.lifeTime = bulletLife;

            Vector2 direction = (target.position - bullet.transform.position).normalized;

            bullet.GetComponent<Rigidbody2D>().velocity = direction * fireForce;

        }
    }
}
