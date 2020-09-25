using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audio;
    void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
            audio.volume=1;
    }

    void Update()
    {
        audio.volume = PlayerPrefs.GetFloat("volume");
    }
}