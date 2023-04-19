using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text dialogueText;
    public float displayTime = 5.0f;
    public string text = "Default Dialogue";

    private bool playerEntered = false;
    private float timer;

    void Start()
    {
        GetComponent<Renderer>().enabled = false;
        dialogueText.gameObject.SetActive(false);
        timer = displayTime;
    }

    void Update()
    {
        if (playerEntered)
        {   
            timer -= Time.deltaTime;
            if (timer <= 0)
            {   
                dialogueText.gameObject.SetActive(false);
                playerEntered = false;
                timer = displayTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {   
            Debug.Log("Entered dialogue");
            playerEntered = true;
            dialogueText.text = text;
            dialogueText.gameObject.SetActive(true);
        }
    }
}
