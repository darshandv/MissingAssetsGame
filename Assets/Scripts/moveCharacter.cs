using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCharacter : MonoBehaviour
{
    public float speed= 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector2 posit = transform.position;
        posit.x += hor * speed * Time.deltaTime;
        posit.y += ver * speed * Time.deltaTime; 

        transform.position = posit;
        // Debug.Log("Pos" + hor + " " + ver);
    }
}
