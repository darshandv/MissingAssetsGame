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

    // public GameObject warning_message;

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
        bool level1Done =
            (scene.name == "Level1")
            && (CollectibleComponent.CollectedComponents == Config.levelCollectibles[0]);
        bool level2Done =
            (scene.name == "Level2")
            && (CollectibleComponent.CollectedComponents == Config.levelCollectibles[1]);
        bool level3Done =
            (scene.name == "Level3")
            && (CollectibleComponent.CollectedComponents == Config.levelCollectibles[2]);
        bool level4Done =
            (scene.name == "Level4")
            && (CollectibleComponent.CollectedComponents == Config.levelCollectibles[3]);

        if (PlayerMovement.getHealth() <= 0 || Config.isDead)
        {
            Pause();
            losingText.SetActive(true);
            winningText.SetActive(false);
            restartButton.SetActive(true);
            nextLevelButton.SetActive(false);
            Debug.Log("INSIDE (PlayerMovement.getHealth() <= 0 || Config.isDead)");
        }
        else if (level1Done || level2Done || level3Done || level4Done)
        {
            if (level1Done)
            {
                nextLevel = "Scenes/Level2";
            }
            else if (level2Done)
            {
                // TODO: Should change to Level3 after adding it
                nextLevel = "Scenes/Level3";
            }
            else if (level3Done)
            {
                nextLevel = "Scenes/Level4";
            }
            else if (level4Done)
            {
                nextLevel = "Scenes/Level5";
            }

            Pause();
            losingText.SetActive(false);
            winningText.SetActive(true);
            restartButton.SetActive(false);
            nextLevelButton.SetActive(true);
        }
    }
}
