using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int PlayerCastleLevel =0;
    public int CastleUpgradStatus = 0;
    public static int Diamonds = 0;
    public int Gold = 500;
    public int level = 1;
    public static int currentLevel = 0;
    public int[] UnlockedCharacters;
    public int[] unlockedAbilities;

    public static bool ShieldAbilityEnable = false;
    public int Price;
    public Button ShieldButton;
    public Button PauseButton;
    // for showing the only players we can use in the scene ( previously we unlock them in the shop menu )
    public GameObject Player3;
    public GameObject Archer;
    public GameObject Mage;
    public GameObject Elf;
    //
    public GameObject Ability1;
    public GameObject Ability2;
    public GameObject Ability3;
    public GameObject Ability4;
    //
    public GameObject ContinueButton;

    public static bool GameOver = false; //boolean for determinating if the game is lose or win ( false - game is plaing , true - opposite)
    public static bool Paused = false; //boolean for determinating if the game is paused

    public GameObject WinMenu; // this menu will appear if we win the level
    public GameObject LoseMenu; //this menu will appear if we lose 
    public GameObject DiamondsReward;

    public static bool alreadyPlaying = false; //for playing win/lose sound only once

    public void ShieldAbility()
    {
        if(GameOver == false && Paused == false && DiamondScript.diamondValue>=Price)
        {
            SoundManager.PlaySound("shieldsound");
            PlayerBaseClass.Shield = true;
            DiamondScript.diamondValue -= Price;
            Diamonds = DiamondScript.diamondValue;
            ShieldButton.interactable = false;
            StartCoroutine(RemoveShield());
            StartCoroutine(EnableShieldButton());
        }

    }
    private IEnumerator EnableShieldButton()
    {
        yield return new WaitForSeconds(20f);
        ShieldButton.interactable = true;
    }
    private IEnumerator RemoveShield()
    {
        yield return new WaitForSeconds(3.5f);
        PlayerBaseClass.Shield = false;

    }
    public void SaveLevel()
    {
        SaveSystem.SaveLevel(level,Diamonds,Gold, UnlockedCharacters, unlockedAbilities, PlayerCastleLevel, CastleUpgradStatus);
    }
    public void LoadLevel()
    {
        LevelsData data = SaveSystem.LoadLevel();
        Gold = data.Gold;
        PlayerCastleLevel = data.PlayerCastleLevel;
        CastleUpgradStatus = data.CastleUpgradStatus;
        Diamonds = data.Diamonds;
        level = data.level;
        UnlockedCharacters = new int[6];
        for (int i=0;i<6;i++)
        {
            UnlockedCharacters[i] = data.unlockedPlayers[i];
        }
        unlockedAbilities = new int[4];
        for(int i=0;i<4;i++)
        {
            unlockedAbilities[i] = data.UnlockedAbilities[i];
        }
        MoneyScript.moneyValue = Gold;
        DiamondScript.diamondValue = Diamonds;
    }
    public void ShowUnlockedAbilities()
    {
        Ability1.SetActive(false);
        Ability2.SetActive(false);
        Ability3.SetActive(false);
        Ability4.SetActive(false);
        for(int i=0;i<4;i++)
        {
            if(unlockedAbilities[i]==1 && i==0)
            {
                Ability1.SetActive(true);
            }
            else if (unlockedAbilities[i] == 1 && i == 1)
            {
                Ability2.SetActive(true);
            }
            else if(unlockedAbilities[i] == 1 && i == 2)
            {
                Ability3.SetActive(true);
            }
            else if(unlockedAbilities[i] == 1 && i == 3)
            {
                Ability4.SetActive(true);
            }
        }
    }
    public void ShowUnlockedCharacters()
    {
        Player3.SetActive(false);
        Archer.SetActive(false);
        Mage.SetActive(false);
        Elf.SetActive(false);
        for (int i=2;i<6;i++)
        {
            if(UnlockedCharacters[i]==1 && i==2)
            {
                Player3.SetActive(true);
            }
            else if(UnlockedCharacters[i] == 1 && i == 3)
            {
                Archer.SetActive(true);
            }
            else if (UnlockedCharacters[i] == 1 && i == 4)
            {
                Mage.SetActive(true);
            }
            else if (UnlockedCharacters[i] == 1 && i == 5)
            {
                Elf.SetActive(true);
            }
        }

    }
    void Start()
    {
        PlayerInstantiating.SpawnedCharacters = 0;
        Time.timeScale = 1.0f;
        LoadLevel();
        alreadyPlaying = false;
        LoseSound.isPlaying = false;
        GameOver = false;
        Paused = false;
        PauseButton.interactable = true;
        PlayerBaseClass.Shield = false;
        PlayerBaseClass.CharacterSpeed = 4f;
        ShowUnlockedCharacters();
        ShowUnlockedAbilities();
        WinMenu.SetActive(false);
        LoseMenu.SetActive(false);
    }
    void Update()
    {
        if (GameOver==true)
        {
            PauseButton.interactable = false;
            Time.timeScale = 0.0f;
            if (PlayerCastle.CastleHealth==0 && alreadyPlaying == false) //If we lose
            {
                LoseMenu.SetActive(true);
                alreadyPlaying = true;
                Diamonds = DiamondScript.diamondValue;
            }
            else if(EnemyCastle.CastleHealth==0 && alreadyPlaying == false)//if we win
            {
                if(currentLevel==level)
                {
                    DiamondsReward.SetActive(true);
                    level++;
                    Diamonds = DiamondScript.diamondValue + 10;
                }
                else
                {
                    Diamonds = DiamondScript.diamondValue;
                }
                SoundManager.PlaySound("winsound");
                WinMenu.SetActive(true);
                alreadyPlaying = true;
            }
            SaveLevel();
        }
    }
    public void LoadSameLevel() //Replay button ( loading the same level )
    {
        SceneManager.LoadScene(currentLevel);
    }
    public void LoadNextLevel() //Loading the next level
    {
        SceneManager.LoadScene(++currentLevel); // ++currentLevel will do the job <---------------------------
        GameOver = false;
        Time.timeScale = 1.0f;
    }
    public void LoadMainMenu() //Loading the main menu
    {
        SoundManager.PlaySound("buttonclick");
        Paused = false;
        SceneManager.LoadScene(0);
        GameOver = false;
        Time.timeScale = 1.0f;
    }
    
}
