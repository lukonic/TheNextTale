using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingOptions : MonoBehaviour
{

    public PostProcessVolume volume;
    private Bloom Bloomas;
    private MotionBlur Motionbluras;
    private AutoExposure AutoExposureas;
    private DepthOfField DepthOfFieldas;
    bool Motionblur;
    bool Bloom;
    bool AutoExposure;
    bool DepthOfField;
    // Start is called before the first frame update
    void Start()
    {
        Motionblur = Convert.ToBoolean(PlayerPrefs.GetInt("MotionBlur", 1));
        Bloom = Convert.ToBoolean(PlayerPrefs.GetInt("Bloom", 1));
        AutoExposure = Convert.ToBoolean(PlayerPrefs.GetInt("AutoExposure", 1));
        DepthOfField = Convert.ToBoolean(PlayerPrefs.GetInt("DepthOfField", 1));

        volume.profile.TryGetSettings(out Bloomas);
        volume.profile.TryGetSettings(out Motionbluras);
        volume.profile.TryGetSettings(out AutoExposureas);
        volume.profile.TryGetSettings(out DepthOfFieldas);

        Bloomas.active = Bloom;
        Motionbluras.active = Motionblur;
        AutoExposureas.active = AutoExposure;
        DepthOfFieldas.active = DepthOfField;

        
        AudioListener.volume = PlayerPrefs.GetFloat("Volume", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
