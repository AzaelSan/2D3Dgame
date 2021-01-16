using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(GameManager manager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/checkpoint.bin";
        FileStream stream = new FileStream(path, FileMode.Create);
        //Debug.Log(path);
        Data data = new Data(manager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static bool CheckFileExist()
    {
        string path = Application.persistentDataPath + "/checkpoint.bin";

        if (File.Exists(path))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static Data LoadData()
    {
        string path = Application.persistentDataPath + "/checkpoint.bin";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(stream) as Data;
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
