using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject AreYouSure;
    GameObject Options;
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
        PlayerPrefs.DeleteAll();
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
