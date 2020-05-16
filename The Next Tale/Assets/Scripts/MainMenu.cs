using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject AreYouSure;
    GameObject Options;

    bool Motionblur;
    bool Bloom;
    bool AutoExposure;
    bool DepthOfField;
    void Start()
    {
        AreYouSure = GameObject.Find("AreYouSure");
        AreYouSure.SetActive(false);
        Options = GameObject.Find("Options");
        Options.SetActive(false);
    }
    public void doExitGame()
    {
        Application.Quit();
    }

    public void doContinue()
    {
        SceneManager.LoadScene("MainHub");
    }

    public void doAreYouSure()
    {
       
        AreYouSure.SetActive(true);
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
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("MotionBlur", Convert.ToInt32(Motionblur));
        PlayerPrefs.SetInt("Bloom", Convert.ToInt32(Bloom));
        PlayerPrefs.SetInt("AutoExposure", Convert.ToInt32(AutoExposure));
        PlayerPrefs.SetInt("DepthOfField", Convert.ToInt32(DepthOfField));
        SceneManager.LoadScene("MainHub");
    }
    public void doMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Cancel()
    {
        AreYouSure.SetActive(false);
    }
    public void doOptionsCancel()
    {
        Options.SetActive(false);
    }
}
