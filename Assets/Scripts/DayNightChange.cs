using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightChange : MonoBehaviour
{
    [Range(0, 1)]
    public float timeOfDay = 0f;
    public float dayDuration = 24f;
    public Light Sun;   
    public Light Moon;
    public ParticleSystem pS;
    [Space]
    public AnimationCurve sunCurve;
    public AnimationCurve moonCurve;
    [Space]
    public Material sunBox;
    public Material moonBox;
    public AnimationCurve boxCurve;


    private float sunIntensity;
    private float moonIntensity;

    private void Start()
    {
        sunIntensity = Sun.intensity;
        moonIntensity = Moon.intensity;
    }



    private void Update()
    {
        
        timeOfDay =((float)DateTime.Now.Hour + ((float)DateTime.Now.Minute * 0.01f)) / dayDuration;
        if (timeOfDay >= 1)
            timeOfDay -= 1;

        RenderSettings.skybox.Lerp(moonBox, sunBox, boxCurve.Evaluate(timeOfDay));
        RenderSettings.sun = boxCurve.Evaluate(timeOfDay)>0.1f ? Sun : Moon;
        DynamicGI.UpdateEnvironment();

        var mainModule = pS.main;
        mainModule.startColor = new Color(1, 1, 1, 1 - boxCurve.Evaluate(timeOfDay));
        Sun.transform.localRotation = Quaternion.Euler(timeOfDay * 360f, 180, 0);
        Moon.transform.localRotation = Quaternion.Euler(timeOfDay * 360f+180f, 180, 0);
        Sun.intensity = sunIntensity*sunCurve.Evaluate(timeOfDay);
        Moon.intensity = moonIntensity*moonCurve.Evaluate(timeOfDay);
    }
}
