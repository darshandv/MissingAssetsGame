using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public GameObject menuUI;

    public void ResetGame() {
        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    public void Pause() {
        menuUI.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void RestartGame() {
        ResetGame();
        PlayerMovement.numberOfEnemiesKilled = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerMovement.resetHealth();
    }

    public void MainMenu() {
        ResetGame();
        PlayerMovement.numberOfEnemiesKilled = 0;
        SceneManager.LoadScene("LandingScreen");
        PlayerMovement.resetHealth();
    }

    // can be changed later
    public void QuitGame() {
        ResetGame();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();

        Debug.Log("Quitting Game");
    }
}