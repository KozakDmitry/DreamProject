using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void SaveGame()
    {
        Debug.Log("Saved");
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Exit");
    }
}
