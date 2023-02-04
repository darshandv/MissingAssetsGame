using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideFollow : MonoBehaviour
{
    public Transform planetPivot;
    public int rotateSpeed = 100;
    public int planetId;
    public EquationTest et;
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
        if (gl.getRotate(planetId) == 1)
        {
            et.playerBody.velocity = Vector2.zero;
            Vector3 point = planetPivot.position;
            Vector3 axis = new Vector3(0, 0, 1);
            et.playerBody.transform.RotateAround(point, axis, Time.deltaTime * rotateSpeed);

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        gl.putRotate(planetId, 1);

    }


}
