using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData()
    {
        Debug.Log("SSS");
        Debug.Log(Application.persistentDataPath);
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/Data.sav", FileMode.Create);

        DataSaved dataSaved = new DataSaved();
        formatter.Serialize(stream, dataSaved);
        stream.Position = 0;//
        stream.Close();
    }

    public static DataSaved LoadData()
    {

        string path = Application.persistentDataPath + "/Data.sav";
        if (File.Exists(path))
        {
            Debug.Log("EE");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            stream.Position = 0; //
            formatter.Deserialize(stream);

            DataSaved data = formatter.Deserialize(stream) as DataSaved;
            stream.Position = 0;
            stream.Close();
            return data;

        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }

    }
}

[System.Serializable]
public class DataSaved
{
    public bool[] checkers;
    public float[] stats;
    public DataSaved()
    {
        checkers = new bool[7];
        stats = new float[5];

        checkers[0] = Data.move;
        checkers[1] = Data.newGame;
        checkers[2] = Data.trainingLvl;
        checkers[3] = Data.lvl1;
        checkers[4] = Data.lvl2;
        checkers[5] = Data.lvl3;
        checkers[6] = Data.teleport;

        stats[0] = Data.playerHealth;
        stats[1] = Data.tpTime;
        stats[2] = Data.playerDamage;
        stats[3] = Data.alienBossHealth;
        stats[4] = Data.skeletonBossHealth;

    }

    public bool[] GetBooleans()
    {
        return checkers;
    }

    public float[] GetStats()
    {
        return stats;
    }
}
