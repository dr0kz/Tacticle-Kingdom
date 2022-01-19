using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiating2 : MonoBehaviour
{
    //malee enemies
    public Knight_1_Enemy pirate_1_prefab;
    public Knight_1_Enemy pirate_2_prefab;

    //range enemy
    public Range_Enemy pirate_3_prefab;


    public EnemyMeteorInstantiating instantiateMeteor;

    private int level = 1;
    private float randomChance;

    private float differentEnemySpawnChance = 1 / 3f;
    void Start()
    {
        InvokeRepeating("InstantiateEnemy", 0f, 8.1f);
        if (GameManager.currentLevel == 6)
        {
            InvokeRepeating("meteorInstantiating",50f, 50f);
        }
        if (GameManager.currentLevel == 7 || GameManager.currentLevel==8)
        {
            InvokeRepeating("meteorInstantiating", 25f, 48f);
        }
    }
    private void InstantiateEnemy()
    {
        Load();
        randomChance = Random.Range(0f, 1f);
        if(GameManager.currentLevel==5)
        {
            Knight_1_Enemy pirate1 = Instantiate(pirate_1_prefab);
            pirate1.transform.position = transform.position;
            pirate1.Init(Vector2.right);
        }
        else if (GameManager.currentLevel == 6)
        {
            if (randomChance <= differentEnemySpawnChance)
            {
                Knight_1_Enemy pirate1 = Instantiate(pirate_1_prefab);
                pirate1.transform.position = transform.position;
                pirate1.Init(Vector2.right);
            }
            else
            {
                Knight_1_Enemy pirate1 = Instantiate(pirate_2_prefab);
                pirate1.transform.position = transform.position;
                pirate1.Init(Vector2.right);
            }

        }
        else if (GameManager.currentLevel == 7)
        {
            if (randomChance <= differentEnemySpawnChance)
            {
                Knight_1_Enemy pirate1 = Instantiate(pirate_1_prefab);
                pirate1.transform.position = transform.position;
                pirate1.Init(Vector2.right);
            }
            else if (randomChance > differentEnemySpawnChance && randomChance <= differentEnemySpawnChance * 2)
            {
                Knight_1_Enemy pirate1 = Instantiate(pirate_2_prefab);
                pirate1.transform.position = transform.position;
                pirate1.Init(Vector2.right);
            }
            else
            {
                Range_Enemy pirate1 = Instantiate(pirate_3_prefab);
                pirate1.transform.position = transform.position;
                pirate1.Init(Vector2.right,2);
            }
        }
        else if (GameManager.currentLevel == 8)
        {
            if (randomChance <= differentEnemySpawnChance)
            {
                Knight_1_Enemy pirate1 = Instantiate(pirate_2_prefab);
                pirate1.transform.position = transform.position;
                pirate1.Init(Vector2.right);
            }
            else if (randomChance > differentEnemySpawnChance && randomChance <= differentEnemySpawnChance * 2)
            {
                Knight_1_Enemy pirate1 = Instantiate(pirate_1_prefab);
                pirate1.transform.position = transform.position;
                pirate1.Init(Vector2.right);
            }
            else
            {
                Range_Enemy pirate1 = Instantiate(pirate_3_prefab);
                pirate1.transform.position = transform.position;
                pirate1.Init(Vector2.right, 2);
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
