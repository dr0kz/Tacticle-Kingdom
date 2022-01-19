
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    public static int moneyValue = 500;
    private int Gold;
    Text money;

    void Start()
    {
        LoadLevel();
        money = GetComponent<Text>();
        InvokeRepeating("MoneyIncrease", 1f, 1);
    }
    private void LoadLevel()
    {
        LevelsData data = SaveSystem.LoadLevel();
        Gold = data.Gold;
    }
    private void MoneyIncrease()
    {
        if(Gold==500)
        {
            moneyValue += 5;
        }
        else if(Gold==750)
        {
            moneyValue += 8;
        }
        else if(Gold==1000)
        {
            moneyValue += 15;
        }
        else
        {
            moneyValue += 20;
        } 
    }
    void Update()
    {
        money.text = " "+moneyValue;
    }
}
