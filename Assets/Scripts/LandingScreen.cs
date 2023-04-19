using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class LandingScreen : MonoBehaviour
{
    public string firstLevel;

    [DllImport("__Internal")]
    private static extern void RefreshPage();

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

    public void ControlsScreen()
    {
        SceneManager.LoadScene("ControlsScreen");
    }

    public void QuitGame() {

        #if UNITY_WEBGL && !UNITY_EDITOR
        RefreshPage();
        #endif


        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
        #endif

        Debug.Log("Quitting Game");
    }
}
