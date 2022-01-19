using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private float MeteorSpeed = 6f;
    private int MeteorDamage = 1000;
    void Update()
    {
        transform.Translate(Vector2.right * MeteorSpeed * Time.deltaTime);
        if (GameManager.GameOver == true)
        {
            Destroy(gameObject);
        }
    }
    public int getMeteorDamage()
    {
        return MeteorDamage;
    }
}
