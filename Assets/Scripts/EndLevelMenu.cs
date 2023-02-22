using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelMenu : MenuBehavior
{
    public GameObject losingText;
    public GameObject winningText;
    // Start is called before the first frame update
    void Start()
    {
        menuUI.SetActive(false);
        IsGamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        bool level1Done = (scene.name == "Level1") && (PlayerMovement.numberOfEnemiesKilled == 1);
        bool level2Done = (scene.name == "Level2") && (PlayerMovement.numberOfEnemiesKilled == 6);

        if (PlayerMovement.getHealth() <= 0) {
            Pause();
            losingText.SetActive(true);
            winningText.SetActive(false);
        } else if (level1Done ||
                   level2Done ||
                   (PlayerMovement.numberOfEnemiesKilled == PlayerMovement.maxEnemiesLimit)) {
            Pause();
            losingText.SetActive(false);
            winningText.SetActive(true);
        }
    }
}
