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
    private static string pathFile = Application.persistentDataPath;
    static JSONObject saveFile = new JSONObject();

    private static void OpenFile()
    {
        
    }
    static void SaveAllData()
    {
        SaveAll();
        File.WriteAllText(pathFile + saveFileName, saveFile.ToString());
    }

    static void LoadAllData()
    {
        string JsonFile = File.ReadAllText(pathFile + saveFileName);
        saveFile = (JSONObject)JSON.Parse(JsonFile);
        LoadAll();
        
    }


}
