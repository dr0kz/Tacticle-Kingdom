using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    public GameObject PauseMenu;

    public void PausePressed()
    {
        GameManager.Paused = true;
        SoundManager.PlaySound("buttonclick");
        PauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void ResumePressed()
    {
        SoundManager.PlaySound("buttonclick");
        GameManager.Paused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
