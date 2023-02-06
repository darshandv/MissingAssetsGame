using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDetect2 : MonoBehaviour
{

    public Transform customPivot;
    public Transform player;
    public int rotateSpeed = 120;
    Rigidbody2D playerBody;
    public bool rotate1 = false;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = player.GetComponent<Rigidbody2D>();
        //logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<BezierFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate1)
        {
            playerBody.velocity = Vector2.zero;
            Vector3 point = customPivot.position;
            Vector3 axis = new Vector3(0, 0, 1);
            player.RotateAround(point, axis, Time.deltaTime * rotateSpeed);
    
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        // update
        rotate1 = true;

    }

}
