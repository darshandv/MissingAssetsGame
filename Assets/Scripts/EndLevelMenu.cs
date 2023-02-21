using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelMenu : MenuBehavior
{
    public GameObject losingText;
    public GameObject winningText;
    // Start is called before the first frame update
    void Start()
    {
        menuUI.SetActive(false);
        IsGamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.getHealth() <= 0) {
            Pause();
            losingText.SetActive(true);
            winningText.SetActive(false);
        } else if (PlayerMovement.numberOfEnemiesKilled == PlayerMovement.limit) {
            Pause();
            losingText.SetActive(false);
            winningText.SetActive(true);
        }
    }
}
