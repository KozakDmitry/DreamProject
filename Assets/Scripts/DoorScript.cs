using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Timeline;

public class DoorScript : MonoBehaviour,ISaveable,IInteractable
{

    [SerializeField]
    private AudioSource aS;
    [SerializeField]
    private AudioClip knock;
    [SerializeField]
    private AudioClip open;
    enum DoorVariables { Finish,IsOpen};
    Animator[] animators;
    private bool Finish= true;
    private bool isOpen = false;
    private enum doorTriggers {TryToOpen,Open,Close};
    private void Awake()
    {
        SaveLoad.SubscribeSV(this.gameObject);
    }
    void Start()
    {

        animators = GetComponentsInChildren<Animator>();

    }
    private void OnDestroy()
    {
        SaveLoad.SaveAll -= Save;
        SaveLoad.LoadAll -= Load;
    }
    public void Save()
    {
        JSONObject save = new JSONObject();
        save.Add("Finish", Finish);
        save.Add("isOpen", isOpen);
        SaveLoad.saveFile.Add("Door", save);
    }

    public void Load()
    {
        JSONObject saveData = new JSONObject();
        saveData.Add(SaveLoad.saveFile["Door"]);
        Debug.Log(saveData);
        Finish = saveData["Finish"];
        isOpen = saveData["isOpen"];
        Check();
    }
    public void Check()
    {
        if (isOpen)
        {
            Open();
        }
    }
    private void SoundPlay(AudioClip clip)
    {
        aS.clip = clip;
        aS.Play();
    }
    private void Open()
    {
        animators[1].SetTrigger(doorTriggers.TryToOpen.ToString());
        if (Finish)
        {
            SoundPlay(open);
            if (!isOpen)
            {
                animators[0].SetTrigger(doorTriggers.Open.ToString());
            }
            else
            {
                animators[0].SetTrigger(doorTriggers.Close.ToString());
            }
            
            isOpen = !isOpen;
        }
        else
        {
            SoundPlay(knock);
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
            Open();
        }
        return false;
    }
    public void OutInteract()
    {

    }
}
