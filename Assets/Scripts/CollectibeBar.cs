using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectibeBar : MonoBehaviour
{
    private int totalCollectibles;
    private int collectedSoFar;
    public Text collectibleText;
    // Start is called before the first frame update
    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        int levelNumber = System.Array.IndexOf(Config.levels, currentScene);
        collectibleText = GameObject.FindGameObjectWithTag("CollectibleText").GetComponent<Text>();
        totalCollectibles = Config.levelCollectibles[currentScene];

    }

    // Update is called once per frame
    void Update()
    {
        collectedSoFar = CollectibleComponent.CollectedComponents;
        collectibleText.text = ": "+collectedSoFar+"/"+totalCollectibles;
    }
}
