using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject continieButton;
    private bool isActive = false;
    private void CheckContinie()
    {
        continieButton.SetActive(SaveLoad.CheckSave());
    }
    private void Start()
    {
        CheckContinie();
    }
    public void Coop()
    {
        isActive = !isActive;
        GameObject.Find("/UIMenuMain/Canvas/Main Menu/JoinGame").SetActive(isActive);
        GameObject.Find("/UIMenuMain/Canvas/Main Menu/HostGame").SetActive(isActive);
    }
    public void Continie()
    {
        SceneManager.LoadScene("Game");
        SaveLoad.continieGame = true;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
        SaveLoad.continieGame = false;
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ResetGame()
    {

        SaveLoad.ResetAllProgress();
        CheckContinie();
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
