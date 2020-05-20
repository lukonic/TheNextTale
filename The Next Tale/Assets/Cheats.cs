using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
    GameObject player;
    GameObject teleporter;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        teleporter = GameObject.Find("Teleporter");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "MainHub")
            {
                PlayerPrefs.SetInt("Exp", PlayerPrefs.GetInt("Exp", 0) + 5);
                player.GetComponent<PlayerScore>().exp = PlayerPrefs.GetInt("Exp", 0);
            }
            else
            {
                player.GetComponent<LevelInventory>().MissionCounter = 10;
                player.transform.position = teleporter.transform.position;
            }
        }
    }
}
