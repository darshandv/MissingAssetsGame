using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionScreen : MenuBehavior
{
    // Start is called before the first frame update
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        // need to add checks for Levels 2 and 3 as well once they're completed
        if (sceneName == "Level1") {
            Config.thrustbarNeeded = false;
            Config.healthbarNeeded = false;
        }
        Pause();
    }
}
