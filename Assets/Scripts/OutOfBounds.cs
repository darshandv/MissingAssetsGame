using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    bool reduceHealth = false;
    PlayerMovement playerMovement;
    private float time = 0.0f;
    public float interpolationPeriod = 5f;

    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;

            if (reduceHealth)
            {
                playerMovement.reduceHealth(5);
                Debug.Log("Health reduce: ");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    { 
        Debug.Log("exitttt: ");
        reduceHealth = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        reduceHealth = false;
        Debug.Log("enter: ");
    }
}
