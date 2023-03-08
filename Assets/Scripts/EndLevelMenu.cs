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
        bool level5Done =
            (scene.name == "Level5")
            && (CollectibleComponent.CollectedComponents == Config.levelCollectibles[4]);
        bool level6Done =
            (scene.name == "Level6")
            && (CollectibleComponent.CollectedComponents == Config.levelCollectibles[5]);
        bool level7Done =
            (scene.name == "Level7")
            && (CollectibleComponent.CollectedComponents == Config.levelCollectibles[6]);
        bool level8Done =
            (scene.name == "Level8")
            && (CollectibleComponent.CollectedComponents == Config.levelCollectibles[7]);

        if (PlayerMovement.getHealth() <= 0 || Config.isDead)
        {
            Pause();
            losingText.SetActive(true);
            winningText.SetActive(false);
            restartButton.SetActive(true);
            nextLevelButton.SetActive(false);
            Debug.Log("INSIDE (PlayerMovement.getHealth() <= 0 || Config.isDead)");
        }
        else if (
            level1Done
            || level2Done
            || level3Done
            || level4Done
            || level5Done
            || level6Done
            || level7Done
            || level8Done
        )
        {
            if (level1Done)
            {
                nextLevel = "Scenes/Level2";
            }
            else if (level2Done)
            {
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
            else if (level5Done)
            {
                nextLevel = "Scenes/Level6";
            }
            else if (level6Done)
            {
                nextLevel = "Scenes/Level7";
            }
            else if (level7Done)
            {
                nextLevel = "Scenes/Level8";
                nextLevelButton.SetActive(false);
            }

            Pause();
            losingText.SetActive(false);
            winningText.SetActive(true);
            restartButton.SetActive(false);
            if (!level7Done) {
                nextLevelButton.SetActive(true);
            }
        }
    }
}
