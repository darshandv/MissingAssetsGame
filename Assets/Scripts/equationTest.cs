using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equationTest : MonoBehaviour
{   
    
    public float planetMass;
    // public float planetMass2;
    public float G;
    public Transform centerOfEarth1;
    public Transform centerOfEarth2;
    // public int impulseForce = 100;
    public Vector2 minPower;
    public Vector2 maxPower;
    public float power = 10f;

    Rigidbody2D playerBody;
    float playerMass;
    float distance;
    float forceVal1, forceVal2;
    // public int stop = 30; 
    // int counter = 1;
    Vector3 forceDirection1, forceDirection2, totalForce;
    //bool pressed = false;

    Vector3 startPoint, endPoint;
    Camera cam;
    Vector2 force;
    public int rotateSpeed = 120;

    //public BezierFollow logic;
    public CollideFollow collideDetected;
    public CollideDetect2 collideDetect2;


    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerMass = playerBody.mass; 
        cam = Camera.main;
        //logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<BezierFollow>();
        collideDetected = GameObject.FindGameObjectWithTag("collide").GetComponent<CollideFollow>();
        collideDetect2 = GameObject.FindGameObjectWithTag("collide1").GetComponent<CollideDetect2>();
        //pressed = false;
        // distance = Vector3.Distance(centerOfEarth.position, transform.position);
        // forceVal = G * (playerMass * planetMass)/(distance*distance);
    }

    // Update is called once per frame
    void Update()
    {   
        
        
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            //Debug.Log("pressed "+startPoint);
        }

        else if (Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;
            force = new Vector2(Mathf.Clamp( startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            playerBody.AddForce(force * power, ForceMode2D.Impulse);
            //Debug.Log("end " + endPoint);
            collideDetected.rotate = false;
            collideDetect2.rotate1 = false;
        }
        else{
            distance = Vector3.Distance(centerOfEarth1.position, transform.position);
            forceVal1 = G * (playerMass * planetMass)/(distance*distance);
            forceDirection1 = (centerOfEarth1.position - transform.position).normalized;

            distance = Vector3.Distance(centerOfEarth2.position, transform.position);
            forceVal2 = G * (playerMass * planetMass)/(distance*distance);
            forceDirection2 = (centerOfEarth2.position - transform.position).normalized;

            if (collideDetected.rotate || collideDetect2.rotate1)
            {
                totalForce = Vector3.zero;
    
            }
            else{
                totalForce = (forceVal1*forceDirection1) + (forceVal2*forceDirection2);  
            }
            playerBody.AddForce(totalForce);

        }

        // if (Input.GetKeyDown(KeyCode.Space)){
        //     // playerBody.AddForce(((Input.mousePosition - transform.position).normalized)*(impulseForce));
        //     playerBody.velocity=((Vector2)Input.mousePosition - (Vector2)transform.position).normalized * impulseForce; 
        // }
        // else{
        //     playerBody.AddForce((forceVal1*forceDirection1) + (forceVal2*forceDirection2));
        // }
        // Debug.Log(playerBody.velocity); 

        // Debug.Log((forceVal1*forceDirection1) + (forceVal2*forceDirection2));
        
        // if(counter<=stop){
        //     forceDirection = (centerOfEarth.position - transform.position).normalized;
        //     playerBody.AddForce(forceVal*forceDirection);
        //     counter+=1;
        //     Debug.Log(playerBody.velocity + " 555 " + playerBody.angularVelocity);  
        // }
        // else if (counter<=stop*2){
        //     playerBody.velocity = Vector2.zero;
        //     playerBody.angularVelocity=0;
        //     counter+=1;
        //     Debug.Log(playerBody.velocity + " 555 " + playerBody.angularVelocity);  
        // }
        // else {
        //     forceDirection = (centerOfEarth.position - transform.position).normalized;
        //     playerBody.AddForce(forceVal*forceDirection);
        //     Debug.Log(playerBody.velocity + " 555 " + playerBody.angularVelocity); 
        // }

        
        
        // if (Input.GetKeyDown(KeyCode.Space)){
        // if (counter>=stop && counter<=stop+1){
        //     forceDirection = (centerOfEarth.position - transform.position).normalized;
        //     playerBody.AddForce(forceVal*forceDirection,ForceMode2D.Impulse ); 
        // }
        // else if(counter<=stop){
        //     forceDirection = (transform.position - centerOfEarth.position).normalized;
        //     playerBody.AddForce(forceVal/2*forceDirection);
        // }
        // counter+=1;
        // Debug.Log(playerBody.velocity + " 555 " + playerBody.angularVelocity);
    }

}
