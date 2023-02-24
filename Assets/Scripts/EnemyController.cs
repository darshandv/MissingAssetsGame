using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public EnemyWeapon weapon;
    public PlayerMovement pm;
    public Transform target;
    public float startInterval = 2.0f;
    public float deltaInterval = 2.0f;
    public float range = 10.0f;
    public float increment = 0.05f;
    private Vector2 initialPosition;
    public MovementType movementType = MovementType.None;
    public bool moveY = true;
    private int UP = 1;
    private int direction = 1;
    public float speed = 1.0f;
    public float followStopDistance = 2.5f;



    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Shoot", startInterval ,deltaInterval);
        Config.numberofEnemies += 1;
    }

    void Shoot()
    {   
        if(weapon && target)
        {
            weapon.Fire(target);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {   
        // Avoid enemies dying from other enemy bullets
        if(!collision.gameObject.name.Contains("EnemyBullet")) { // TODO: A better way to identify
            Destroy(gameObject);
            pm.increaseEnemyKills();
        }
    }

    float getPosition(Vector2 current) {
        if(moveY) {
            return current.y;
        }
        else {
            return current.x;
        }
    }

    void setPosition(float pos) {
        if(moveY) {
            transform.position = new Vector2(transform.position.x,pos);
        }
        else {
            transform.position = new Vector2(pos,transform.position.y);
        }
    }

    bool insideBound() {
        if(direction == UP) {
            return getPosition(transform.position) + 1 < getPosition(initialPosition) + range;
        }
        else {
            return getPosition(transform.position) - 1 > getPosition(initialPosition) - range;
        }
    }

    private void addDelta(){
        if(insideBound()){
            setPosition(getPosition(transform.position)+direction*increment);
        }
        else {
            direction *= -1;
        }
    }

    private void follow() {
        if(Vector2.Distance(transform.position,target.position) >= followStopDistance){        
            var step =  speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    private void moveFixedAxis() {
        addDelta();
    }

    private void FixedUpdate()
    {
        if (target) {
            Vector3 aimDirection =  new Vector2(target.position.x, target.position.y) - rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 90f;
            rb.rotation = aimAngle;
        }

        switch (movementType)
        {
            case MovementType.Follow:
                follow();
                break;
            case MovementType.FixedAxis:
                moveFixedAxis();
                break;
            default:
                break;
        } 
            
    }
}