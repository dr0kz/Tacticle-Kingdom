using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelsData
{
    public int level; //storing the current level
    public int Diamonds; //storing the number of collected diamonds
    public int[] unlockedPlayers; //In this array we store the players that are unlocked
    public int[] UnlockedAbilities;
    public int PlayerCastleLevel;
    public int CastleUpgradStatus;
    public int Gold;

    public LevelsData(int lvl,int dmd,int gold,int[] unlockedCharacters,int[] unlockedAbilities, int playerCastleLevel,int castleUpgradStatus)
    {
        Gold = gold;
        CastleUpgradStatus = castleUpgradStatus;
        PlayerCastleLevel = playerCastleLevel;
        level = lvl;
        Diamonds = dmd;
        unlockedPlayers = new int[6];
        for(int i=0;i<6;i++)
        {
            unlockedPlayers[i] = unlockedCharacters[i];
        }
        UnlockedAbilities = new int[4];
        for(int i=0;i<4;i++)
        {
            UnlockedAbilities[i] = unlockedAbilities[i];
        }
    }

}
