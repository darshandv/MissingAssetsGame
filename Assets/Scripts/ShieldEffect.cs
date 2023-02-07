using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Shield")]
public class ShieldEffect : PowerupBehavior
{
    public bool invulnerable = false;
    public override void Apply(GameObject targetObj)
    {
        targetObj.GetComponent<MoveBehavior>().isInvulnerable = true;
        targetObj.GetComponent<MoveBehavior>().healthValue = 101;
    }

    public override void Remove(GameObject targetObj)
    {
        targetObj.GetComponent<MoveBehavior>().isInvulnerable = false;
        targetObj.GetComponent<MoveBehavior>().healthValue = 100;
    }
}
