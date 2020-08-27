using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private bool isActive = false;
    public void Coop()
    {
        isActive = !isActive;
        GameObject.Find("/UIMenuMain/Canvas/Main Menu/JoinGame").SetActive(isActive);
        GameObject.Find("/UIMenuMain/Canvas/Main Menu/HostGame").SetActive(isActive);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }

    public void HidePanel(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void ShowPanel(GameObject obj)
    {
        obj.SetActive(true);
    }
}
