using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public GameObject menuUI;
    public static string nextLevel;

    public GameObject healthBar;
    public GameObject thrustBar;

    //public GameObject warning_message;

    private Camera mainCamera;

    void Start()
    {
        Camera mainCamera = Camera.main;
    }

    private void LoadingNewScene(bool isNextLevel)
    {
        PlayerMovement.resetHealth(isNextLevel);
        CollectibleComponent.CollectedComponents = 0;
        PlayerMovement.numberOfEnemiesKilled = 0;
        Config.ResetAllVariables();
    }

    public void ResetGame()
    {
        Time.timeScale = 1f;
        IsGamePaused = false;
        //warning_message.SetActive(false);
        if (mainCamera)
        {
            CameraFollow cs = mainCamera.GetComponent<CameraFollow>();
            cs.StartGameZoom();
        }
    }

    public void ResumeGame()
    {
        menuUI.SetActive(false);
        healthBar.SetActive(true);
        thrustBar.SetActive(true);

        ResetGame();
    }

    public void Pause()
    {
        menuUI.SetActive(true);
        healthBar.SetActive(false);
        thrustBar.SetActive(false);
        //warning_message.SetActive(false);

        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void RestartGame()
    {
        ResetGame();
        LoadingNewScene(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        // Send metrics to the next level
        AnalyticsTracker.sendMetric2();
        AnalyticsTracker.sendMetric3();
        AnalyticsTracker.sendMetric4();
        AnalyticsTracker.sendMetric5();
        AnalyticsTracker.sendMetric6("NextLevel");
        AnalyticsTracker.sendMetric7();
        AnalyticsTracker.sendMetric8();
        AnalyticsTracker.sendMetric9();
        AnalyticsTracker.sendMetric10();

        ResetGame();
        LoadingNewScene(true);
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
        LoadingNewScene(false);
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
