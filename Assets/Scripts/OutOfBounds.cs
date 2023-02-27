using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    bool outOfBounds = false;
    PlayerMovement playerMovement;
    private float time = 0.0f;
    private float interpolationPeriod = 5f;
    private int counter = 0;

    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (outOfBounds)
        {
            time += Time.deltaTime;

            if (time >= interpolationPeriod || counter==0)
            {
                counter++;
                time = 0.0f;
                playerMovement.reduceHealth(5);
                playerMovement.healthBar.SetHealth(PlayerMovement.getHealth());
                Debug.Log("Health reduce: " + PlayerMovement.getHealth());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetType() == typeof(UnityEngine.BoxCollider2D))
        {
            Debug.Log("exitttt: "+ collision.name);
            outOfBounds = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetType() == typeof(UnityEngine.BoxCollider2D))
        {
            counter = 0;
            outOfBounds = false;
            Debug.Log("enter: "+ collision.name);
        }
    }

   
}
