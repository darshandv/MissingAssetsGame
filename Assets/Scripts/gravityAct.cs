using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityAct : MonoBehaviour
{
    public float planetMass;
    // public float planetMass2;
    public float G;
    public Transform centerOfEarth1;
    public Transform centerOfEarth2;

    Rigidbody2D playerBody;
    float playerMass;
    float distance;
    float forceVal1, forceVal2;
    // public int stop = 30; 
    // int counter = 1;
    Vector3 forceDirection1, forceDirection2;
    
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerMass = playerBody.mass; 
        // distance = Vector3.Distance(centerOfEarth.position, transform.position);
        // forceVal = G * (playerMass * planetMass)/(distance*distance);
    }

    // Update is called once per frame
    void Update()
    {   
        distance = Vector3.Distance(centerOfEarth1.position, transform.position);
        forceVal1 = G * (playerMass * planetMass)/(distance*distance);
        forceDirection1 = (centerOfEarth1.position - transform.position).normalized;

        distance = Vector3.Distance(centerOfEarth2.position, transform.position);
        forceVal2 = G * (playerMass * planetMass)/(distance*distance);
        forceDirection2 = (centerOfEarth2.position - transform.position).normalized;
        playerBody.AddForce((forceVal1*forceDirection1) + (forceVal2*forceDirection2));

        Debug.Log((forceVal1*forceDirection1) + (forceVal2*forceDirection2));
    
    }
}
