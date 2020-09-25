using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TVManager : MonoBehaviour,IInteractable
{
    private VideoPlayer vp;
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
    public AdviceTypes InInteract()
    {
        return AdviceTypes.Usial;
    }

}
