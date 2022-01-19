using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Knight_1_Enemy piratePrefab;

    private float speed = 2.65f;
    private int Damage = 100;
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if(GameManager.GameOver)
        {
            Destroy(gameObject);
        }
    }
    public void InstantiateEnemies()
    {
        Knight_1_Enemy pirate = Instantiate(piratePrefab);
        pirate.transform.position =new Vector3(transform.position.x,transform.position.y-0.37f,transform.position.z);
        pirate.Init(Vector2.right);
    }
    public int getDamage()
    {
        return Damage;
    }
}
