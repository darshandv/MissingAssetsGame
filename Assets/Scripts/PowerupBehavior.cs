using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupBehavior : ScriptableObject
{
    public abstract void Apply(GameObject targetObj);

    public abstract void Remove(GameObject targetObj);
}
