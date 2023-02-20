using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustController
{
    private float thrust = Config.maxThrust;
    
    

    public void reduceThrust(float reduceValue){
        if (thrust >= reduceValue){
            thrust -= reduceValue;
        }  
    }

    public void increaseThrust(float increaseValue){
        if (thrust <= Config.maxThrust - increaseValue){
            thrust += increaseValue;
        }
    }

    public float getThrust(){
        return thrust;
    }

}
