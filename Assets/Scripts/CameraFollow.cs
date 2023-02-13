using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 10f; 
    public Transform target; 

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y, -50f);
            transform.position = Vector3.Slerp(transform.position,newPos, FollowSpeed * Time.deltaTime);
        }
    }
}