using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LaptopScript : MonoBehaviour, IPointerDownHandler,IInteractable,ISaveable
{
    [SerializeField]
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
    [SerializeField]
    private InputField inpFl;
    bool Interacting = false;

    void Awake()
    {
        SaveLoad.SubscribeSV(this.gameObject);
    }

    void Start()
    {

        string txt = string.Empty;
        if (SaveLoad.continieGame)
        {
            txt = PlayerPrefs.GetString("Notepad");
        }
        else
        {
            txt = "Code Is 4562";
        }
        inpFl.text = txt;
    }   
    public void OutInteract()
    {
        offScreen.SetActive(true);
        notepad.SetActive(false);
        cam.gameObject.SetActive(false);
        player.GetComponentInChildren<Camera>(true).gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public bool Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Cursor.visible = true;
            cam.gameObject.SetActive(true);
            player.GetComponentInChildren<Camera>(true).gameObject.SetActive(false);
            offScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            return true;
        }
        else
            return false;
    }
    private void OnDestroy()
    {
        SaveLoad.SaveAll -= Save;
        SaveLoad.LoadAll -= Load;
    }
    public AdviceTypes InInteract()
    {
        return AdviceTypes.Usial;
    }
    public void Save()
    {
        JSONObject saveData = new JSONObject();
        saveData.Add("Interact", Interacting);
        SaveLoad.saveFile.Add("Laptop", saveData);
    }
    public void Load()
    {
        JSONObject saveData = new JSONObject();
        saveData.Add(SaveLoad.saveFile["Laptop"].AsArray);
    }
    public void Check()
    {

    }
    public void SaveNotepad()
    {
        string text = string.Empty;
        string toSave = string.Empty;
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

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
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
