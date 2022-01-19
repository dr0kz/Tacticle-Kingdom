using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiating3 : MonoBehaviour
{
    //malee enemies
    public Knight_1_Enemy corona_1_Prefab;
    public Corona corona_2_Prefab;
    public Bat bat_Prefab;

    private float offset;
    public EnemyMeteorInstantiating instantiateMeteor;

    private int level = 1;
    private float randomChance;

    private float differentEnemySpawnChance = 1 / 5f;

    private int flag = 0;
    private int flag2 = 0;
    private int flag3 = 0;
    private int flag4 = 0;

    void Start()
    {
        InvokeRepeating("InstantiateEnemy", 0f, 7.5f);
        InvokeRepeating("meteorInstantiating", 8f, 40f);
        if(GameManager.currentLevel==9)
        {
            InvokeRepeating("InstantiateBat", 0f, 6f);
            InvokeRepeating("InstantiateBat", 48f, 10f);
        }
        if(GameManager.currentLevel==10)
        {
            InvokeRepeating("InstantiateBat", 6f, 10f);
            InvokeRepeating("InstantiateEnemy", 125f, 10f);
            InvokeRepeating("InstantiateBat", 52f, 10f);
        }
        if(GameManager.currentLevel==11)
        {
            InvokeRepeating("InstantiateBat", 0f, 4.9f);
        }
    }
    void Update()
    {
        if (GameManager.currentLevel == 11)
        {
            if (YearBar.slidervalue <= 0.756f && flag == 0)
            {
                flag = 1;
                InvokeRepeating("InstantiateBat", 0f, 9.3f);
                SoundManager.PlaySound("danger");
            }
            else if (YearBar.slidervalue <= 0.519f && flag2 == 0)
            {
                flag2 = 1;
                InvokeRepeating("InstantiateBat", 0f, 14f);
                InvokeRepeating("InstantiateEnemy", 0f, 15f);
                SoundManager.PlaySound("danger");
            }
            else if (YearBar.slidervalue <= 0.261f && flag3 == 0)
            {
                flag3 = 1;
                InvokeRepeating("InstantiateEnemy", 0f, 30f);
                InvokeRepeating("InstantiateBat", 0f, 20f);
                SoundManager.PlaySound("danger");
            }
            else if(YearBar.slidervalue<=0f && flag4==0)
            {
                flag4 = 1;
                SoundManager.PlaySound("danger");
                InvokeRepeating("InstantiateEnemy", 0f, 45f);
                InvokeRepeating("InstantiateBat", 0f, 25f);
            }
        }
    }
    private void InstantiateEnemy()
    {
        Load();
        randomChance = Random.Range(0f, 1f);
        if (GameManager.currentLevel == 9)
        {
            Knight_1_Enemy corona1 = Instantiate(corona_1_Prefab);
            corona1.transform.position = transform.position;
            corona1.Init(Vector2.right);
        }
        else if(GameManager.currentLevel==10)
        {
            if(randomChance <= differentEnemySpawnChance)
            {
                Corona corona1 = Instantiate(corona_2_Prefab);
                corona1.transform.position = transform.position;
            }
            else
            {
                Knight_1_Enemy corona1 = Instantiate(corona_1_Prefab);
                corona1.transform.position = transform.position;
                corona1.Init(Vector2.right);
            }
        }
        else
        {
            Corona corona1 = Instantiate(corona_2_Prefab);
            corona1.transform.position = transform.position;
        }
    }
    private void InstantiateBat()
    {
        Bat bat = Instantiate(bat_Prefab);
        offset = Random.Range(2.9f, 3.3f);
        bat.transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
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
