using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public GameObject background;
    public GameObject meteor;
    public GameObject speed;
    public GameObject shield;
    public GameObject arrow;
    public GameObject goldenknight;
    public GameObject archer;
    public GameObject mage;
    public GameObject elf;
    public GameObject knight1;
    public GameObject knight2;


    private int infoNumber;
    public void onPress()
    {
        background.SetActive(true);
        if (infoNumber == 0)
        {
            meteor.SetActive(true);
        }
        else if (infoNumber == 1)
        {
            speed.SetActive(true);
        }
        else if (infoNumber == 2)
        {
            shield.SetActive(true);
        }
        else if (infoNumber == 3)
        {
            arrow.SetActive(true);
        }
        else if (infoNumber == 4)
        {
            goldenknight.SetActive(true);
        }
        else if (infoNumber == 5)
        {
            archer.SetActive(true);
        }
        else if (infoNumber == 6)
        {
            mage.SetActive(true);
        }
        else if (infoNumber == 7)
        {
            elf.SetActive(true);
        }
        else if (infoNumber == 8)
        {
            knight1.SetActive(true);
        }
        else if (infoNumber == 9)
        {
            knight2.SetActive(true);
        }
    }

    public void onRelease()
    {
        background.SetActive(false);
        if (infoNumber == 0)
        {
            meteor.SetActive(false);
        }
        else if (infoNumber == 1)
        {
            speed.SetActive(false);
        }
        else if (infoNumber == 2)
        {
            shield.SetActive(false);
        }
        else if (infoNumber == 3)
        {
            arrow.SetActive(false);
        }
        else if (infoNumber == 4)
        {
            goldenknight.SetActive(false);
        }
        else if (infoNumber == 5)
        {
            archer.SetActive(false);
        }
        else if (infoNumber == 6)
        {
            mage.SetActive(false);
        }
        else if (infoNumber == 7)
        {
            elf.SetActive(false);
        }
        else if (infoNumber == 8)
        {
            knight1.SetActive(false);
        }
        else if (infoNumber == 9)
        {
            knight2.SetActive(false);
        }
    }
    public void DisableCharacterInfo()
    {
        meteor.SetActive(false);
        speed.SetActive(false);
        shield.SetActive(false);
        arrow.SetActive(false);
        goldenknight.SetActive(false);
        archer.SetActive(false);
        mage.SetActive(false);
        elf.SetActive(false);
        knight1.SetActive(false);
        knight2.SetActive(false);
    }
    public void SetNumberInfo(int num)
    {
        infoNumber = num;
    }
}
