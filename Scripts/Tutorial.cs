using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject movementTut;

    public GameObject characterTut;
    void Start()
    {
        Time.timeScale = 0f;
        movementTut.SetActive(true);
        characterTut.SetActive(false);
    }
    public void GotItButton1Pressed()
    {
        movementTut.SetActive(false);
        characterTut.SetActive(true);
    }
    public void GotItButton2Pressed()
    {
        characterTut.SetActive(false);
        Time.timeScale = 1f;
    }
}
