using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject AreYouSure;
    void Start()
    {
        AreYouSure = GameObject.Find("AreYouSure");
        AreYouSure.SetActive(false);
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
    public void doStartNewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainHub");
    }
    public void Cancel()
    {
        AreYouSure.SetActive(false);
    }
}
