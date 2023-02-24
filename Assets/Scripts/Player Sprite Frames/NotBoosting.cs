using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotBoosting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.GetComponent<Renderer>().enabled=false;
        }
        else 
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}
