using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleInstantiate : MonoBehaviour
{
    public Transform PlayerCastlePosition; //instantiating the player castle on this position
    public PlayerCastle CastleLevel1;
    public PlayerCastle CastleLevel2;
    public PlayerCastle CastleLevel3;
    public PlayerCastle CastleLevel4;

    public Transform EnemyCastlePosition;
    public EnemyCastle CastleLevelX;
    public int EnemyCastleHp;
    private int PlayerCastleLevel = 0;
    private int level = 0;


    void Start()
    {
        LoadLevel();
        if (PlayerCastleLevel == 0)
        {
            PlayerCastle castle = Instantiate(CastleLevel1);
            castle.transform.position = PlayerCastlePosition.position;
            castle.Init(500);//castle health
        }
        else if (PlayerCastleLevel == 1)
        {
            PlayerCastle castle = Instantiate(CastleLevel2);
            castle.transform.position = PlayerCastlePosition.position;
            castle.Init(750);//castle health
        }
        else if (PlayerCastleLevel == 2)
        {
            PlayerCastle castle = Instantiate(CastleLevel3);
            castle.transform.position = PlayerCastlePosition.position;
            castle.Init(1000);//castle health
        }
        else if (PlayerCastleLevel == 3)
        {
            PlayerCastle castle = Instantiate(CastleLevel4);
            castle.transform.position = PlayerCastlePosition.position;
            castle.Init(1400);//castle health
        }
        //EnemyCastle
        EnemyCastle enemycastle = Instantiate(CastleLevelX);
        enemycastle.transform.position = EnemyCastlePosition.position;
        enemycastle.Init(EnemyCastleHp);
    }
    private void LoadLevel()
    {
        LevelsData data = SaveSystem.LoadLevel();
        PlayerCastleLevel = data.PlayerCastleLevel;
        level = data.level;
    }
}
