using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseClass : MonoBehaviour
{
    public Knight_1_Enemy enemy1Prefab;
    public Knight_1_Enemy enemy2Prefab;
    public Knight_1_Enemy enemy3Prefab;

    private float randomEnemy = 0f;

    public static float CharacterSpeed=4f; //static because its same for every character and so we can change it easy when SpeedAbility is ON
    [SerializeField] protected int CharacterHealth;
    [SerializeField] protected int CharacterDamage;

    protected string sound; //sound string for function HitDelay; ( we send sound string as argument )
    public float raycastMaxDistance = 0.5f; // Max distance from player to where he can detect enemy
    protected float originOffset = 0.8f; //offset from the center of the player ( optional )

    public LayerMask EnemyLayer;   //layer mask if raycast hit something that have layer:Enemy
    public LayerMask SameLayer;    //layer mask if raycast hit something that have layer:Enemy for enemies and Player for players
    public LayerMask CastleLayer;  //layer mask if raycast hit something that have layer:EnemyCastle for players and PlayerCastle for enemies

    protected int playerHealth;
    protected float playerMovementSpeed;
    protected Vector2 dir;

    public static bool Shield = false;
    public GameObject ShieldPrefab;
    protected int KnightType; // integer for manage the sounds of the characters

    public Animator animator; // for animations

    public CharacterHealthBar healthBar; //healthBar above the characters

    protected bool isPlayerMoveing = true;

    protected float elapsed;
    public float attackTime = 1.8f;
    protected bool isDead = false;

    protected bool isStuned = false;

    private SpriteRenderer changeColor;
    void Start()
    {
        elapsed = attackTime;
        changeColor = GetComponent<SpriteRenderer>();
        playerHealth = GetMaxHealth(); //getting the player max health from inherited class
        playerMovementSpeed = GetPlayerMaxMovementSpeed(); // getting the player max movement speed from inherited class
        animator.SetFloat("Health", playerHealth);
        healthBar.SetMaxHealth(playerHealth);
    }
    protected void Die()
    {
        PlayerInstantiating.SpawnedCharacters--;
        CancelInvoke();
        Destroy(gameObject); //Destoring the player
    }
    public void TakeDamage(int damage) 
    {
        if (Shield == false)
        {
            playerHealth = Mathf.Max(0, playerHealth - damage);
            if (playerHealth == 0 && isDead==false)
            {
                isDead = true;
                animator.SetFloat("Health", 0);
                InvokeRepeating("Die", 0.6f, 1f);
                SoundManager.PlaySound("death");
            }
            else
            {
                animator.SetTrigger("HurtTrigger");
            }
            healthBar.SetHealth(playerHealth);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag=="EnemyArrow")
        {
            if(Shield==false)
            {
                TakeDamage(other.GetComponent<RangeWeapon>().getDamageArrow());
            }
            Destroy(other.gameObject);
        }
        if(other.transform.tag=="EnemyMeteor")
        {
            if(Shield==false)
            {
                TakeDamage(other.GetComponent<Meteor>().getMeteorDamage());
            }
            Destroy(other.gameObject);
        }
        if(other.transform.tag=="Bullet")
        {
            if (Shield == false)
            {
                TakeDamage(other.GetComponent<RangeWeapon>().getDamageBullet());
            }
            Destroy(other.gameObject);
        }
        if(other.transform.tag=="Ship")
        {
            SoundManager.PlaySound("shipbreak");
            if(Shield==false)
            {
                TakeDamage(other.GetComponent<Ship>().getDamage());
            }
            other.GetComponent<Ship>().InstantiateEnemies();
            Destroy(other.gameObject);
        }
        if(other.transform.tag=="infect")
        {
            SoundManager.PlaySound("coronaDie");
            if(Shield==false)
            {
                TakeDamage(other.GetComponent<Corona>().getDamage());
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
            instantiateEnemy();
        }
        if(other.transform.tag=="policeCar")
        {
            Destroy(gameObject);
            other.GetComponent<PoliceCar>().IncreasePlayersKilled();
        }
    }
    private void instantiateEnemy()
    {
        float randomEnemy = Random.Range(0f, 1f);
        if(randomEnemy<=0.25f)
        {
            Knight_1_Enemy enemy = Instantiate(enemy1Prefab);
            if (transform.tag == "Elf")
            {
                enemy.transform.position = new Vector3(transform.position.x, transform.position.y - 0.64f, transform.position.z);
            }
            else if(transform.tag=="Archer")
            {
                enemy.transform.position = new Vector3(transform.position.x, transform.position.y - 0.41f, transform.position.z);
            }
            else if(transform.tag=="Mage")
            {
                enemy.transform.position = new Vector3(transform.position.x, transform.position.y - 0.56f, transform.position.z);
            }
            else
            {
                enemy.transform.position = transform.position;
            }
            enemy.Init(Vector2.right);
        }
        else if(randomEnemy>0.25f && randomEnemy<=0.5f)
        {
            Knight_1_Enemy enemy = Instantiate(enemy2Prefab);
            if (transform.tag == "Elf")
            {
                enemy.transform.position = new Vector3(transform.position.x, transform.position.y - 0.64f, transform.position.z);
            }
            else if (transform.tag == "Archer")
            {
                enemy.transform.position = new Vector3(transform.position.x, transform.position.y - 0.41f, transform.position.z);
            }
            else if (transform.tag == "Mage")
            {
                enemy.transform.position = new Vector3(transform.position.x, transform.position.y - 0.56f, transform.position.z);
            }
            else
            {
                enemy.transform.position = transform.position;
            }
            enemy.Init(Vector2.right);
        }
        else
        {
            Knight_1_Enemy enemy = Instantiate(enemy3Prefab);
            if (transform.tag == "Elf")
            {
                enemy.transform.position = new Vector3(transform.position.x, transform.position.y - 0.64f, transform.position.z);
            }
            else if (transform.tag == "Archer")
            {
                enemy.transform.position = new Vector3(transform.position.x, transform.position.y - 0.41f, transform.position.z);
            }
            else if (transform.tag == "Mage")
            {
                enemy.transform.position = new Vector3(transform.position.x, transform.position.y - 0.56f, transform.position.z);
            }
            else
            {
                enemy.transform.position = transform.position;
            }
            enemy.Init(Vector2.right);
        }

    }
    public void golemStun()
    {
        isStuned = true;
        //changeColor.color = Color.darkgray;
        changeColor.color = new Color(0f, 0f, 0f);
        StartCoroutine(RemoveStun());
    }
    private IEnumerator RemoveStun()
    {
        yield return new WaitForSeconds(1.2f);
        isStuned = false;
        changeColor.color = Color.white;
    }
    public int ReturnPlayerHealth()
    {
        return playerHealth;
    }
    public abstract int GetMaxHealth();
    public abstract float GetPlayerMaxMovementSpeed();
}
