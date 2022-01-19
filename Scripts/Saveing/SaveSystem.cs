using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem  
{
    public static void SaveLevel(int lvl, int dmd,int gold, int[] unlockedCharacters,int[] unlockedAbilities,int playerCastleLevel,int CastleUpgradStatus)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";

        FileStream stream = new FileStream(path, FileMode.Create);

        LevelsData data = new LevelsData(lvl,dmd,gold, unlockedCharacters, unlockedAbilities, playerCastleLevel, CastleUpgradStatus);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static LevelsData LoadLevel()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelsData data=formatter.Deserialize(stream) as LevelsData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
    public static void DeleteData()
    {
        string path = Application.persistentDataPath + "/player.fun";
        File.Delete(path);
    }
}
