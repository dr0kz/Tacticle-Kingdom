using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondScript : MonoBehaviour
{
    public static int diamondValue = 0;
    Text diamonds;

    void Start()
    {
        diamonds = GetComponent<Text>();
    }
    void Update()
    {
        diamonds.text = " " + diamondValue;
    }
}
