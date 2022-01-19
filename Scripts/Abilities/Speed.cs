using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour
{
    public int Price;
    public Button SpeedButton;
    public void SpeedAbility()
    {
        if (GameManager.GameOver == false && GameManager.Paused == false && DiamondScript.diamondValue >= Price)
        {
            SoundManager.PlaySound("speedsound");
            DiamondScript.diamondValue -= Price;
            GameManager.Diamonds = DiamondScript.diamondValue;
            PlayerBaseClass.CharacterSpeed += 3f;
            SpeedButton.interactable = false;
            StartCoroutine(changeSpeed());
            StartCoroutine(EnableSpeedButton());
        }
    }
    private IEnumerator EnableSpeedButton()
    {
        yield return new WaitForSeconds(15f);
        SpeedButton.interactable = true;
    }
    private IEnumerator changeSpeed()
    {
        yield return new WaitForSeconds(3.5f);
        PlayerBaseClass.CharacterSpeed -= 3f;

    }

}
