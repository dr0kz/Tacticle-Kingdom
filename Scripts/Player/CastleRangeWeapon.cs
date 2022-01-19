using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleRangeWeapon : MonoBehaviour
{
    private int damage;
    private ClosestEnemy enemy;
    private float Speed = 10f;

    public void Init(ClosestEnemy closestEnemy,int CharacterDamage)
    {
        enemy = closestEnemy;
        damage = CharacterDamage;
    }
    public int GetDamage()
    {
        return damage;
    }
    void Update()
    {
        if(GameManager.GameOver)
        {
            Destroy(gameObject);
        }
        if (enemy != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, Speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
