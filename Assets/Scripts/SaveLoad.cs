using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    public static Save save = new Save();
    public static void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.gd");
        bf.Serialize(file, Save.current);
        file.Close();
        Debug.Log("Save");
    }
    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/save.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.gd", FileMode.Open);
            Save.current = (Save)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            Save.current = new Save();
        }
    }

    public static void Reset()
    {
        Save.current = new Save();
        SaveLoad.SaveGame();
    }

}
