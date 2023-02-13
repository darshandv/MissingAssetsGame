using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public PlayerMovement pm;
   
   public void restart()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pm.resetHealth();
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