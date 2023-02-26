using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textController : MonoBehaviour
{
    public Text thrust;
    public Text health;
    public PlayerMovement player;
    GameObject playerGameObj;

    
    string getThrustText() {
        if(!player) return "Wasted";
        else return "Thrust: "+ player.tc.getThrust().ToString("F1");
    }

    string getHealthText()
    {
        if (!player) return "Wasted";
        else return " "+PlayerMovement.getHealth().ToString();
    }

    void Update(){
        thrust.text = getThrustText();
        health.text = getHealthText();
    }
}
