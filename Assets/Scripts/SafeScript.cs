using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class SafeScript : MonoBehaviour,IInteractable,ISaveable
{
    [SerializeField]
    private Text textInput;
    [SerializeField]
    private int codeValue;
    private bool isLocked = true;
    Animator am;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Camera cam;
    private void Start()
    {
        SaveLoad.SubscribeSV(this.gameObject);
        am = GetComponent<Animator>();
        //cam = player.GetComponentInChildren<Camera>();
    }
    public bool Interact()
    {
        if (isLocked)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                cam.gameObject.SetActive(true);
                player.GetComponentInChildren<Camera>().gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                return true;
            }
        }
        else
        {
            am.SetTrigger("Close");
            isLocked = true;
        }
        return false;
    }

    public void OutInteract()
    {
        cam.gameObject.SetActive(false);
        player.GetComponentInChildren<Camera>(true).gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public AdviceTypes InInteract()
    {
        return AdviceTypes.Usial;
    }

    public void Save()
    {
        JSONArray save = new JSONArray();
        save.Add("codeValue", codeValue);
        save.Add("isLocked",isLocked);
        save.Add("textInput", textInput.text);
        SaveLoad.saveFile.Add("Safe", save);
    }


    public void Load()
    {
        JSONArray saveData = new JSONArray();
        saveData.Add(SaveLoad.saveFile["Safe"].AsArray);
        codeValue = saveData["codeValue"];
        isLocked = saveData["isLocked"];
        textInput.text = saveData["textInput"];
        Check();
    }

    public void Check()
    {
        if (!isLocked)
        {
            am.SetTrigger("Open");
        }
    }
    public void AddNum(int num)
    {
        textInput.text += num;
    }
    public void RemoveNum()
    {
        textInput.text.Remove(textInput.text.Length);
    }
    public void RemoveAll()
    {
        textInput.text = string.Empty;
    }
    public void CheckCode()
    {
        if (int.Parse(textInput.text) == codeValue)
        {
            am.SetTrigger("Open");
            isLocked = false;
            textInput.text = string.Empty;
            OutInteract();
        }
        else
        {
            RemoveAll();
        }
    }
}
