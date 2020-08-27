using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateManager : MonoBehaviour
{
    private string selectedLanguage;
    private TranslateObj[] allTranslateObj;
    // Start is called before the first frame update
    void Start()
    {
        Translator.ReadCSVFile();
        selectedLanguage = Translator.SelectStartLanguage();
        allTranslateObj = FindObjectsOfType<TranslateObj>() as TranslateObj[];
        foreach(TranslateObj obj in allTranslateObj)
        {
            obj.ChangeText(Translator.SendPhrase(obj.numText));
        }
    }
    // Update is called once per frame
        void Update()
    {
        
    }
}
