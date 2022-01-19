using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleMage : MonoBehaviour
{
    public CastleRangeWeapon magicPrefab;
    public Transform RangeWeaponPosition;
    public int CharacterDamage;
    public Animator animator;
    private float DistanceBeforeCanShoot=200f;
    public int playerHealth;

    public CharacterHealthBar healthBar;

    private float elapsed = 1.8f;

    void Start()
    {
        animator.SetFloat("Health", playerHealth);
        healthBar.SetMaxHealth(playerHealth);
    }
    protected void Die()
    {
        CancelInvoke();
        Destroy(gameObject); //Destoring the player
    }
    public void TakeDamage(int damage)
    {
        if (PlayerBaseClass.Shield == false)
        {
            playerHealth = Mathf.Max(0, playerHealth - damage);
            if (playerHealth == 0)
            {
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
    void Update()
    {
        FindClosestEnemy();
    }
    private void FindClosestEnemy()
    {
        ClosestEnemy closestEnemy = null;

        ClosestEnemy[] allEnemies = GameObject.FindObjectsOfType<ClosestEnemy>();

        foreach(ClosestEnemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy<DistanceBeforeCanShoot)
            {
                closestEnemy = currentEnemy;
            }
        }  
        if (closestEnemy != null)
        {
            elapsed += Time.deltaTime;
            if(elapsed>=1.8f && playerHealth != 0)
            {
                elapsed = elapsed % 1.8f;
                StartCoroutine(Attack(closestEnemy));
            }
            Debug.DrawLine(this.transform.position, closestEnemy.transform.position,Color.red);
        }
        
    }
    private IEnumerator Attack(ClosestEnemy closestEnemy)
    {
        animator.SetTrigger("AttackTrigger");
        yield return new WaitForSeconds(0.4f);
        CastleRangeWeapon weapon = Instantiate(magicPrefab);
        weapon.transform.position = RangeWeaponPosition.transform.position;
        weapon.Init(closestEnemy, CharacterDamage);
        SoundManager.PlaySound("magicspell");
        animator.SetTrigger("DontAttackTrigger");
    }
    public int getDamage()
    {
        return CharacterDamage;
    }

}
