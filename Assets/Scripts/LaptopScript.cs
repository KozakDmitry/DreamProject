using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LaptopScript : MonoBehaviour, IPointerDownHandler,IInteractable
{

    private Camera cam;
    private static string nameProg = "Notepad";
    private DateTime time;
    private int countClicks = 0;
    [SerializeField]
    private GameObject notepad;
    [SerializeField]
    private GameObject offScreen;
    [SerializeField]
    private GameObject player;
    private InputField inpFl;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInParent<Camera>();
        inpFl = GetComponentInChildren<InputField>();
        string txt = "";
        txt = PlayerPrefs.GetString("Notepad");
        txt = txt.Replace("", "/n");
        inpFl.text = txt;
    }
    public void Interact()
    {
        cam.gameObject.SetActive(true);
        player.GetComponentInChildren<Camera>().gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
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
        notepad.SetActive(true);
    }
    public void ExitNotepad()
    {
        notepad.SetActive(false);
    }
    public void ExitLaptop()
    {
        Debug.Log("Seconds");
        offScreen.SetActive(true);
        notepad.SetActive(false);
        cam.gameObject.SetActive(false);
        player.GetComponentInChildren<Camera>().gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
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
