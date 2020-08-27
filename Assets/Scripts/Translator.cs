using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;

public static class Translator
{
    private static string fileName = "Languages";
    private static string path = Application.dataPath +"/Localization/" + fileName;
    private static string choosedLanguage;
    private static string phrase;
    private static string[] phrases;
    private enum Languages
    {
        Russian,
        English
    }

    public static void SelectStartLanguage()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            choosedLanguage = LoadLanguage();
        }
        
    }
    public static int ReturnLanguage()
    {
        switch(choosedLanguage)
        {
            case "Russian":
                return 0;
            case "English":
                return 1;
            default:
                return 0;
        }
    }
    public static string SendPhrase(int num)
    {
        var data = phrases[num].Split(';');

        return data[ReturnLanguage()]; 
    }
    public static string LoadLanguage()
    {
        
        return Enum.IsDefined(typeof(Languages), PlayerPrefs.GetString("Language")) ? PlayerPrefs.GetString("Language") : Application.systemLanguage.ToString();
    }

    public static void ChangeLanguage(string choose)
    {
        choosedLanguage = choose;
    }


    private static void ReadCSVFile()
    {
        phrases = File.ReadAllLines(path);
    }
}
