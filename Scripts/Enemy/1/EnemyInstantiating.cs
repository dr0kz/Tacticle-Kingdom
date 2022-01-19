using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiating : MonoBehaviour
{
    //malee enemies
    public Knight_1_Enemy knight_1_Prefab; 
    public Knight_1_Enemy knight_2_Prefab;
    public Knight_1_Enemy knight_3_Prefab;

    //range enemies
    public Range_Enemy range_1_Prefab;

    public EnemyMeteorInstantiating instantiateMeteor;

    private int level = 1;
    private float randomChance;

    private float differentEnemySpawnChance=1/3f;
    void Start()
    {
        InvokeRepeating("InstantiateEnemy", 0f, 7.9f);
        InvokeRepeating("InstantiateEnemy", 110f, 15f);
        if(GameManager.currentLevel==3)
        {
            InvokeRepeating("meteorInstantiating", 90f, 40f);
        }
        if (GameManager.currentLevel==4)
        {
            InvokeRepeating("meteorInstantiating", 20f, 35f);
        }
    }
    private void InstantiateEnemy()
    {
        Load();
        randomChance = Random.Range(0f, 1f);
        if(GameManager.currentLevel == 1)
        {
            Knight_1_Enemy knight = Instantiate(knight_1_Prefab);
            knight.transform.position = transform.position;
            knight.Init(Vector2.right);
        }
        else if(GameManager.currentLevel == 2)
        {
            if (randomChance <= differentEnemySpawnChance)
            {
                Knight_1_Enemy knight = Instantiate(knight_1_Prefab);
                knight.transform.position = transform.position;
                knight.Init(Vector2.right);
            }
            else if (randomChance > differentEnemySpawnChance && randomChance <= differentEnemySpawnChance * 2)
            {
                Knight_1_Enemy knight = Instantiate(knight_3_Prefab);
                knight.transform.position = transform.position;
                knight.Init(Vector2.right);
            }
            else
            {
                Knight_1_Enemy knight = Instantiate(knight_2_Prefab);
                knight.transform.position = transform.position;
                knight.Init(Vector2.right);
            }

        }
        else if(GameManager.currentLevel == 3)
        {
            
            if (randomChance <= differentEnemySpawnChance)
            {
                Knight_1_Enemy knight = Instantiate(knight_3_Prefab);
                knight.transform.position = transform.position;
                knight.Init(Vector2.right);
            }
            else if(randomChance > differentEnemySpawnChance && randomChance <= differentEnemySpawnChance * 2)
            {
            
                Range_Enemy archer = Instantiate(range_1_Prefab);
                archer.transform.position = new Vector3(transform.position.x, transform.position.y + 0.41f, 0f);
                archer.Init(Vector2.right,1); //true represents that this is archer , false is for mage
           }
           else
           {
                Knight_1_Enemy knight = Instantiate(knight_2_Prefab);
                knight.transform.position = transform.position;
                knight.Init(Vector2.right);
           }
        }
        else if(GameManager.currentLevel==4)
        {
            if (randomChance <= differentEnemySpawnChance)
            {
                Knight_1_Enemy knight = Instantiate(knight_3_Prefab);
                knight.transform.position = transform.position;
                knight.Init(Vector2.right);
            }
            else if (randomChance > differentEnemySpawnChance && randomChance <= differentEnemySpawnChance * 2)
            {

                Range_Enemy archer = Instantiate(range_1_Prefab);
                archer.transform.position = new Vector3(transform.position.x, transform.position.y + 0.41f, 0f);
                archer.Init(Vector2.right, 1); //true represents that this is archer , false is for mage
            }
            else
            {
                Knight_1_Enemy knight = Instantiate(knight_2_Prefab);
                knight.transform.position = transform.position;
                knight.Init(Vector2.right);
            }
        }
    }
    private void meteorInstantiating()
    {
        instantiateMeteor.GetComponent<EnemyMeteorInstantiating>().MeteorsAbility();
    }
    private void Load()
    {
        LevelsData data = SaveSystem.LoadLevel();
        level = data.level;
    }
}
