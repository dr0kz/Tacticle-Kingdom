using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public static int CastleHealth;
    void Start()
    {
        slider = GetComponent<Slider>();
        InvokeRepeating("GetMaxHealth", 0.1f, 0f);   
    }
    void GetMaxHealth()
    {
        slider.maxValue = PlayerCastle.CastleHealth;
        CastleHealth = PlayerCastle.CastleHealth;
        fill.color = gradient.Evaluate(1f);
        CancelInvoke();
    }
    void Update()
    {
        slider.value = PlayerCastle.CastleHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
