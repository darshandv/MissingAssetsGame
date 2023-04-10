using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingScreen : MonoBehaviour
{
    public string firstLevel;
    // Start is called before the first frame update
    void Start()
    {
        firstLevel = "LevelTraining1";
    }


    public void StartGame() {
        SceneManager.LoadScene(firstLevel);
    }

    public void LevelSelectionScreen()
    {
        SceneManager.LoadScene("LevelSelectionScreen");
    }

    // Can be changed later
    public void QuitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();

        Debug.Log("Quitting Game");
    }
}
