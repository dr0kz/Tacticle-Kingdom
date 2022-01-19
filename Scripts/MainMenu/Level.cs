using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public int CastleUpgradStatus = 0; // integer for the castle image,price in the upgrade menu
    public int playerCastleLevel = 0; // castle level
    public int level = 1; //game level
    public int[] UnlockedCharacters; // unlocked characters(players)
    public int[] UnlockedAbilities;

    public int Diamonds;
    public int Gold;

    public GameObject UnlockGold1;
    public GameObject UnlockGold2;
    public GameObject UnlockGold3;
    public GameObject UnlockGold4;

    public GameObject upgradeGold; //upgrade button in upgrade menu for gold
    public GameObject Unlock1; //unlock button for knight3
    public GameObject Unlock2; //unlock button for archer
    public GameObject Unlock3; //unlock button for mage
    public GameObject Unlock4; //unlock button for elf

    public GameObject AbilityUnlock1;
    public GameObject AbilityUnlock2;
    public GameObject AbilityUnlock3;
    public GameObject AbilityUnlock4;

    public GameObject upgrade; //upgrade button in upgrade menu for castle
    public GameObject diamondPrefab;
    public GameObject castle1; // castle upgrade 1 ( image )
    public GameObject castle2; // castle upgrade 2 ( image )
    public GameObject castle3; // castle upgrade 3 ( image )
    public GameObject castle4; // castle upgrade 4 ( image )
    
    public void LoadGoldUpgradeStatus()
    {
        LoadLevel();
        DiamondScript.diamondValue = Diamonds;
        UnlockGold1.SetActive(false);
        UnlockGold2.SetActive(false);
        UnlockGold3.SetActive(false);
        UnlockGold4.SetActive(false);
        if (Gold == 500)
        {
            UnlockGold1.SetActive(true);
        }
        else if (Gold == 750)
        {
            UnlockGold2.SetActive(true);
        }
        else if (Gold == 1000)
        {
            UnlockGold3.SetActive(true);
        }
        else if (Gold == 1400)
        {
            UnlockGold4.SetActive(true);
            upgradeGold.SetActive(false);
        }
    }
    public void GoldHandler()
    {
        LoadLevel();
        if(Gold==500 && DiamondScript.diamondValue>=10)
        {
            PlayUnlockSound();
            Gold = 750;
            DiamondScript.diamondValue -= 10;
            UnlockGold1.SetActive(false);
            UnlockGold2.SetActive(true);
            SaveLevel();
        }
        else if(Gold==750 && DiamondScript.diamondValue>=20)
        {
            PlayUnlockSound();
            Gold = 1000;
            DiamondScript.diamondValue -= 20;
            UnlockGold2.SetActive(false);
            UnlockGold3.SetActive(true);
            SaveLevel();
        }
        else if (Gold == 1000 && DiamondScript.diamondValue >= 30)
        {
            PlayUnlockSound();
            Gold = 1400;
            DiamondScript.diamondValue -= 30;
            UnlockGold3.SetActive(false);
            UnlockGold4.SetActive(true);
            upgradeGold.SetActive(false);
            SaveLevel();
        }
    }
    public void ImageHandler() //for showing to us the right image in the upgrade menu
    {
        LoadLevel();
        if (playerCastleLevel == 0 && DiamondScript.diamondValue>=10)
        {
            PlayUnlockSound();
            CastleUpgradStatus++; //increment because in LoadCastleUpgradeStatus() we set the right image to show to us in upgrade menu
            DiamondScript.diamondValue -= 10;
            playerCastleLevel += 1;
            castle1.SetActive(false);
            castle2.SetActive(true);
            SaveLevel(); //saveing after we upgrade the castle
        }
        else if(playerCastleLevel == 1 && DiamondScript.diamondValue >= 10)
        {
            PlayUnlockSound();
            CastleUpgradStatus++;
            DiamondScript.diamondValue -= 10;
            playerCastleLevel += 1;
            castle2.SetActive(false);
            castle3.SetActive(true);
            SaveLevel();
        }
        else if (playerCastleLevel == 2 && DiamondScript.diamondValue >= 10)
        {
            PlayUnlockSound();
            CastleUpgradStatus++;
            DiamondScript.diamondValue -= 10;
            upgrade.SetActive(false);
            diamondPrefab.SetActive(false);
            playerCastleLevel += 1;
            castle3.SetActive(false);
            castle4.SetActive(true);
            SaveLevel();
        }
    }
    public void PlayClickButtonSound()
    {
        SoundManager.PlaySound("buttonclick");
    }
    public void PlayUnlockSound()
    {
        SoundManager.PlaySound("unlocksound");
    }
    public void UnlockKnight3()
    {
        if(DiamondScript.diamondValue>=25)
        {
            Unlock1.SetActive(false);
            PlayUnlockSound();
            LoadLevel();
            UnlockedCharacters[2] = 1;
            DiamondScript.diamondValue -= 25;
            SaveLevel();
        }
    }
    public void UnlockArcher()
    {
        if (DiamondScript.diamondValue >= 40)
        {
            Unlock2.SetActive(false);
            PlayUnlockSound();
            LoadLevel();
            UnlockedCharacters[3] = 1;
            DiamondScript.diamondValue -= 40;
            SaveLevel();
        }
    }
    public void UnlockMage()
    {
        if (DiamondScript.diamondValue >= 60)
        {
            Unlock3.SetActive(false);
            PlayUnlockSound();
            LoadLevel();
            UnlockedCharacters[4] = 1;
            DiamondScript.diamondValue -= 60;
            SaveLevel();
        }
    }
    public void UnlockElf()
    {
        if(DiamondScript.diamondValue>=85)
        {
            Unlock4.SetActive(false);
            PlayUnlockSound();
            LoadLevel();
            UnlockedCharacters[5] = 1;
            DiamondScript.diamondValue -= 85;
            SaveLevel();
        }
    }
    void Start()
    {
        LoadLevel();
    }
    public void UnlockAbility1()
    {
        if(DiamondScript.diamondValue>=30)
        {
            AbilityUnlock1.SetActive(false);
            PlayUnlockSound();
            LoadLevel();
            UnlockedAbilities[0] = 1;
            DiamondScript.diamondValue -= 30;
            SaveLevel();
        }
    }
    public void UnlockAbility2()
    {
        if (DiamondScript.diamondValue >= 20)
        {
            AbilityUnlock2.SetActive(false);
            PlayUnlockSound();
            LoadLevel();
            UnlockedAbilities[1] = 1;
            DiamondScript.diamondValue -= 20;
            SaveLevel();
        }
    }
    public void UnlockAbility3()
    {
        if (DiamondScript.diamondValue >= 25)
        {
            AbilityUnlock3.SetActive(false);
            PlayUnlockSound();
            LoadLevel();
            UnlockedAbilities[2] = 1;
            DiamondScript.diamondValue -= 25;
            SaveLevel();
        }
    }
    public void UnlockAbility4()
    {
        if (DiamondScript.diamondValue >= 25)
        {
            AbilityUnlock4.SetActive(false);
            PlayUnlockSound();
            LoadLevel();
            UnlockedAbilities[3] = 1;
            DiamondScript.diamondValue -= 25;
            SaveLevel();
        }
    }
    public void LoadUnlockedAbilitiesStatus()
    {
        LoadLevel();
        DiamondScript.diamondValue = Diamonds;
        AbilityUnlock1.SetActive(true);
        AbilityUnlock2.SetActive(true);
        AbilityUnlock3.SetActive(true);
        AbilityUnlock4.SetActive(true);
        if(UnlockedAbilities[0]==1)
        {
            AbilityUnlock1.SetActive(false);
        }
        if (UnlockedAbilities[1] == 1)
        {
            AbilityUnlock2.SetActive(false);
        }
        if (UnlockedAbilities[2] == 1)
        {
            AbilityUnlock3.SetActive(false);
        }
        if (UnlockedAbilities[3] == 1)
        {
            AbilityUnlock4.SetActive(false);
        }
    }
    public void LoadUnlockedPlayersStatus()
    {
        LoadLevel();
        DiamondScript.diamondValue = Diamonds;
        Unlock1.SetActive(true);
        Unlock2.SetActive(true);
        Unlock3.SetActive(true);
        Unlock4.SetActive(true);
        if(UnlockedCharacters[2]==1)
        {
            Unlock1.SetActive(false);
        }
        if (UnlockedCharacters[3] == 1)
        {
            Unlock2.SetActive(false);
        }
        if (UnlockedCharacters[4] == 1)
        {
            Unlock3.SetActive(false);
        }
        if (UnlockedCharacters[5] == 1)
        {
            Unlock4.SetActive(false);
        }
    }
    public void LoadCastleUpgradeStatus() //function that set the right image to show to us in upgrade menu ( for castle upgrade )
    {
        LoadLevel();
        DiamondScript.diamondValue = Diamonds;
        castle1.SetActive(false);
        castle2.SetActive(false);
        castle3.SetActive(false);
        castle4.SetActive(false);
        if (CastleUpgradStatus==0)
        {
            castle1.SetActive(true);
        }
        else if(CastleUpgradStatus==1)
        {
            castle2.SetActive(true);
        }
        else if(CastleUpgradStatus==2)
        {
            castle3.SetActive(true);
        }
        else if (CastleUpgradStatus == 3)
        {
            castle4.SetActive(true);
            upgrade.SetActive(false);
        }
    }
    public void SaveLevel()
    {
        Diamonds = DiamondScript.diamondValue;
        SaveSystem.SaveLevel(level, Diamonds,Gold, UnlockedCharacters,UnlockedAbilities, playerCastleLevel, CastleUpgradStatus);
    }
    public void LoadLevel()
    {
        LevelsData data = SaveSystem.LoadLevel();
        if(data!=null)
        {
            Diamonds = data.Diamonds;
            CastleUpgradStatus = data.CastleUpgradStatus;
            playerCastleLevel = data.PlayerCastleLevel;
            level = data.level;
            Gold = data.Gold;
            UnlockedCharacters = new int[6];
            for(int i=0;i<6;i++)
            {
                UnlockedCharacters[i] = data.unlockedPlayers[i];
            }
            UnlockedAbilities = new int[4];
            for(int i=0;i<4;i++)
            {
                UnlockedAbilities[i] = data.UnlockedAbilities[i];
            }
        }
        else //if we start the game for the first time
        {
            UnlockedCharacters = new int[6];
            for(int i=0;i<6;i++)
            {
                if (i == 0 || i==1) UnlockedCharacters[i] = 1;
                else UnlockedCharacters[i] = 0;
            }
            UnlockedAbilities = new int[4];
            for(int i=0;i<4;i++)
            {
                UnlockedAbilities[i] = 0;
            }
            Gold = 500;
            SaveSystem.SaveLevel(15,500,500, UnlockedCharacters,UnlockedAbilities, playerCastleLevel, CastleUpgradStatus);
        }
    }
    public void PlayMenu()
    {
        LoadLevel();
        SceneManager.LoadScene(level);
    }
    public void DeleteData()
    {
        SaveSystem.DeleteData();
    }
}
