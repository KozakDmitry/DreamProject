using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class DoorScript : MonoBehaviour,ISaveable,IInteractable
{
    enum DoorVariables { Finish,IsOpen};
    Animator[] animators;
    private bool Finish= false;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        SaveLoad.SubscribeSV(this.gameObject);
        animators = GetComponentsInChildren<Animator>();
        //foreach(Animator an in animators)
        //{
        //    Debug.Log(an.name);
        //}
    }

    public void Save()
    {
        JSONArray save = new JSONArray();
        save.Add("Finish", Finish);
        save.Add("isOpen", isOpen);

        SaveLoad.saveFile.Add("Window", save);
    }

    public void Load()
    {
        JSONArray saveData = new JSONArray();
        saveData.Add(SaveLoad.saveFile["Window"].AsArray);
        Finish = saveData["Finish"];
        isOpen = saveData["isOpen"];
        //saveData["Finish"] != null ? Finish = saveData["Finish"] : Finish = false;
        Check();
    }
    public void Check()
    {
        if (isOpen)
        {
            Open();
        }
    }
    private void Open()
    {
        animators[1].SetTrigger("TryToOpen");
        if (Finish)
        {
            if (!isOpen)
            {
                animators[0].SetTrigger("Open");
            }
            else
            {
                animators[0].SetTrigger("Close");
            }

        }
    }
    public AdviceTypes InInteract()
    {
        return AdviceTypes.Usial;
    }
    public bool Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
        }
        return false;
    }
    public void OutInteract()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
