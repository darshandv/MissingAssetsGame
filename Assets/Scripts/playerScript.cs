using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float planetMass;
    // public float planetMass2;
    public float G = 1;
    public Transform centerOfPlanet1;
    public Transform centerOfPlanet2;
    public Transform centerOfPlanet3;
    // public int impulseForce = 100;
    public Vector2 minPower = new Vector2(-3,3);
    public Vector2 maxPower = new Vector2(-3,3);
    public float power = 10f;
    public float orbitDistance = 3;

    Rigidbody2D playerBody;
    float playerMass;
    float distance1, distance2, distance3;
    float forceVal1, forceVal2, forceVal3;
    Vector3 forceDirection1, forceDirection2, forceDirection3, totalForce;
    //bool pressed = false;

    Vector3 startPoint, endPoint;
    Vector2 force;
    public int rotateSpeed = 120;


    public PlayerWeapon weapon;

    //public BezierFollow logic;
    // public CollideFollow collideDetected;
    // public CollideDetect2 collideDetect2;


    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerMass = playerBody.mass; 
    }

    void enableRotate(Vector3 point) {

        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            rotateSpeed +=20;
            // reduceEnergy();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            rotateSpeed -=20;
            rotateSpeed = Mathf.Max(rotateSpeed,0);
        }

        Vector3 axis = new Vector3(0, 0, 1);
        transform.RotateAround(point, axis, Time.deltaTime * rotateSpeed);
    }

    void enableCannonRotation() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        Vector2 aimDirection = mousePosition - playerBody.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        playerBody.rotation = aimAngle;

        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation= Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
    }


    void enableShooting() {
        enableCannonRotation();

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            weapon.Fire();
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.W)){
            force = (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            playerBody.velocity = Vector2.zero;
            playerBody.AddForce(force * (playerMass * planetMass)*power, ForceMode2D.Impulse);
        }
        else{
            distance1 = Vector3.Distance(centerOfPlanet1.position, transform.position);
            forceVal1 = G * (playerMass * planetMass)/(distance1*distance1);
            forceDirection1 = (centerOfPlanet1.position - transform.position).normalized;

            distance2 = Vector3.Distance(centerOfPlanet2.position, transform.position);
            forceVal2 = G * (playerMass * planetMass)/(distance2*distance2);
            forceDirection2 = (centerOfPlanet2.position - transform.position).normalized;


            distance3 = Vector3.Distance(centerOfPlanet3.position, transform.position);
            forceVal3 = G * (playerMass * planetMass)/(distance3*distance3);
            forceDirection3 = (centerOfPlanet3.position - transform.position).normalized;


            bool isOrbitting = false;
            Vector3 point = centerOfPlanet1.position;

            if (distance1 < orbitDistance){
                isOrbitting = true;
                point = centerOfPlanet1.position;
            }
            else if (distance2 < orbitDistance){
                isOrbitting = true;
                point = centerOfPlanet2.position;
            } else if (distance3 < orbitDistance){
                isOrbitting = true;
                point = centerOfPlanet3.position;
            }
            
            if(isOrbitting) {
                playerBody.velocity = Vector2.zero;
                enableRotate(point);
                enableShooting();
            }
            else{
                totalForce = (forceVal1*forceDirection1) + (forceVal2*forceDirection2) + (forceVal3*forceDirection3);  
                playerBody.AddForce(totalForce);
            }

        }    
    }
}
