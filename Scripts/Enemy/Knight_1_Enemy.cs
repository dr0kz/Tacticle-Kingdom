using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_1_Enemy : EnemyBaseClass
{

    public void Init(Vector2 mydir) //getting Left Vector from EnemyInstantiating class
    {
        dir = mydir;
    }
    void Update()
    {
        RaycastCheckUpdate();
        if (isEnemyMoveing && enemyHealth!=0 && IsStuned == false)
        {
            animator.SetFloat("Speed", 1);
            transform.Translate(dir * Time.deltaTime * CharacterSpeed);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
        if(GameManager.GameOver==true)
        {
            Die();
        }
    }
    private RaycastHit2D CheckRaycast(Vector2 direction, LayerMask PlayerLayer) //RayCast
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
        Debug.DrawRay(startingPosition, direction, Color.red); //Good for Debugging. Displaying the raycast ( turn on GIZMOS)
        return Physics2D.Raycast(startingPosition, direction, raycastMaxDistance, PlayerLayer);
    }
    private void RaycastCheckUpdate()
    {
        Vector2 direction = new Vector2(-raycastMaxDistance, 0);
        RaycastHit2D hit = CheckRaycast(direction, PlayerLayer);
        RaycastHit2D sameHit = CheckRaycast(direction, SameLayer);
        RaycastHit2D hitCastle = CheckRaycast(direction, CastleLayer);

        if(sameHit.collider || IsStuned == true)
        {
            isEnemyMoveing = false;
        }
        else if (hit.collider)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= AttackTime && enemyHealth != 0)
            {
                elapsed = elapsed % AttackTime;
                StartCoroutine(HitDelay(hit, soundNameAttackCharacter,false));
                animator.SetTrigger("AttackTrigger");
            }
            isEnemyMoveing = false;
            animator.SetTrigger("DontAttackTrigger");
        }
        else if (hitCastle.collider)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= AttackTime && enemyHealth != 0)
            {
                elapsed = elapsed % AttackTime;
                animator.SetTrigger("AttackTrigger");
                StartCoroutine(HitDelay(hitCastle, soundNameAttackCastle,true));
            }
            isEnemyMoveing = false;
            animator.SetTrigger("DontAttackTrigger");
        }
        else
        {
            isEnemyMoveing = true;
        }
    }
    private IEnumerator HitDelay(RaycastHit2D hit,string sound,bool attackCastle)
    {
        yield return new WaitForSeconds(0.145f);
        SoundManager.PlaySound(sound);
        if (hit.collider != null)
        {
            if(attackCastle)
            {
                hit.collider.gameObject.GetComponent<PlayerCastle>().TakeDamage(CharacterDamage);
            }
            else
            {
                if (transform.tag == "golem")
                {
                    if(Random.Range(0f,1f)<=1/3f)
                    {
                        hit.collider.gameObject.GetComponent<PlayerBaseClass>().golemStun();
                        SoundManager.PlaySound("golemStun");
                    }
                   
                }
                hit.collider.gameObject.GetComponent<PlayerBaseClass>().TakeDamage(CharacterDamage);
            }
        }
    }
    public override int GetMaxHealth() // Function that return player's health
    {
        return CharacterHealth;
    }
    public override float GetEnemyMaxMovementSpeed()
    {
        return CharacterSpeed;
    }
    public int getDamage()
    {
        return CharacterDamage;
    }
}
