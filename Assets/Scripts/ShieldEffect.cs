using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Shield")]
public class ShieldEffect : PowerupBehavior
{
    public bool invulnerable = false;
    public override void Apply(GameObject targetObj)
    {
        targetObj.GetComponent<playerScript>().isInvulnerable = true;
        targetObj.GetComponent<playerScript>().healthValue = 101;
    }

    public override void Remove(GameObject targetObj)
    {
        targetObj.GetComponent<playerScript>().isInvulnerable = false;
        targetObj.GetComponent<playerScript>().healthValue = 100;
    }
}
