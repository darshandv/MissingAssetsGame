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
        bool level2Done = (scene.name == "Level2") && (PlayerMovement.numberOfEnemiesKilled == 1);
        bool level3Done = (scene.name == "Level3") && (PlayerMovement.numberOfEnemiesKilled == 1);
        bool level4Done = (scene.name == "Level4") && (PlayerMovement.numberOfEnemiesKilled == 6);
        bool sampleSceneDone = (scene.name == "SampleScene") && (PlayerMovement.numberOfEnemiesKilled == 3);

        if (PlayerMovement.isDead || PlayerMovement.getHealth() <= 0) {
            Pause();
            losingText.SetActive(true);
            winningText.SetActive(false);
        } else if (level2Done || level3Done || level4Done || sampleSceneDone) {
            Pause();
            losingText.SetActive(false);
            winningText.SetActive(true);
        }
    }
}
