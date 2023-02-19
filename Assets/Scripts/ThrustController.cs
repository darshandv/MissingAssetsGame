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

    public float getThrust(){
        return thrust;
    }

}
