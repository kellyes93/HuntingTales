using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DashBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // method that sets and fill to the max the cooldown slider
    public void SetMaxDash(float dash)
    {
        slider.maxValue = dash;
        slider.value = dash;
        fill.color = gradient.Evaluate(1f);
    }
    // method that empty to the min value the cooldown slider
    public void SetDash(float dash)
    {
        slider.value = dash;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
