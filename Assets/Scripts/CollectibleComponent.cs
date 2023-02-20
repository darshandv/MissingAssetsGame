using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectibleComponent : MonoBehaviour
{
    public static int TotalComponents = 0; // total number of collectible components in the level
    public static int CollectedComponents = 0; // number of collected components

    void Start()
    {
        TotalComponents++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CollectedComponents++;
            Destroy(gameObject);
            if (CollectedComponents >= TotalComponents)
            {
                StartCoroutine(EndLevel());
                // Debug.Log("end level");
            }
        }
        // Debug.Log("Collected items: " + CollectedComponents+" $$$ "+TotalComponents);
    }

    IEnumerator EndLevel()
    {
        // TODO: put your code here to end the level (e.g. load the next scene)
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        int level1 = string.Compare(sceneName, "Level1");
        int level2 = string.Compare(sceneName, "Level2");

        Debug.Log("EndLevel : " + sceneName + " &&& " + level1 + " &&& " + level2);

        if (level1 == 0)
        {
            AsyncOperation nScene = SceneManager.LoadSceneAsync(
                "Scenes/Level2",
                LoadSceneMode.Single
            );
            // SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scenes/Level2"));

            nScene.allowSceneActivation = false;
            // _SceneAsync = nScene;

            //Wait until we are done loading the scene
            while (nScene.progress < 0.9f)
            {
                Debug.Log("Loading scene " + " [][] Progress: " + nScene.progress);
                // yield return null;
            }

            //Activate the Scene
            nScene.allowSceneActivation = true;
            Debug.Log("Loading scene " + " [][] Progress: " + nScene.progress);

            while (!nScene.isDone)
            {
                // wait until it is really finished
                yield return null;
            }

            Scene nThisScene = SceneManager.GetSceneByName("Scenes/Level2");

            if (nThisScene.IsValid())
            {
                Debug.Log("Scene is Valid");
                // SceneManager.MoveGameObjectToScene(UIRootObject, nThisScene);
                SceneManager.SetActiveScene(nThisScene);
            }
            else
            {
                Debug.Log("Invalid scene!!");
            }
        }
        else if (level2 == 0)
        {
            AsyncOperation nScene = SceneManager.LoadSceneAsync(
                "Scenes/Level3",
                LoadSceneMode.Single
            );
            // SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scenes/Level3"));

            nScene.allowSceneActivation = false;
            // _SceneAsync = nScene;

            //Wait until we are done loading the scene
            while (nScene.progress < 0.9f)
            {
                Debug.Log("Loading scene " + " [][] Progress: " + nScene.progress);
                // yield return null;
            }

            //Activate the Scene
            nScene.allowSceneActivation = true;
            Debug.Log("Loading scene " + " [][] Progress: " + nScene.progress);

            while (!nScene.isDone)
            {
                // wait until it is really finished
                yield return null;
            }

            Scene nThisScene = SceneManager.GetSceneByName("Scenes/Level3");

            if (nThisScene.IsValid())
            {
                Debug.Log("Scene is Valid");
                // SceneManager.MoveGameObjectToScene(UIRootObject, nThisScene);
                SceneManager.SetActiveScene(nThisScene);
            }
            else
            {
                Debug.Log("Invalid scene!!");
            }
        }
        // yield return null;
    }
}
