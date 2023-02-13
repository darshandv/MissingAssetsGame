using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Shield")]
public class ShieldEffect : PowerupBehavior
{
    public bool invulnerable = false;
    public override void Apply(GameObject targetObj)
    {
        targetObj.GetComponent<PlayerMovement>().isInvulnerable = true;
        targetObj.GetComponentInChildren<ShieldController>().shielded = true;
    }

    public override void Remove(GameObject targetObj)
    {
        targetObj.GetComponent<PlayerMovement>().isInvulnerable = false;
        targetObj.GetComponentInChildren<ShieldController>().shielded = false;
    }
}
