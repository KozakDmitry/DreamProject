using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TVManager : MonoBehaviour,IInteractable,ISaveable
{
    private VideoPlayer vp;
    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponentInChildren<VideoPlayer>();
        SaveLoad.SubscribeSV(this.gameObject);
    }
    public bool Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (vp.isPlaying)
            {
                vp.Stop();
            }
            else
            {
                vp.Play();
            }
        }
        return false;
    }
    public void OutInteract()
    {

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
