using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject[] Locked;
    public Button[] buttons;

    private int level;

    public void LoadScene1()
    {
        SceneManager.LoadScene(1);
        GameManager.currentLevel = 1;
    }
    public void LoadScene2()
    {
        SceneManager.LoadScene(2);
        GameManager.currentLevel = 2;
    }
    public void LoadScene3()
    {
        SceneManager.LoadScene(3);
        GameManager.currentLevel = 3;
    }
    public void LoadScene4()
    {
        SceneManager.LoadScene(4);
        GameManager.currentLevel = 4;
    }
    public void LoadScene5()
    {
        SceneManager.LoadScene(5);
        GameManager.currentLevel = 5;
    }
    public void LoadScene6()
    {
        SceneManager.LoadScene(6);
        GameManager.currentLevel = 6;
    }
    public void LoadScene7()
    {
        SceneManager.LoadScene(7);
        GameManager.currentLevel = 7;
    }
    public void LoadScene8()
    {
        SceneManager.LoadScene(8);
        GameManager.currentLevel = 8;
    }
    public void LoadScene9()
    {
        SceneManager.LoadScene(9);
        GameManager.currentLevel = 9;
    }
    public void LoadScene10()
    {
        SceneManager.LoadScene(10);
        GameManager.currentLevel = 10;
    }
    public void LoadScene11()
    {
        SceneManager.LoadScene(11);
        GameManager.currentLevel = 11;
    }
    public void LoadScene12()
    {
        SceneManager.LoadScene(12);
        GameManager.currentLevel = 12;
    }
    public void LoadScene13()
    {
        SceneManager.LoadScene(13);
        GameManager.currentLevel = 13;
    }
    public void LoadScene14()
    {
        SceneManager.LoadScene(14);
        GameManager.currentLevel = 14;
    }
    public void LoadScene15()
    {
        SceneManager.LoadScene(15);
        GameManager.currentLevel = 15;
    }
    private void LoadLevel()
    {
        LevelsData data = SaveSystem.LoadLevel();
        level = data.level;
    }
    public void LoadLevels()
    {
        LoadLevel();
        for(int i=0;i<14;i++)
        {
            if(i<level-1)
            {
                Locked[i].SetActive(false);
                buttons[i].interactable = true;
            }
            else
            {
                Locked[i].SetActive(true);
                buttons[i].interactable = false;
            }
        }
    }
}
