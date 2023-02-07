using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 10f; 
    public Transform target; 

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            Vector3 newPos = new Vector3(target.position.x, target.position.y, -50f);
            transform.position = Vector3.Slerp(transform.position,newPos, FollowSpeed * Time.deltaTime);
        }
    }
}