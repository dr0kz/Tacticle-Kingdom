using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInstantiating : MonoBehaviour
{
    public Knight_1 knight_1_Prefab; //knight 1
    public Knight_1 knight_2_Prefab; //knight 2
    public Knight_1 knight_3_Prefab; //knight 3

    public Knight_1 elf_Prefab;

    public RangeClass archerPrefab;
    public RangeClass magePrefab;

    public Button Knight_1_Button; //knight 1 button
    public Button Knight_2_Button; //knight 2 button
    public Button Knight_3_Button; //knight 3 button

    public Button archerButton;
    public Button mageButton;

    public Button elfButton;

    public static int SpawnedCharacters = 0;

    void Start()
    {
        LevelsData data = SaveSystem.LoadLevel();
        if (data.PlayerCastleLevel >=1)
        {
            transform.position = new Vector3(transform.position.x + 1.87f, transform.position.y, transform.position.z);
        }
    }
    public void Button_1_Pressed()
    {
        if (MoneyScript.moneyValue >= 200 && GameManager.GameOver==false && GameManager.Paused == false)
        {
            SpawnedCharacters++;
            MoneyScript.moneyValue -= 200;
            StartCoroutine(Spawn(knight_1_Prefab, 0.5f, 1,false));
            SetButtonsStatus(false);
        }
    }

    public void Button_2_Pressed()
    {
        if (MoneyScript.moneyValue >= 300 && GameManager.GameOver == false && GameManager.Paused == false)
        {
            SpawnedCharacters++;
            MoneyScript.moneyValue -= 300;
            StartCoroutine(Spawn(knight_2_Prefab, 0.8f, 2, false));
            SetButtonsStatus(false);
        }
    }
    public void Button_3_Pressed()
    {
        if (MoneyScript.moneyValue >= 450 && GameManager.GameOver == false && GameManager.Paused == false)
        {
            SpawnedCharacters++;
            MoneyScript.moneyValue -= 450;
            StartCoroutine(Spawn(knight_3_Prefab,1f, 3, false));
            SetButtonsStatus(false);
        }
    }
    public void Button_4_Pressed() //ARCHER
    {
        if (MoneyScript.moneyValue >= 450 && GameManager.GameOver == false && GameManager.Paused == false)
        {
            SpawnedCharacters++;
            MoneyScript.moneyValue -= 450;
            StartCoroutine(SpawnRange(archerPrefab, 1f,true));
            SetButtonsStatus(false);
        }
    }
    public void Button_5_Pressed() //MAGE
    {
        if (MoneyScript.moneyValue >= 600 && GameManager.GameOver == false && GameManager.Paused == false)
        {
            SpawnedCharacters++;
            MoneyScript.moneyValue -= 600;
            StartCoroutine(SpawnRange(magePrefab, 1.5f, false));
            SetButtonsStatus(false);
        }
    }
    public void Button_6_Pressed()
    {
        if (MoneyScript.moneyValue >= 800 && GameManager.GameOver == false && GameManager.Paused == false)
        {
            SpawnedCharacters++;
            MoneyScript.moneyValue -= 800;
            StartCoroutine(Spawn(elf_Prefab, 2f, 4,true));
            SetButtonsStatus(false);
        }
    }
    private void SetButtonsStatus(bool status)
    {
        Knight_1_Button.interactable = status;
        Knight_2_Button.interactable = status;
        Knight_3_Button.interactable = status;
        archerButton.interactable = status;
        mageButton.interactable = status;
        elfButton.interactable = status;
    }
    private Vector3 FindClosestEnemy()
    {
        
        PlayerBaseClass[] allCharacters = GameObject.FindObjectsOfType<PlayerBaseClass>();
        Vector3 closestPosition = this.transform.position;
        foreach (PlayerBaseClass currentCharacter in allCharacters)
        {
            if (currentCharacter.transform.position.x < closestPosition.x)
            {
                closestPosition = currentCharacter.transform.position;
            }
        }
        return closestPosition;
    }
    private IEnumerator Spawn(Knight_1 character, float seconds, int sound,bool isElf) //MALEE
    {
        yield return new WaitForSeconds(seconds);
        Knight_1 knight = Instantiate(character);
        knight.transform.position = transform.position;
        if(isElf)
        {
            Vector3 spawnPos = FindClosestEnemy();
            spawnPos.x = spawnPos.x - 1f;
            knight.transform.position = new Vector3(spawnPos.x, transform.position.y + 0.64f, 0f);
        }
        else
        {
            Vector3 spawnPos = FindClosestEnemy();
            spawnPos.x = spawnPos.x - 1f;
            spawnPos.y = knight.transform.position.y;
            knight.transform.position = spawnPos;

            //knight.transform.position = transform.position;
        }
        knight.Init(Vector2.right, sound);
        SetButtonsStatus(true);
    }
    private IEnumerator SpawnRange(RangeClass character, float seconds, bool isArcher)
    {
        yield return new WaitForSeconds(seconds);
        RangeClass range = Instantiate(character);
        range.transform.position = transform.position;
        if(isArcher)
        {
            Vector3 spawnPos = FindClosestEnemy();
            spawnPos.x = spawnPos.x - 1f;
            range.transform.position = new Vector3(spawnPos.x, transform.position.y + 0.41f, 0f);
        }
        else
        {
            Vector3 spawnPos = FindClosestEnemy();
            spawnPos.x = spawnPos.x - 1f;
            range.transform.position = new Vector3(spawnPos.x, transform.position.y + 0.56f, 0f);
        }
        SetButtonsStatus(true);
        range.Init(Vector2.right, isArcher);
    }
}
