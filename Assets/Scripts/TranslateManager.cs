using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateManager : MonoBehaviour
{
    private TranslateObj[] allTranslateObj;
    void Start()
    {
        Translator.ReadCSVFile();
        allTranslateObj = FindObjectsOfType<TranslateObj>() as TranslateObj[];
        ChangeLan();
    }

    public void ChangeLan()
    {
        foreach (TranslateObj obj in allTranslateObj)
        {
            obj.ChangeText(Translator.SendPhrase(obj.numText));
        }
    }
}