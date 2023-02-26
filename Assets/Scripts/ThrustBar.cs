using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrustBar : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Image fill;

	public void SetThrust(float thrust)
	{
	
		slider.value = thrust;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
