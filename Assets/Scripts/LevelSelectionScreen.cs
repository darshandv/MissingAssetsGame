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
        SceneManager.LoadScene("LevelTraining1");
    }

    public void Level2Selection()
    {
        SceneManager.LoadScene("LevelTraining2");
    }
    public void Level3Selection()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level4Selection()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level5Selection()
    {
        SceneManager.LoadScene("Level3");
    }

    public void Level6Selection()
    {
        SceneManager.LoadScene("Level4");
    }

    public void Level7Selection()
    {
        SceneManager.LoadScene("Level5");
    }

    public void Level8Selection()
    {
        SceneManager.LoadScene("Level6");
    }

    public void Level9Selection()
    {
        SceneManager.LoadScene("Level7");
    }

    public void Level10Selection()
    {
        SceneManager.LoadScene("Level8");
    }

    public void Level11Selection()
    {
        SceneManager.LoadScene("Level9");
    }

    public void Level12Selection()
    {
        SceneManager.LoadScene("Level10");
    }
}
