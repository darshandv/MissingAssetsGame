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
        firstLevel = Config.levels[6];
    }

    public void StartGame() {
        SceneManager.LoadScene(firstLevel);
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
