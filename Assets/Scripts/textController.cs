using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textController : MonoBehaviour
{
    public Text textElement;
    public PlayerMovement player;
    GameObject playerGameObj;

    
    string getHealthText() {
        if(!player) return "Wasted";
        else return "Health: " + player.getHealth().ToString();
    }

    void Update(){
        textElement.text = getHealthText();
    }
}
