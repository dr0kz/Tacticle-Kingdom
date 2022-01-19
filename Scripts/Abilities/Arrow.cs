using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float ArrowSpeed = 6f;
    private int ArrowDamage = 30;
    void Update()
    {
        if(GameManager.GameOver)
        {
            Destroy(gameObject);
        }
    }
    public int getArrowDamage()
    {
        return ArrowDamage;
    }
}
