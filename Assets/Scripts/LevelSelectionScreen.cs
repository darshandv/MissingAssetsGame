using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionScreen : MonoBehaviour
{
    public void MainMenuSelection() {
        SceneManager.LoadScene("LandingScreen");
    }

    public void Level1Selection()
    {
        SceneManager.LoadScene(Config.levels[0]);
    }

    public void Level2Selection()
    {
        SceneManager.LoadScene(Config.levels[1]);
    }
    public void Level3Selection()
    {
        SceneManager.LoadScene(Config.levels[2]);
    }
    public void Level4Selection()
    {
        SceneManager.LoadScene(Config.levels[3]);
    }

    public void Level5Selection()
    {
        SceneManager.LoadScene(Config.levels[4]);
    }

    public void Level6Selection()
    {
        SceneManager.LoadScene(Config.levels[5]);
    }

    public void Level7Selection()
    {
        SceneManager.LoadScene(Config.levels[6]);
    }

    public void Level8Selection()
    {
        SceneManager.LoadScene(Config.levels[7]);
    }

    public void Level9Selection()
    {
        SceneManager.LoadScene(Config.levels[8]);
    }

    public void Level10Selection()
    {
        SceneManager.LoadScene(Config.levels[9]);
    }

    public void Level11Selection()
    {
        SceneManager.LoadScene(Config.levels[10]);
    }

    public void Level12Selection()
    {
        SceneManager.LoadScene(Config.levels[11]);
    }
}
