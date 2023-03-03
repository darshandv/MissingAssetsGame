using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelMenu : MenuBehavior
{
    public GameObject losingText;
    public GameObject winningText;
    public GameObject nextLevelButton;
    public GameObject restartButton;

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
        bool level1Done = (scene.name == "Level1") && (CollectibleComponent.CollectedComponents == 1);
        bool level2Done = (scene.name == "Level2") && (CollectibleComponent.CollectedComponents == 3);
        bool level3Done = (scene.name == "Level3") && (CollectibleComponent.CollectedComponents == 2);
        bool level4Done = (scene.name == "Level4") && (CollectibleComponent.CollectedComponents == 2);

        if (PlayerMovement.getHealth() <= 0 || Config.isDead)
        {
            Pause();
            losingText.SetActive(true);
            winningText.SetActive(false);
            restartButton.SetActive(true);
            nextLevelButton.SetActive(false);
        } else if (level1Done || level2Done || level3Done || level4Done) {
            if (level1Done) {
                nextLevel = "Level2";
            } else if (level2Done) {
                nextLevel = "Level3";
            } else if (level3Done) {
                nextLevel = "Level4";
            } else if (level4Done) {
                nextLevel = "Level5";
            }

            Pause();
            losingText.SetActive(false);
            winningText.SetActive(true);
            restartButton.SetActive(false);
            nextLevelButton.SetActive(true);
        }
    }
}
