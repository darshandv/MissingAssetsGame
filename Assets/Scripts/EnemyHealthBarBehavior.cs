using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarBehavior : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;
    public Image fill;

    private Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        Transform enemyContainer = transform.parent;
        enemy = enemyContainer.GetChild(1);
    }

    public void SetHealth(float maxHealth, float health)
    {
        Debug.Log("health "+ health);
        Debug.Log("Max health " + maxHealth);
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;
        Color sCol = Color.Lerp(low, high, slider.normalizedValue);
        //Debug.Log("color" + sCol);
        fill.color = sCol;
        //slider.fillRect.GetComponentInChildren<Image>().color = sCol;
    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(enemy.position + offset);
    }
}
