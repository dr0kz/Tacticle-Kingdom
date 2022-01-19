using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public int batHealth;
    public float batSpeed;
    public int batDamage;

    public string soundNameDie;
    public CharacterHealthBar healthBar;
    private bool isDead = false;
    public Animator animator;
    private float dropChance = 1 / 2.5f;
    public int Money;
    void Start()
    {
        healthBar.SetMaxHealth(batHealth);
    }
    void Update()
    {
        transform.Translate(Vector2.left * batSpeed * Time.deltaTime);
        if (GameManager.GameOver)
        {
            Destroy(gameObject);
        }
    }
    protected void Die() // if Enemy's health is equal to 0 Destructor is called
    {
        Destroy(gameObject); //Destoring the enemy
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag== "CastleMageMagic")
        {
            TakeDamage(other.GetComponent<CastleRangeWeapon>().GetDamage());
            Destroy(other.gameObject);
        }
        if (other.transform.tag == "Meteor")
        {
            TakeDamage(other.GetComponent<Meteor>().getMeteorDamage());
            Destroy(other.gameObject);
        }
        if (other.transform.tag == "ArrowAbility")
        {
            TakeDamage(other.GetComponent<Arrow>().getArrowDamage());
            Destroy(other.gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        batHealth = Mathf.Max(0, batHealth - damage);
        if (batHealth == 0 && isDead==false)
        {
            isDead = true;
            Die();
            SoundManager.PlaySound("batdie");
            SoundManager.PlaySound(soundNameDie);
            MoneyScript.moneyValue += Money;
            if (Random.Range(0f, 1f) <= dropChance)
            {
                DiamondScript.diamondValue += 1;
                SoundManager.PlaySound("diamond");
            }
            SaveLevel();
        }
        healthBar.SetHealth(batHealth);
    }
    public int getDamage()
    {
        return batDamage;
    }
    public void SaveLevel()
    {
        LevelsData data = SaveSystem.LoadLevel();
        SaveSystem.SaveLevel(data.level, DiamondScript.diamondValue, data.Gold, data.unlockedPlayers,
        data.UnlockedAbilities, data.PlayerCastleLevel, data.CastleUpgradStatus);
    }
}
