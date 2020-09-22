using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TVManager : MonoBehaviour,IInteractable
{
    private VideoPlayer vp;
    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponentInChildren<VideoPlayer>();
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


    public AdviceTypes InInteract()
    {
        return AdviceTypes.Usial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
