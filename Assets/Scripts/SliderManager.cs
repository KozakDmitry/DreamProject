using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public Slider slider;
    private float volume;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("volume")) volume = 1;
    }

    private void Update()
    {
        if(volume!=slider.value)
        {
            PlayerPrefs.SetFloat("volume", slider.value);
            PlayerPrefs.Save();
            volume = slider.value;
        }
    }
}
