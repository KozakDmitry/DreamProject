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
    [SerializeField]
    Animator am;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Camera cam;

    private enum safeTrigger {Open,Close, OpenedSafe };
    private void Awake()
    {
        SaveLoad.SubscribeSV(this.gameObject);
    }
    private void Start()
    {
    }
    public bool Interact()
    {
        if (isLocked)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cursor.visible = true;
                cam.gameObject.SetActive(true);
                player.GetComponentInChildren<Camera>().gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                return true;
            }
        }
        else
        {
            am.SetTrigger(safeTrigger.Close.ToString());
            isLocked = true;
        }
        return false;
    }

    public void OutInteract()
    {
        cam.gameObject.SetActive(false);
        player.GetComponentInChildren<Camera>(true).gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public AdviceTypes InInteract()
    {
        return AdviceTypes.Usial;
    }

    public void Save()
    {
        JSONObject save = new JSONObject();
        save.Add("codeValue", codeValue);
        save.Add("isLocked",isLocked);
        save.Add("textInput", textInput.text);
        SaveLoad.saveFile.Add("Safe", save);
    }

    private void OnDestroy()
    {
        SaveLoad.SaveAll -= Save;
        SaveLoad.LoadAll -= Load;
    }
    public void Load()
    {
        JSONObject saveData = new JSONObject();
        saveData.Add(SaveLoad.saveFile["Safe"]);
        codeValue = saveData["codeValue"];
        isLocked = saveData["isLocked"];
        textInput.text = saveData["textInput"];
        Check();
    }

    public void Check()
    {
        if (!isLocked)
        {
            am.SetTrigger(safeTrigger.OpenedSafe.ToString());
        }
    }
    public void AddNum(int num)
    {
        textInput.text += num;
    }
    public void RemoveNum()
    {
       textInput.text =  textInput.text.Substring(0, textInput.text.Length - 1);
    }
    public void RemoveAll()
    {
        textInput.text = string.Empty;
    }
    public void CheckCode()
    {
        if (int.Parse(textInput.text) == codeValue)
        {
            am.SetTrigger(safeTrigger.Open.ToString());
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
