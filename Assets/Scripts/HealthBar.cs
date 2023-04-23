using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class HealthBar : MonoBehaviour
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;

	void Start() {
		string currentScene = SceneManager.GetActiveScene().name;
        int levelNumber = Array.IndexOf(Config.levels,currentScene);

		int health = Config.maxHealth[currentScene];
		slider.maxValue = health;
		slider.value = health;
		fill.color = gradient.Evaluate(1f);
	}

    public void SetHealth(long health)
	{
		slider.value = health;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}
