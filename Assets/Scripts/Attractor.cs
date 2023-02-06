using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {

    public float planetMass;
    public float G;

    public Rigidbody2D playerBody;
    Rigidbody2D planetBody;
    float playerMass; 
    float distance;
    float forceVal;
    Vector3 forceDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        planetBody = GetComponent<Rigidbody2D>();
        playerMass = playerBody.mass;
        // distance = Vector3.Distance(centerOfEarth.position, transform.position);
        // forceVal = G * (playerMass * planetMass)/(distance*distance);
    }

    // Update is called once per frame
    void Update()
    {   
        distance = Vector3.Distance(playerBody.position, planetBody.position);
        forceVal = G * (playerMass * planetMass)/(distance*distance);
        forceDirection = (planetBody.position - playerBody.position).normalized;
        playerBody.AddForce(forceVal*forceDirection);

    }

	// const float G = 667.4f;
    // public float planetMass = 500;
    // float rbmass;

	// public static List<Attractor> Attractors;

	// public Rigidbody2D rb;

    // void Start()
    // {
    //     rb = GetComponent<Rigidbody2D>();
    //     rbmass = rb.mass
    // }

	// void FixedUpdate ()
	// {
	// 	// foreach (Attractor attractor in Attractors)
	// 	// {
	// 	// 	if (attractor != this)
	// 	// 		Attract(attractor);
	// 	// }
    //     Attract(rb);
	// }

	// // void OnEnable ()
	// // {
	// // 	if (Attractors == null)
	// // 		Attractors = new List<Attractor>();

	// // 	Attractors.Add(this);
	// // }

	// // void OnDisable ()
	// // {
	// // 	Attractors.Remove(this);
	// // }

	// void Attract (Rigidbody2D objToAttract)
	// {
	// 	Rigidbody2D rbToAttract = objToAttract;

	// 	Vector3 direction = rbToAttract.position - transform.position;
	// 	float distance = Vector3.Distance(rbToAttract.position, transform.position);

	// 	if (distance == 0f)
	// 		return;

	// 	float forceMagnitude = G * (planetMass * rbToAttract.mass) / Mathf.Pow(distance, 2);
	// 	Vector3 force = direction.normalized * forceMagnitude;

	// 	rbToAttract.AddForce(force);
	// }

}