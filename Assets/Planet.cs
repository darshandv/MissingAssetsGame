using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public int planetId;
    public float planetMass;
    float distance;
    public EquationTest et;
    public Transform centerOfPlanet;
    GlobalUtility gl;

    // Start is called before the first frame update
    void Start()
    {
        et = GameObject.FindGameObjectWithTag("Logic").GetComponent<EquationTest>();
        gl = GameObject.FindGameObjectWithTag("global").GetComponent<GlobalUtility>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(et.playerBody.position, centerOfPlanet.position);
        gl.putForceDirection(planetId, ((transform.position - et.playerBody.transform.position).normalized));
        gl.putForceVals(planetId, (gl.getG() * (et.playerBody.mass * planetMass) / (distance * distance)));

    }
}
