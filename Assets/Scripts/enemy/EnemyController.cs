using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public EnemyWeapon weapon;
    public Transform target;
    public float startInterval = 2.0f;
    public float deltaInterval = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Shoot", startInterval ,deltaInterval);
    }

    void Shoot()
    {   
        if(target)
            weapon.Fire(target);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (target) {
            Vector3 aimDirection =  new Vector2(target.position.x, target.position.y) - rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 90f;
            rb.rotation = aimAngle;
        }

    }
}