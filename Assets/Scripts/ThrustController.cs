using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustController
{
    private float thrust = (Config.currentLevel == 3) ? Config.maxThrustLevel3 : Config.maxThrust;

    public void reduceThrust(float reduceValue)
    {
        if (thrust >= reduceValue)
        {
            thrust -= reduceValue;
        }
    }

    public void increaseThrust(float increaseValue)
    {
        if (thrust <= Config.maxThrust - increaseValue)
        {
            thrust += increaseValue;
        }
    }

    public float getThrust()
    {
        return thrust;
    }
}
