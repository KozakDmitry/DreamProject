using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LaptopScript : MonoBehaviour, IPointerDownHandler,IInteractable,ISaveable
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

    void Awake()
    {
        SaveLoad.SubscribeSV(this.gameObject);
    }

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            cam.gameObject.SetActive(true);
            player.GetComponentInChildren<Camera>().gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public int InInteract()
    {
        return 0;
    }
    public void Save()
    {
        JSONArray saveData = new JSONArray();
        saveData.Add("Interact", 0);
        SaveLoad.saveFile.Add("Laptop", saveData);
    }
    public void Load()
    {
        JSONArray saveData = new JSONArray();
        saveData.Add(SaveLoad.saveFile["Laptop"].AsArray);
    }
    public void OutInteract()
    {
       
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
