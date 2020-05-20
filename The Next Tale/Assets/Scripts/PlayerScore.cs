using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    //Set up a variable to store how many you've collected
    public int currentScore;
    public int gems;
    public int secrets;
    public int exp;

    private int startKeys = 0;
    public int currentKeys;
    public Text counter;
    public Text key;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentKeys = startKeys;
        currentKeys = startKeys;
        gems = 0;
        secrets = 0;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "MainHub")
        {
            key.text = "Experience: " + exp.ToString();
        }
        this.GetComponent<Saving>().Load();
    }



    private void Update()
    {

        counter.text = "Score: " + currentScore.ToString();
        key.text = "Keys: " + currentKeys.ToString();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "MainHub")
        {
            key.text = "Experience: " + exp.ToString();
        }
    }
}
