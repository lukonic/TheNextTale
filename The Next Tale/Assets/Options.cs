using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    bool Motionblur;
    bool Bloom;
    bool AutoExposure;
    bool DepthOfField;
    bool on;
    float volume;

    public GameObject Toggle_motion;
    public GameObject Toggle_bloom;
    public GameObject Toggle_auto;
    public GameObject Toggle_depth;
    public GameObject Slider;
    public GameObject postproc;
    // Start is called before the first frame update
    public void Start()
    {
        postproc = GameObject.FindGameObjectWithTag("PostProc");
        Motionblur = Convert.ToBoolean(PlayerPrefs.GetInt("MotionBlur",1));
        Bloom = Convert.ToBoolean(PlayerPrefs.GetInt("Bloom", 1));
        AutoExposure = Convert.ToBoolean(PlayerPrefs.GetInt("AutoExposure", 1));
        DepthOfField = Convert.ToBoolean(PlayerPrefs.GetInt("DepthOfField", 1));
        volume = PlayerPrefs.GetFloat("Volume", 1);
        AudioListener.volume = volume;


        print(volume);
        on = false;
        Toggle_motion.GetComponent<Toggle>().isOn = Motionblur;
        Toggle_bloom.GetComponent<Toggle>().isOn = Bloom;
        Toggle_auto.GetComponent<Toggle>().isOn = AutoExposure;
        Toggle_depth.GetComponent<Toggle>().isOn = DepthOfField;
        Slider.GetComponent<Slider>().value = volume;
        on = true;
    }

    public void GoBack()
    {

        PlayerPrefs.SetInt("MotionBlur", Convert.ToInt32(Motionblur));
        PlayerPrefs.SetInt("Bloom", Convert.ToInt32(Bloom));
        PlayerPrefs.SetInt("AutoExposure", Convert.ToInt32(AutoExposure));
        PlayerPrefs.SetInt("DepthOfField", Convert.ToInt32(DepthOfField));
        PlayerPrefs.SetFloat("Volume", volume);

        print(volume);
        this.gameObject.SetActive(false);
    }

    public void changePP()
    {

        PlayerPrefs.SetInt("MotionBlur", Convert.ToInt32(Motionblur));
        PlayerPrefs.SetInt("Bloom", Convert.ToInt32(Bloom));
        PlayerPrefs.SetInt("AutoExposure", Convert.ToInt32(AutoExposure));
        PlayerPrefs.SetInt("DepthOfField", Convert.ToInt32(DepthOfField));
        postproc = GameObject.FindGameObjectWithTag("PostProc");
        postproc.GetComponent<PostProcessingOptions>().change();
    }
    public void ChangeVolume()
    {
        if (on)
        {
            volume = Slider.GetComponent<Slider>().value;
            AudioListener.volume = volume;
            PlayerPrefs.SetFloat("Volume", volume);
        }
    }
    public void ChangeBlur()
    {
        if (on)
        {
            if (Motionblur)
            {
                Motionblur = false;
            }
            else
            {
                Motionblur = true;
            }
        }
    }
    public void ChangeBloom()
    {
        if (on)
        {
            if (Bloom)
            {
                Bloom = false;
            }
            else
            {
                Bloom = true;
            }
        }
    }
    public void ChangeAuto()
    {
        if (on)
        {
            if (AutoExposure)
            {
                AutoExposure = false;
            }
            else
            {
                AutoExposure = true;
            }
        }
    }
    public void ChangeDOF()
    {
        if (on)
        {
            if (DepthOfField)
            {
                DepthOfField = false;
            }
            else
            {
                DepthOfField = true;
            }
        }
    }


}
