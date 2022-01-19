using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Start()
    {
        slider = GetComponent<Slider>();
        InvokeRepeating("GetMaxHealth", 0.1f, 0f);
    }
    void GetMaxHealth()
    {
        slider.maxValue = EnemyCastle.CastleHealth;
        fill.color = gradient.Evaluate(1f);
        CancelInvoke();
    }
    void Update()
    {
        slider.value = EnemyCastle.CastleHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
