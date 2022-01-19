using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEffect : MonoBehaviour
{
    public Slider slider;
    public GameObject gm;
    public float SpawnTime;
    public int CharacterMoney;

    void Start()
    {
        gm.SetActive(false);
        slider.maxValue = SpawnTime;
        slider.value = SpawnTime;
    }
    public void Repeat()
    {
        if (GameManager.GameOver == false && GameManager.Paused == false)
        {
            if (MoneyScript.moneyValue >= CharacterMoney)
            {
                gm.SetActive(true);
                slider.maxValue = SpawnTime;
                InvokeRepeating("RepeatSlider", 0f, 0.01f);
            }
        }
    }
    public void RepeatSlider()
    {
        slider.value -= 0.01f;
        if(slider.value==0)
        {
            gm.SetActive(false);
            CancelInvoke();
            slider.maxValue = SpawnTime;
            slider.value = slider.maxValue;
        }

    }
}
