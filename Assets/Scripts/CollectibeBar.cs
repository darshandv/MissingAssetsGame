using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibeBar : MonoBehaviour
{
    public int level;
    private int totalCollectibles;
    private int collectedSoFar;
    public Text collectibleText;
    // Start is called before the first frame update
    void Start()
    {
        collectibleText = GameObject.FindGameObjectWithTag("CollectibleText").GetComponent<Text>();
        totalCollectibles = Config.levelCollectibles[level-1]; 
    }

    // Update is called once per frame
    void Update()
    {
        collectedSoFar = CollectibleComponent.CollectedComponents;
        collectibleText.text = ": "+collectedSoFar+"/"+totalCollectibles;
    }
}
