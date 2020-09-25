using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        if (SaveLoad.continieGame)
            SaveLoad.LoadAllData();
    }
    public void SaveGame()
    {
        SaveLoad.SaveAllData();     
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
