using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiating5 : MonoBehaviour
{
    //malee enemies
    public Knight_1_Enemy golem_1_Prefab;
    public Knight_1_Enemy golem_2_Prefab;
    public Knight_1_Enemy golem_3_Prefab;

    private float offset;
    public EnemyMeteorInstantiating instantiateMeteor;

    private int level = 1;
    private float randomChance;

    private float differentEnemySpawnChance = 1 / 2f;
    void Start()
    {
        InvokeRepeating("InstantiateEnemy", 0f, 7.1f);
        InvokeRepeating("InstantiateEnemy", 120f, 15f);
        InvokeRepeating("meteorInstantiating", 10f, 48f);
    }
    private void InstantiateEnemy()
    {
        Load();
        randomChance = Random.Range(0f, 1f);

        if (GameManager.currentLevel == 14)
        {
            if (randomChance <= differentEnemySpawnChance)
            {
                Knight_1_Enemy golem = Instantiate(golem_1_Prefab);
                golem.transform.position = transform.position;
                golem.Init(Vector2.right);
            }
            else
            {
                Knight_1_Enemy golem = Instantiate(golem_2_Prefab);
                golem.transform.position = transform.position;
                golem.Init(Vector2.right);
            }
        }
        else
        {
            if (randomChance <= differentEnemySpawnChance)
            {
                Knight_1_Enemy golem = Instantiate(golem_3_Prefab);
                golem.transform.position = transform.position;
                golem.Init(Vector2.right);
            }
            else
            {
                Knight_1_Enemy golem = Instantiate(golem_2_Prefab);
                golem.transform.position = transform.position;
                golem.Init(Vector2.right);
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
