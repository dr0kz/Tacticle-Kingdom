using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YearBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public static float slidervalue;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = 1f;
        slider.value = 1f;
        slidervalue = slider.value;
        fill.color = gradient.Evaluate(1f);
        InvokeRepeating("IncreaseYear", 0.1f, 1.55f);
    }
    private void IncreaseYear()
    {
        slider.value -= 0.01f;
        slidervalue = slider.value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
