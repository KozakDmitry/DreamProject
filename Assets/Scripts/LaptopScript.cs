using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LaptopScript : MonoBehaviour, IPointerDownHandler
{
    private static string nameProg = "Notepad";
    private DateTime time;
    private int countClicks = 0;
    [SerializeField]
    private GameObject notepad;
    [SerializeField]
    private GameObject offScreen;
    private InputField inpFl;

    // Start is called before the first frame update
    void Start()
    {
        inpFl = GetComponentInChildren<InputField>();
        string txt = "";
        txt = PlayerPrefs.GetString("Notepad");
        txt = txt.Replace("", "/n");
        inpFl.text = txt;
    }
        
    public void SaveNotepad()
    {
        string text = "";
        string toSave = "";
        text = inpFl.text;
        toSave = text.Replace("/n", " ");
        PlayerPrefs.SetString("Notepad", toSave);
        PlayerPrefs.Save(); 
    }

        
    public void EnterNotepad()
    {
        Debug.Log("Seconds");
        notepad.SetActive(true);
    }
    public void ExitNotepad()
    {
        Debug.Log("No seconds");

        notepad.SetActive(false);
    }
    public void ExitLaptop()
    {
        Debug.Log("Seconds");
        offScreen.SetActive(true);
        notepad.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        //eventData.pointerCurrentRaycast.gameObject.tag
        if (eventData.pointerCurrentRaycast.gameObject.name == nameProg)
        {

            if (countClicks == 0)
            {
                countClicks++;
                time = DateTime.Now;
            }
            else if (countClicks > 0  && (DateTime.Now - time).TotalSeconds < 0.5f)
            {

                notepad.SetActive(true);
            }
            else
                countClicks = 0;
        }
       
    }
}
