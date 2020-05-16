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

    public GameObject Toggle_motion;
    public GameObject Toggle_bloom;
    public GameObject Toggle_auto;
    public GameObject Toggle_depth;
    // Start is called before the first frame update
    void Start()
    {
        Motionblur = Convert.ToBoolean(PlayerPrefs.GetInt("MotionBlur",1));
        Bloom = Convert.ToBoolean(PlayerPrefs.GetInt("Bloom", 1));
        AutoExposure = Convert.ToBoolean(PlayerPrefs.GetInt("AutoExposure", 1));
        DepthOfField = Convert.ToBoolean(PlayerPrefs.GetInt("DepthOfField", 1));

        print(Motionblur);
        print(Bloom);
        print(AutoExposure);
        print(DepthOfField);
        on = false;
        Toggle_motion.GetComponent<Toggle>().isOn = Motionblur;
        Toggle_bloom.GetComponent<Toggle>().isOn = Bloom;
        Toggle_auto.GetComponent<Toggle>().isOn = AutoExposure;
        Toggle_depth.GetComponent<Toggle>().isOn = DepthOfField;
        on = true;
    }

    public void GoBack()
    {

        PlayerPrefs.SetInt("MotionBlur", Convert.ToInt32(Motionblur));
        PlayerPrefs.SetInt("Bloom", Convert.ToInt32(Bloom));
        PlayerPrefs.SetInt("AutoExposure", Convert.ToInt32(AutoExposure));
        PlayerPrefs.SetInt("DepthOfField", Convert.ToInt32(DepthOfField));

        print(Motionblur);
        print(Bloom);
        print(AutoExposure);
        print(DepthOfField);
        this.gameObject.SetActive(false);
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
