using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiating4 : MonoBehaviour
{
    //malee enemies
    public Knight_1_Enemy police_1_Prefab;
    public Range_Enemy police_2_Prefab;
    public PoliceCar policeCar_Prefab;
    public Bat bat_Prefab;

    private float offset;
    public EnemyMeteorInstantiating instantiateMeteor;

    private int level = 1;
    private float randomChance;

    private float differentEnemySpawnChance = 1 / 2f;
    void Start()
    {
        InvokeRepeating("InstantiateBat", 0f, 4f);
        InvokeRepeating("InstantiateBat", 30f, 4.2f);
        InvokeRepeating("InstantiateEnemy", 0f, 7.5f);
        InvokeRepeating("InstantiateEnemy", 100f, 16f);
        InvokeRepeating("InstantiatePoliceCar", 6f, 68f);
        InvokeRepeating("meteorInstantiating", 17f, 40f);
    }
    private void InstantiateBat()
    {
        Bat bat = Instantiate(bat_Prefab);
        offset = Random.Range(2.9f, 3.3f);
        bat.transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
    }
    private void InstantiatePoliceCar()
    {
        PoliceCar police = Instantiate(policeCar_Prefab);
        police.transform.position = new Vector3(transform.position.x+13f,transform.position.y,transform.position.z);
    }
    private void InstantiateEnemy()
    {
        Load();
        randomChance = Random.Range(0f, 1f);

        if (GameManager.currentLevel == 12)
        {
            Knight_1_Enemy police = Instantiate(police_1_Prefab);
            police.transform.position = transform.position;
            police.Init(Vector2.right);
        }
        else
        {
            if (randomChance <= differentEnemySpawnChance)
            {
                Knight_1_Enemy police = Instantiate(police_1_Prefab);
                police.transform.position = transform.position;
                police.Init(Vector2.right);
            }
            else
            {
                Range_Enemy police = Instantiate(police_2_Prefab);
                police.transform.position = transform.position;
                police.Init(Vector2.right, 2);
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
