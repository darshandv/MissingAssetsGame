using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Speed")]
public class SpeedEffect : PowerupBehavior
{
    public float speed;
    public override void Apply(GameObject targetObj)
    {
        targetObj.GetComponent<playerScript>().isSpedUp = true;
        targetObj.GetComponent<playerScript>().moveSpeed += speed;
    }

    public override void Remove(GameObject targetObj)
    {
        targetObj.GetComponent<playerScript>().isSpedUp = false;
        targetObj.GetComponent<playerScript>().moveSpeed -= speed;
    }
}
