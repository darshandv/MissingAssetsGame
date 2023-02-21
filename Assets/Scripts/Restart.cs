using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// DO NOT USE THIS SCRIPT, USE PAUSE MENU FOR RESTARTING LEVEL
public class Restart : MonoBehaviour
{   
   public void restart()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerMovement.resetHealth();
   }

   private void Update() 
   {
        if (Input.GetKeyDown(KeyCode.R))
        {
            restart();
            // Application.LoadLevel(0);
        }
   }
}