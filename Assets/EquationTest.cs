using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationTest : MonoBehaviour
{
    public Vector2 minPower;
    public Vector2 maxPower;
    public float power = 10f;

    public Rigidbody2D playerBody;
    Vector3 totalForce, force;

    Vector3 startPoint, endPoint;
    Camera cam;
    Vector2 impactForce;
    int isRotate = 0;
    GlobalUtility gl;


    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        gl = GameObject.FindGameObjectWithTag("global").GetComponent<GlobalUtility>();

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            Debug.Log("Mouse Button down. Panet startPoint: " + startPoint);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;
            impactForce = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            playerBody.AddForce(impactForce * power, ForceMode2D.Impulse);
            Debug.Log("Mouse Button up. Panet endPoint" + endPoint);
            for (int i = 0; i < 2; i++)
            {
                gl.putRotate(i, 0);
            }
        }
        else
        {
            isRotate = 0;
            force = Vector3.zero;
            for (int i = 0; i < 2; i++)
            {
                if (gl.getRotate(i) == 0)
                {
                    force += gl.getForceVals(i) * gl.getForceDirection(i);
                }
                else
                    isRotate = 1;
            }
            Debug.Log("Force " + force);
            if (isRotate == 1)
            {
                totalForce = Vector3.zero;
            }
            else
            {

                totalForce = force;
            }
            playerBody.AddForce(totalForce);

        }
    }

}
