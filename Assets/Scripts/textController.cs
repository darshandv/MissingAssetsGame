using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class textController : MonoBehaviour
{
    public Text thrust;
    public Text health;
    public PlayerMovement player;
    public ThrustBar thrustBar;
    GameObject playerGameObj;

    
    string getThrustText() {
        if (!player) return "Wasted";
        else {
            thrustBar.SetThrust(player.tc.getThrust());
            return player.tc.getThrust().ToString("F1");
        }
    }

    string getHealthText()
    {
        if (!player) return "Wasted";
        else return " "+PlayerMovement.getHealth().ToString();
    }

    void Update(){
        if (Config.healthbarNeeded && Config.thrustbarNeeded) {
            thrust.text = getThrustText();
            health.text = getHealthText();
        } 
    }
}
