using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehavior : MonoBehaviour
{
    public float moveSpeed, healthValue;
    public bool isSpedUp, isInvulnerable;
    float vertical, horizontal;
    Rigidbody2D objRigidBody2d;

    void Start()
    {
        objRigidBody2d = GetComponent<Rigidbody2D>();
        healthValue = 100;
        moveSpeed = 6;
        isSpedUp = false;
        isInvulnerable = false;
    }

    void Update()
    {
        MoveBall();
    }

    void MoveBall() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        objRigidBody2d.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
}