using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Saving : MonoBehaviour
{
    GameObject player;
    GameObject teleporter;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        teleporter = GameObject.Find("Teleporter");

    }

    public void Save()
    {
        //hp
        PlayerPrefs.SetInt("CurrentHealth", player.GetComponent<PlayerHealth>().currentHealth);

        //gems
        PlayerPrefs.SetInt("Gems", player.GetComponent<PlayerScore>().gems + PlayerPrefs.GetInt("Gems", 0));

        //secrets
        for (int i = 0; i < player.GetComponent<LevelInventory>().counter; i++)
        {
            PlayerPrefs.SetInt(player.GetComponent<LevelInventory>().SecretArray[i], 1);
        }
        //secrets amount
        PlayerPrefs.SetInt(teleporter.GetComponent<Teleporter>().LevelName, PlayerPrefs.GetInt(teleporter.GetComponent<Teleporter>().LevelName, 0) + player.GetComponent<LevelInventory>().counter);
    }
    public void Load()
    {
        //hp
        player.GetComponent<PlayerHealth>().currentHealth = PlayerPrefs.GetInt("CurrentHealth", 5);

        //gems
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "MainHub")
        {
            player.GetComponent<PlayerScore>().currentScore = PlayerPrefs.GetInt("Gems", 0);
        }


    }
    public void Delete()
    {
        PlayerPrefs.DeleteAll();
    }
}
