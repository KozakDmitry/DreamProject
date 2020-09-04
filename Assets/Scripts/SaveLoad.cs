using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;

public static class SaveLoad
{
    public delegate void SaveContainer();
    public static event SaveContainer SaveAll = delegate { };
    public delegate void LoadContainer();
    public static event LoadContainer LoadAll = delegate { };
    private static string saveFileName = "/Saves.json";
    private static string pathFile = Application.persistentDataPath+ saveFileName;
    public static JSONObject saveFile = new JSONObject();

    public static void SubscribeSV(GameObject gm)
    {
        ISaveable isave = gm.GetComponent<ISaveable>();
        SaveAll += isave.Save;
        LoadAll += isave.Load;  
    }
    private static void OpenFile()
    {
        
    }
    static void SaveAllData()
    {
        SaveAll();
        File.WriteAllText(pathFile, saveFile.ToString());
    }

    static void LoadAllData()
    {
        string JsonFile = File.ReadAllText(pathFile);
        saveFile = (JSONObject)JSON.Parse(JsonFile);
        LoadAll();
        
    }


}
