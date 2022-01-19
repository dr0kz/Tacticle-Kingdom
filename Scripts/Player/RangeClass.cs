using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeClass : PlayerBaseClass
{

    public RangeWeapon arrowPrefab;
    public RangeWeapon magicPrefab;
    public Transform RangeWeaponPosition;

    public float raycastMaxDistanceFire = 10f;

    private bool isArcher;

    public void Init(Vector2 mydir,bool characterType) //getting Right Vector from PlayerInstantiating class
    {
        dir = mydir;
        isArcher = characterType;
    }
    void Update()
    {
        RaycastCheckUpdate();
        if (Shield == true)
        {
            ShieldPrefab.SetActive(true);
        }
        else
        {
            ShieldPrefab.SetActive(false);
        }
        if (isPlayerMoveing && isStuned==false) // moveing right while dont hit enemy
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
    private RaycastHit2D CheckRaycast(Vector2 direction, LayerMask EnemyLayer,int flag) //RayCast
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
        if (flag==1)
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

        RaycastHit2D enemyHit = CheckRaycast(direction2, EnemyLayer,1); //for detecting enemy
        RaycastHit2D castleHit = CheckRaycast(direction2, CastleLayer,1); //for detecting enemy castle;

        RaycastHit2D sameHit = CheckRaycast(direction, SameLayer,0);
        if(isStuned)
        {
            isPlayerMoveing = false;
        }
        else if (sameHit.collider && (enemyHit.collider || castleHit.collider))
        {
            elapsed += Time.deltaTime;
            isPlayerMoveing = false;
            if (elapsed >= 1.8f)
            {
                elapsed = elapsed % 1.8f;
                StartCoroutine(Attack(isArcher));
                Attack(isArcher);
            }
        }
        else if (!sameHit.collider && (enemyHit.collider || castleHit.collider))
        {
            elapsed += Time.deltaTime;
            isPlayerMoveing = false;
            if (elapsed >= 1.8f && playerHealth!=0)
            {
                elapsed = elapsed % 1.8f;
                StartCoroutine(Attack(isArcher));
                Attack(isArcher);
            }
        }
        else if (sameHit.collider && !enemyHit.collider && !castleHit.collider)
        {
            isPlayerMoveing = false;
        }
        else
        {
            isPlayerMoveing = true;
        }
    }
    private IEnumerator Attack(bool isArcher)
    {
        animator.SetTrigger("AttackTrigger");
        yield return new WaitForSeconds(0.4f);
        if (isArcher) //Instantiate (object, position, Quaternion.Euler(0, 90, 0));
        {
            RangeWeapon weapon = Instantiate(arrowPrefab);
            weapon.transform.position = RangeWeaponPosition.transform.position;
            weapon.transform.rotation = Quaternion.Euler(0,0, 13);
            weapon.Init(Vector2.right, 1, CharacterDamage,false);
            
        }
        else
        {
            RangeWeapon weapon = Instantiate(magicPrefab);
            weapon.transform.position = RangeWeaponPosition.transform.position;
            weapon.Init(Vector2.right, 2, CharacterDamage,false);
            SoundManager.PlaySound("magicspell");
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
    public override float GetPlayerMaxMovementSpeed() //Function that return player's movementSpeeds
    {
        return CharacterSpeed;
    }
}
