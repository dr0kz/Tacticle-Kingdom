using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCastle : MonoBehaviour
{
    public static int CastleHealth;
    private float ShipSpeed = 0.4f;
    private float elapsed = 0f;
    public void Init(int health)
    {
        CastleHealth = health;
    }
    public void TakeDamage(int damage)
    {
        CastleHealth = Mathf.Max(0, CastleHealth - damage);
        if (CastleHealth == 0)
        {
            GameManager.GameOver = true;
        }
    }
    public int EnemyCastleHealth()
    {
        return CastleHealth;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag=="Magic")
        {
            TakeDamage(other.GetComponent<RangeWeapon>().getDamageSpell());
            Destroy(other.gameObject);
        }
        if (other.transform.tag=="Arrow")
        {
            TakeDamage(other.GetComponent<RangeWeapon>().getDamageArrow());
            Destroy(other.gameObject);
        }
    }
}
