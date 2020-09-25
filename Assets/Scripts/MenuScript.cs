using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;
    private MouseLook ml;
    void ChangeMenu()
    {
        menu.SetActive(!menu.activeSelf);
        if (menu.activeSelf)
        {
            ml.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            ml.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Start()
    {
        ml = GetComponent<MouseLook>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeMenu();
            
        }
    }
}
