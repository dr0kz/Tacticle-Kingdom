using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : MonoBehaviour
{
    private Vector2 dir;
    private int weaponType; //1 for arrow , 2 for magic

    private int Damage;
    private bool isFromEnemy;
    private float ArrowSpeed = 12f;
    private float MagicSpeed = 12f;
    private float BulletSpeed = 12f;
    
    private float angle=13f;

    public void Init(Vector2 mydir,int type,int damage,bool fromEnemy)
    {
        dir = mydir;
        weaponType = type;
        Damage = damage;
        isFromEnemy = fromEnemy;
    }
    void Update()
    {
        if (isFromEnemy)
        {
            if(weaponType==1)
            {
                transform.Translate(dir * ArrowSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, angle -= 0.1f);
            }
            else if(weaponType==3)
            {
                transform.Translate(dir * BulletSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (weaponType == 1)
            {
                transform.Translate(dir * ArrowSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, angle -= 0.1f);
            }
            else if (weaponType == 2)
            {
                transform.Translate(dir * MagicSpeed * Time.deltaTime);
            }
        }
        if(GameManager.GameOver==true)
        {
            Destroy(gameObject);
        }
    }
    public int getDamageArrow()
    {
        return Damage;
    }
    public int getDamageSpell()
    {
        return Damage;
    }
    public int getDamageBullet()
    {
        return Damage;
    }

}
