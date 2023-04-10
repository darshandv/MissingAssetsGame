using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileBoosting : MonoBehaviour
{
    public PlayerMovement Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((Input.GetKey(KeyCode.W)) && (((Player.tc.getThrust())>0.5f)))
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else 
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}