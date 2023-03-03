using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public void LoadNextLevel()
    {
        Config.currentLevel++;
        Debug.Log("Config.currentLevel: "+Config.currentLevel);
        if (Config.currentLevel < Config.levels.Length)
        {
            // SceneManager.LoadScene("Level"+Config.currentLevel);
            Debug.Log("Next level" + Config.levels[Config.currentLevel]);
            StartCoroutine(EndLevel(Config.levels[Config.currentLevel]));
        }
        else
        {
            Debug.Log("No more levels!");
        }
    }

    IEnumerator EndLevel(string sceneName)
    {

        AsyncOperation nScene = SceneManager.LoadSceneAsync(
            sceneName,
            LoadSceneMode.Single
        );
        nScene.allowSceneActivation = false;

        while (!nScene.isDone)
        {
            if (nScene.progress >= 0.9f)
            {
                nScene.allowSceneActivation = true;
            }
            Debug.Log("Progress: " + nScene.progress);
            yield return null;
        }

        Scene nThisScene = SceneManager.GetSceneByName("Scenes/" + sceneName);

        if (nThisScene.IsValid())
        {
            Debug.Log("Scene is Valid");
            SceneManager.SetActiveScene(nThisScene);
            // Application.LoadLevel(0);
        }
        else
        {
            Debug.Log("Invalid scene!!");
        }
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9f)
        {
            // yield return null;
        }

        asyncLoad.allowSceneActivation = true;

        //done loading
        yield return null;
    }
}   