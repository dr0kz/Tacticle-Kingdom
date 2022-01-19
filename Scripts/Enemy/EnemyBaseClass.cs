using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseClass : MonoBehaviour
{
    [SerializeField] protected float CharacterSpeed;
    [SerializeField] protected int CharacterHealth;
    [SerializeField] protected int CharacterDamage;

    public LayerMask PlayerLayer; //layer mask if raycast hit something that have layer:Player
    public LayerMask SameLayer;
    public LayerMask CastleLayer;

    public string soundNameAttackCharacter;//name of the sound - attacking character
    public string soundNameAttackCastle;//name of the sound - attacking castle
    public string soundNameDie="death";

    public float raycastMaxDistance = 10f; // Max distance from enemy to where he can detect player
    public float originOffset = 0.8f; //offset from the center of the enemy ( optional )

    protected bool IsStuned = false;

    protected int enemyHealth;
    protected float enemyMovementSpeed;
    protected Vector2 dir;
    protected float elapsed;
    public float AttackTime = 2f;
    protected bool isEnemyMoveing=true;

    public Blood BloodPrefab;
    private bool isDead = false;
    public CharacterHealthBar healthBar;
    public int Money;

    public Animator animator;

    private Color currentColor;
    private SpriteRenderer changeColor;

    private const float dropChance= 1f / 2.5f;
    void Start()
    {
        changeColor = GetComponent<SpriteRenderer>();
        currentColor = changeColor.color;
        elapsed = AttackTime;
        enemyHealth = GetMaxHealth(); //getting the enemy max health from inherited class
        enemyMovementSpeed = GetEnemyMaxMovementSpeed(); // getting the enemy max movement speed from inherited class
        animator.SetFloat("Health", enemyHealth);
        healthBar.SetMaxHealth(enemyHealth);
    }
    protected void Die() // if Enemy's health is equal to 0 Destructor is called
    {
        CancelInvoke();
        Destroy(gameObject); //Destoring the enemy
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Arrow")
        {
            TakeDamage(other.GetComponent<RangeWeapon>().getDamageArrow());
            Destroy(other.gameObject);
        }
        if (other.transform.tag == "Magic")
        {
            TakeDamage(other.GetComponent<RangeWeapon>().getDamageSpell());
            Destroy(other.gameObject);
        }
        if(other.transform.tag== "CastleMageMagic")
        {
            TakeDamage(other.GetComponent<CastleRangeWeapon>().GetDamage());
            Destroy(other.gameObject);
        }
        if (other.transform.tag == "Meteor")
        {
            Destroy(other.gameObject);
            if(transform.tag!="golem")
            {
                TakeDamage(other.GetComponent<Meteor>().getMeteorDamage());
            }
            else
            {
                golemImmune();
            }
            
        }
        if (other.transform.tag == "ArrowAbility")
        {
            TakeDamage(other.GetComponent<Arrow>().getArrowDamage());
            Destroy(other.gameObject);
        }
        if(other.transform.tag=="Stun")
        {
            TakeDamage(other.GetComponent<Stun>().GetStunDamage());
            StartCoroutine(EndStunDuration());
            IsStuned = true;
            Destroy(other.gameObject);
        }
    }
    private void golemImmune()
    {
        changeColor.color = new Color(0f, 0f, 0f);
        StartCoroutine(RemoveImmune());
    }
    private IEnumerator RemoveImmune()
    {
        yield return new WaitForSeconds(0.2f);
        changeColor.color = currentColor;
    }
    private IEnumerator EndStunDuration()
    {
        yield return new WaitForSeconds(3f);
        IsStuned = false;
    }
    public void TakeDamage(int damage)
    {
        enemyHealth = Mathf.Max(0, enemyHealth - damage);
        if (enemyHealth == 0 && isDead==false)
        {
            isDead = true;
            animator.SetFloat("Health", 0);
            InvokeRepeating("Die", 0.6f, 1f);
            SoundManager.PlaySound(soundNameDie);
            MoneyScript.moneyValue += Money; //every enemy gives different amount of money
            if (Random.Range(0f, 1f) <= dropChance)
            {
                DiamondScript.diamondValue += 1;
                SoundManager.PlaySound("diamond");
                SaveLevel();
            }
        }
        else
        {
            animator.SetTrigger("HurtTrigger");
        }
        healthBar.SetHealth(enemyHealth);
    }
    public void SaveLevel()
    {
        
        LevelsData data = SaveSystem.LoadLevel();
        SaveSystem.SaveLevel(data.level, DiamondScript.diamondValue,data.Gold, data.unlockedPlayers,
        data.UnlockedAbilities, data.PlayerCastleLevel, data.CastleUpgradStatus);
    }
    public void CriticalHit()
    {
        Blood blood=Instantiate(BloodPrefab, transform.position, Quaternion.identity);
    }
    public int ReturnEnemyHealth()
    {
        return enemyHealth;
    }
    public abstract int GetMaxHealth();
    public abstract float GetEnemyMaxMovementSpeed();
}
