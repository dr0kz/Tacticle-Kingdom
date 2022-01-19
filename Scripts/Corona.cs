using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corona : MonoBehaviour
{
    public int coronaDamage = 30;
    public int coronaCastleDamage = 150;
    public float coronaSpeed = 4f;
    void Update()
    {
        transform.Translate(Vector2.right * coronaSpeed * Time.deltaTime);
    }
    public int getDamage()
    {
        return coronaDamage;
    }
    public int getCastleDamage()
    {
        return coronaCastleDamage;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag=="Meteor")
        {
            Destroy(gameObject);
        }
    }
}
