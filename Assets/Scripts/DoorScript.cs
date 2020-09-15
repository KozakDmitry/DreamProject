using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour,ISaveable,IInteractable
{
    Animator[] animators;
    private bool Finish= false;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        SaveLoad.SubscribeSV(this.gameObject);
        animators = GetComponentsInChildren<Animator>();
    }

    public void Save()
    {

    }

    public void Load()
    {

    }

    public int InInteract()
    {
        return 0;
    }
    public bool Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
