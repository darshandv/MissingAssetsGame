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
        targetObj.GetComponent<MoveBehavior>().isSpedUp = true;
        targetObj.GetComponent<MoveBehavior>().moveSpeed += speed;
    }

    public override void Remove(GameObject targetObj)
    {
        targetObj.GetComponent<MoveBehavior>().isSpedUp = false;
        targetObj.GetComponent<MoveBehavior>().moveSpeed -= speed;
    }
}
