using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public GameObject menuUI;
    public static string nextLevel;

    private void LoadingNewScene() {
        PlayerMovement.resetHealth();
        CollectibleComponent.CollectedComponents = 0;
        PlayerMovement.numberOfEnemiesKilled = 0;
        Config.ResetAllVariables();
    }

    public void ResetGame()
    {
        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    public void ResumeGame() {
        menuUI.SetActive(false);
        ResetGame();
    }

    public void Pause()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void RestartGame()
    {
        ResetGame();
        LoadingNewScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        ResetGame();
        LoadingNewScene();
        SceneManager.LoadScene(nextLevel);
        nextLevel = "";
        
        // LevelChange levelChange = Camera.main.GetComponent<LevelChange>();
        
        // levelChange.LoadNextLevel(); //change location for calling this
        // // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Debug.Log("HAPPENING");
        
        // CollectibleComponent.ResetCollectedComponents();
    }

    public void MainMenu()
    {
        ResetGame();
        LoadingNewScene();
        SceneManager.LoadScene("LandingScreen");
    }

    // can be changed later
    public void QuitGame()
    {
        ResetGame();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();

        Debug.Log("Quitting Game");
    }
}
