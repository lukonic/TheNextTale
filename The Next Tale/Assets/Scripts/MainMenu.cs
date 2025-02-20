﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject AreYouSure;
    public GameObject Options;
    public GameObject EscapeCanvas;
    public GameObject Controls;
    bool Motionblur;
    bool Bloom;
    bool AutoExposure;
    bool DepthOfField;
    float volume;

    void Start()
    {
        if(Options != null)
        Options.SetActive(false);
        if(EscapeCanvas != null)
        EscapeCanvas.SetActive(false);
        if (AreYouSure != null)
            AreYouSure.SetActive(false);
        if (Controls != null)
            Controls.SetActive(false);

    }
    public void doExitGame()
    {
        Application.Quit();
    }

    public void doContinue()
    {
        //SceneManager.LoadScene("MainHub");
    }

    public void doAreYouSure()
    {
       
        AreYouSure.SetActive(true);
    }
    public void doControls()
    {

        Controls.SetActive(true);
    }
    public void doOptions()
    {
        Options.SetActive(true);
    }
    public void doStartNewGame()
    {
        Motionblur = Convert.ToBoolean(PlayerPrefs.GetInt("MotionBlur", 1));
        Bloom = Convert.ToBoolean(PlayerPrefs.GetInt("Bloom", 1));
        AutoExposure = Convert.ToBoolean(PlayerPrefs.GetInt("AutoExposure", 1));
        DepthOfField = Convert.ToBoolean(PlayerPrefs.GetInt("DepthOfField", 1));
        volume = PlayerPrefs.GetFloat("Volume", 1);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("MotionBlur", Convert.ToInt32(Motionblur));
        PlayerPrefs.SetInt("Bloom", Convert.ToInt32(Bloom));
        PlayerPrefs.SetInt("AutoExposure", Convert.ToInt32(AutoExposure));
        PlayerPrefs.SetInt("DepthOfField", Convert.ToInt32(DepthOfField));
        PlayerPrefs.SetFloat("Volume", volume);
        //SceneManager.LoadScene("MainHub");
    }
    public void doMainMenu()
    {
        //SceneManager.LoadScene("MainMenu");
    }
    public void Cancel()
    {
        AreYouSure.SetActive(false);
    }
    public void doOptionsCancel()
    {
        Options.SetActive(false);
    }
    public void print()
    {
        print("resume");
    }
}
