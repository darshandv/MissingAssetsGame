using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text textElement;
    public PlayerController player;
    GameObject playerGameObj;

    // void Start() {
    //     playerGameObj = GameObject.Find("Player");
    //     if(playerGameObj != null) {
    //         player = player.GetComponent<PlayerController>();
    //     }
    // }

    string getEnergyText() {
        if (player.getEnergy() > 0) return "Energy: " + player.getEnergy().ToString();
        else return "Ded in the space";
    }
    
    string getHealthText() {
        if(player.getHealth() > 0) return "Health: " + player.getHealth().ToString();
        else return "Health: Ded";
    }

    void Update(){
        textElement.text = getEnergyText() + "\n" + getHealthText();
    }
}
