using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range_Enemy :EnemyBaseClass
{

    public RangeWeapon arrowPrefab;
    public RangeWeapon bulletPrefab;
    public Transform RangeWeaponPosition;

    public float raycastMaxDistanceFire = 10f;

    private int CharacterType;

    public void Init(Vector2 mydir, int characterType) //getting Right Vector from PlayerInstantiating class
    {
        dir = mydir;
        CharacterType = characterType;
    }
    void Update()
    {
        RaycastCheckUpdate();
        if (isEnemyMoveing && enemyHealth != 0 && IsStuned == false) // moveing right while dont hit enemy
        {
            animator.SetFloat("Speed", 1);
            transform.Translate(dir * Time.deltaTime * enemyMovementSpeed);
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
    private RaycastHit2D CheckRaycast(Vector2 direction, LayerMask EnemyLayer, int flag) //RayCast
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
        Debug.DrawRay(startingPosition, direction, Color.red); //Good for Debugging. Displaying the raycast (turn on GIZMOS)
        if (flag == 1)
        {
            return Physics2D.Raycast(startingPosition, direction, raycastMaxDistanceFire, EnemyLayer);
        }
        else
        {
            return Physics2D.Raycast(startingPosition, direction, raycastMaxDistance, EnemyLayer);
        }
    }
    private void RaycastCheckUpdate()
    {
        Vector2 direction = new Vector2(raycastMaxDistance, 0); //this vector is for only detecting player of the same layer
        Vector2 direction2 = new Vector2(raycastMaxDistanceFire, 0); //this vector is for detecting enemy and enemy castle

        RaycastHit2D playerHit = CheckRaycast(-direction2, PlayerLayer, 1); //for detecting enemy
        RaycastHit2D castleHit = CheckRaycast(-direction2, CastleLayer, 1); //for detecting enemy castle;

        RaycastHit2D sameHit = CheckRaycast(-direction, SameLayer, 0);
        if(IsStuned==true)
        {
            isEnemyMoveing = false;
        }
        else if (sameHit.collider && (playerHit.collider || castleHit.collider))
        {
            elapsed += Time.deltaTime;
            isEnemyMoveing = false;
            if (elapsed >= AttackTime)
            {
                elapsed = elapsed % AttackTime;
                StartCoroutine(Attack(CharacterType));
                //Attack(isArcher);
            }
        }
        else if (!sameHit.collider && (playerHit.collider || castleHit.collider))
        {
            elapsed += Time.deltaTime;
            isEnemyMoveing = false;
            if (elapsed >= AttackTime && enemyHealth!=0)
            {
                elapsed = elapsed % AttackTime;
                StartCoroutine(Attack(CharacterType));
                //Attack(isArcher);
            }
        }
        else if (sameHit.collider && !playerHit.collider && !castleHit.collider)
        {
            isEnemyMoveing = false;
        }
        else
        {
            isEnemyMoveing = true;
        }
    }
    private IEnumerator Attack(int CharacterType)
    {
        animator.SetTrigger("AttackTrigger");
        yield return new WaitForSeconds(0.4f);
        if (CharacterType==1) //Instantiate (object, position, Quaternion.Euler(0, 90, 0));
        {
            RangeWeapon weapon = Instantiate(arrowPrefab);
            weapon.transform.position = RangeWeaponPosition.transform.position;
            weapon.transform.rotation = Quaternion.Euler(0, 180, 13);
            weapon.Init(Vector2.right, 1, CharacterDamage,true);

        }
        else if(CharacterType==2) //pirate
        {
            RangeWeapon weapon = Instantiate(bulletPrefab);
            weapon.transform.position = RangeWeaponPosition.transform.position;
            weapon.Init(Vector2.right, 3, CharacterDamage,true);
            SoundManager.PlaySound("bullet");
        }
        animator.SetTrigger("DontAttackTrigger");
    }
    public int getDamage()
    {
        return CharacterDamage;
    }
    public override int GetMaxHealth() // Function that return player's health
    {
        return CharacterHealth;
    }
    public override float GetEnemyMaxMovementSpeed()//Function that return player's movementSpeeds
    {
        return CharacterSpeed;
    }
}
