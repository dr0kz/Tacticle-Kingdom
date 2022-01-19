using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCastle : MonoBehaviour
{
    public static int CastleHealth;

    private int IsMageUnlocked;
    private int level;

    public CastleMage Mage;

    public GameObject MageButton1;
    public GameObject MageButton2;
    public GameObject MageButton3;
    public GameObject MageButton4;

    public Transform MagePosition1;
    public Transform MagePosition2;
    public Transform MagePosition3;
    public Transform MagePosition4;

    public void Init(int health)
    {
        CastleHealth = health;
        LoadLevel();
        SetMageButtons();
    }
    private void SetMageButtons()
    {
        if(IsMageUnlocked==1 && level==0)
        {
            MageButton1.SetActive(true);
        }
        else if(IsMageUnlocked==1 && level==1)
        {
            MageButton2.SetActive(true);
        }
        else if (IsMageUnlocked == 1 && level == 2)
        {
            MageButton2.SetActive(true);
            MageButton3.SetActive(true);
        }
        else if(IsMageUnlocked==1 && level==3)
        {
            MageButton2.SetActive(true);
            MageButton3.SetActive(true);
            MageButton4.SetActive(true);
        }
    }
    public void Button1Pressed()
    {
        if(MoneyScript.moneyValue>=1000)
        {
            MoneyScript.moneyValue -= 1000;
            CastleMage mage = Instantiate(Mage, MagePosition1.position, Quaternion.identity);
            MageButton1.SetActive(false);
        }
    }
    public void Button2Pressed()
    {
        if (MoneyScript.moneyValue >= 1000)
        {
            MoneyScript.moneyValue -= 1000;
            CastleMage mage = Instantiate(Mage, MagePosition2.position, Quaternion.identity);
            MageButton2.SetActive(false);
        }
    }
    public void Button3Pressed()
    {
        if (MoneyScript.moneyValue >= 1000)
        {
            MoneyScript.moneyValue -= 1000;
            CastleMage mage = Instantiate(Mage, MagePosition3.position, Quaternion.identity);
            MageButton3.SetActive(false);
        }
    }
    public void Button4Pressed()
    {
        if (MoneyScript.moneyValue >= 1000)
        {
            MoneyScript.moneyValue -= 1000;
            CastleMage mage = Instantiate(Mage, MagePosition4.position, Quaternion.identity);
            MageButton4.SetActive(false);
        }
    }
    private void LoadLevel()
    {
        LevelsData data = SaveSystem.LoadLevel();
        IsMageUnlocked = data.unlockedPlayers[4];
        level = data.PlayerCastleLevel;
    }
    public void TakeDamage(int damage)
    {
        CastleHealth = Mathf.Max(0, CastleHealth - damage);
        if(CastleHealth==0)
        {
            GameManager.GameOver = true;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag=="EnemyArrow")
        {
            TakeDamage(other.GetComponent<RangeWeapon>().getDamageArrow());
            Destroy(other.gameObject);
        }
        if (other.transform.tag == "Bullet")
        {
            TakeDamage(other.GetComponent<RangeWeapon>().getDamageBullet());
            Destroy(other.gameObject);
        }
        if(other.transform.tag=="infect")
        {
            TakeDamage(other.GetComponent<Corona>().getCastleDamage());
            SoundManager.PlaySound("coronaDie");
            Destroy(other.gameObject);
        }
        if(other.transform.tag=="Bat")
        {
            TakeDamage(other.GetComponent<Bat>().getDamage());
            Destroy(other.gameObject);
        }
        if(other.transform.tag=="Ship")
        {
            TakeDamage(other.GetComponent<Ship>().getDamage());
            Destroy(other.gameObject);
            SoundManager.PlaySound("shipbreak");
        }
        if(other.transform.tag=="policeCar")
        {
            TakeDamage(other.GetComponent<PoliceCar>().getDamage());
            Destroy(other.gameObject);
        }
    }
}
