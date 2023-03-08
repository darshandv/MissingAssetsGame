using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shield;
    public Rigidbody2D shieldRigidbody2D;
    public bool shielded;

    void Start() {
        shieldRigidbody2D = GetComponent<Rigidbody2D>();
        shielded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!shielded) {
            shield.SetActive(false);
        } else {
            shield.SetActive(true);
        }
    }
}
