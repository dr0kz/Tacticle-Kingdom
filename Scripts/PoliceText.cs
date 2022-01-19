using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PoliceText : MonoBehaviour
{
    private TextMeshProUGUI textMP;
    void Start()
    {
        textMP = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMP.text=PoliceCar.playersKilled.ToString();
    }
}
