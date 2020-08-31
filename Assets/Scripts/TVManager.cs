using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TVManager : MonoBehaviour
{
    private VideoPlayer vp;
    public void PlayTV()
    {
        vp.Play();
    }
    public void StopTV()
    {
    
        vp.Stop();
    }
    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponentInParent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
