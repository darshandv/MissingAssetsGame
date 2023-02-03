using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public PlayerWeapon weapon;
    // public Transform target;

    Vector2 moveDirection;
    Vector2 mousePosition;

    public Transform customPivot;

    private static long energy = 50;
    private static long health = 50;

    
    public int rotateSpeed = 20;
    public bool isDown = false;
    public bool isDead = false; 

    public long getEnergy()
    {
        return energy;
    }
    
    public void reduceEnergy()
    {
        energy = energy - 5;
        if(energy == 0) isDown = true;
    }

    public long getHealth()
    {
        return health;
    }
    
    public void reduceHealth()
    {
        health = health - 5;
        if(health == 0) isDead = true;
    }

    void Start() 
    { 
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        reduceHealth();
        if(health == 0) Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.UpArrow)) {
            rotateSpeed +=20;
            reduceEnergy();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            rotateSpeed -=20;
            rotateSpeed = Mathf.Max(rotateSpeed,0);
        }

        if(isDown) rotateSpeed = 0;
        Vector3 point = customPivot.position;
        Vector3 axis = new Vector3(0, 0, 1);
        

        
        transform.RotateAround(point, axis, Time.deltaTime * rotateSpeed);

        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation= Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;


        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            weapon.Fire();
        }

        // moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    private void FixedUpdate()
    {
        // rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = aimAngle;
    }
}
