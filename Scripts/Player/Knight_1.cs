using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_1 : PlayerBaseClass
{
    public Stun DoubleAxePrefab;
    private float luckyShot;
    private bool MultipleAttack = true;
    public void Init(Vector2 mydir,int type) //getting Right Vector from PlayerInstantiating class
    {
        KnightType = type;
        dir = mydir;
    }
    void Update()
    {
        RaycastCheckUpdate();
        if (Shield==true)
        {
            ShieldPrefab.SetActive(true);
        }
        else
        {
            ShieldPrefab.SetActive(false);
        }
        if (isPlayerMoveing && playerHealth!=0) // moveing right while dont hit enemy
        {
            animator.SetFloat("Speed", 1);
            transform.Translate(dir * Time.deltaTime * CharacterSpeed);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
        if (GameManager.GameOver == true)
        {
            Die();
        }

    }
    private RaycastHit2D CheckRaycast(Vector2 direction, LayerMask EnemyLayer) //RayCast
    {
        float directionOriginOffset;
        if (direction.x > 0)
        {
            directionOriginOffset = originOffset;
        }
        else
        {
            directionOriginOffset = originOffset * -1;
        }
        Vector2 startingPosition = new Vector2(transform.position.x + directionOriginOffset, transform.position.y);
        Debug.DrawRay(startingPosition, direction, Color.white); //Good for Debugging. Displaying the raycast ( turn on GIZMOS)
        return Physics2D.Raycast(startingPosition, direction, raycastMaxDistance, EnemyLayer);
    }
    private void RaycastCheckUpdate()
    {
        Vector2 direction = new Vector2(raycastMaxDistance, 0);
        RaycastHit2D hit = CheckRaycast(direction, EnemyLayer);
        RaycastHit2D sameHit = CheckRaycast(direction, SameLayer);
        RaycastHit2D hitCastle = CheckRaycast(direction, CastleLayer);
        if(sameHit.collider || isStuned)
        {
            isPlayerMoveing = false;
        }
        else if (hit.collider)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= attackTime && playerHealth != 0)//hit.collider.GetComponent<EnemyBaseClass>().ReturnEnemyHealth() != 0
            {
                animator.SetTrigger("AttackTrigger");
                elapsed = elapsed % attackTime;
                luckyShot = Random.Range(0f, 1f);
                if (KnightType == 4 && MultipleAttack == true)
                {
                    if (luckyShot <= 1 / 1.7f)
                    {
                        elapsed = attackTime-0.42f;
                        MultipleAttack = false;
                        StartCoroutine(ResetMultipleAttack());
                    }
                }
                if (KnightType == 1)
                {
                    sound = "attack1";
                }
                else if (KnightType == 2)
                {
                    sound = "attack3";
                }
                else if (KnightType == 3 || KnightType == 4)
                {
                    sound = "attack2";
                }
                if(luckyShot<=1/4f && KnightType==2)
                {
                    Vector3 StunPosition= new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y + 2.85f, 0f);
                    Stun stun = Instantiate(DoubleAxePrefab, StunPosition, Quaternion.Euler(0,0,180));
                }
                if (luckyShot <= 1/2.5 && (KnightType == 3 || KnightType == 4))
                {
                    StartCoroutine(HitDelay(hit, sound, true));
                }
                else
                {
                    StartCoroutine(HitDelay(hit, sound, false));
                }
            }
            isPlayerMoveing = false;
            animator.SetTrigger("DontAttackTrigger");
        }
        else if (hitCastle.collider)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= attackTime && playerHealth != 0)
            {
                elapsed = elapsed % attackTime;
                animator.SetTrigger("AttackTrigger");
                StartCoroutine(HitDelay(hitCastle, "attackCastle", false));
                
            }
            isPlayerMoveing = false;
            animator.SetTrigger("DontAttackTrigger");
        }
        else
        {
            isPlayerMoveing = true;
        }
    }
    private IEnumerator HitDelay(RaycastHit2D hit,string sound,bool critical)
    {
        yield return new WaitForSeconds(0.145f);
        if (hit.collider != null)
        {
            if (critical)
            {
                hit.collider.gameObject.GetComponent<EnemyBaseClass>().TakeDamage(CharacterDamage+CharacterDamage/2);
                hit.collider.gameObject.GetComponent<EnemyBaseClass>().CriticalHit();

                if (playerHealth != 0)
                {
                    if (transform.tag == "Elf")
                    {
                        playerHealth += 70;
                    }
                    else
                    {
                        playerHealth += 30;
                    }
                    if (playerHealth >= CharacterHealth)
                    {
                        playerHealth = CharacterHealth;
                    }
                }
                healthBar.SetHealth(playerHealth);
                //hit.collider.gameObject.SendMessage("TakeDamage", 2 * CharacterDamage); //Critical damage
                //hit.collider.gameObject.SendMessage("CriticalHit");
            }
            else if (sound == "attackCastle")
            {
                hit.collider.gameObject.GetComponent<EnemyCastle>().TakeDamage(CharacterDamage);
                //hit.collider.gameObject.SendMessage("TakeDamage", CharacterDamage);
            }
            else
            {
                hit.collider.gameObject.GetComponent<EnemyBaseClass>().TakeDamage(CharacterDamage);
            }
            SoundManager.PlaySound(sound);
        }
    }
    private IEnumerator ResetMultipleAttack()
    {
        yield return new WaitForSeconds(3f);
        MultipleAttack = true;
    }
    public override int GetMaxHealth() // Function that return player's health
    {
        return CharacterHealth;
    }
    public override float GetPlayerMaxMovementSpeed()
    {
        return CharacterSpeed;
    }

}
