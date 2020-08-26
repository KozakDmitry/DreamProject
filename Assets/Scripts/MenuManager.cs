using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void SaveGame()
    {

    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
