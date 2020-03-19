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
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName != "MainHub")
        {
            print("AGEWJGIWEWG");
            PlayerPrefs.SetInt(teleporter.GetComponent<Teleporter>().LevelName, PlayerPrefs.GetInt(teleporter.GetComponent<Teleporter>().LevelName, 0) + player.GetComponent<LevelInventory>().counter);
        }
    }
    public void SaveLevel1()
    {
        ArDuotExp("Level1_Complete", 5);
        PlayerPrefs.SetInt("Level1_Complete", 1);
        if (player.GetComponent<LevelInventory>().TorchesLit == 7)
        {
            ArDuotExp("Level1_Torches", 5);
            PlayerPrefs.SetInt("Level1_Torches", 1);
        }
        if (player.GetComponent<LevelInventory>().BarrelWithoutJump > 0)
        {
            ArDuotExp("Level1_Barrel_Jump", 5);
            PlayerPrefs.SetInt("Level1_Barrel_Jump", 1);
        }
        if (player.GetComponent<LevelInventory>().Gems == 7)
        {
            ArDuotExp("Level1_Gems", 5);
            PlayerPrefs.SetInt("Level1_Gems", 1);
        }
        if (PlayerPrefs.GetInt(teleporter.GetComponent<Teleporter>().LevelName, 0) == 1)
        {
            ArDuotExp("Level1_Secret", 5);
            PlayerPrefs.SetInt("Level1_Secret", 1);
        }
        if (player.GetComponent<LevelInventory>().jumps < 5)
        {
            ArDuotExp("Level1_Jumping", 5);
            PlayerPrefs.SetInt("Level1_Jumping", 1);
        }
        if (player.GetComponent<LevelInventory>().KeyInTime == 1)
        {
            ArDuotExp("Level1_Race_Key", 5);
            PlayerPrefs.SetInt("Level1_Race_Key", 1);
        }
        if (player.GetComponent<LevelInventory>().NoKey == 1)
        {
            ArDuotExp("Level1_NoKey", 5);
            PlayerPrefs.SetInt("Level1_NoKey", 1);
        }

        print(player.GetComponent<LevelInventory>().Level1Time);
        if (player.GetComponent<LevelInventory>().Level1Time < 22)
        {
            ArDuotExp("Level1_Race", 5);
            PlayerPrefs.SetInt("Level1_Race", 1);
        }

    }
    public void ArDuotExp(string achievement, int kiek)
    {
        if (PlayerPrefs.GetInt(achievement, 0) == 0)
        {
            print("Duodu exp už:" + achievement + kiek);
            PlayerPrefs.SetInt("Exp", PlayerPrefs.GetInt("Exp", 0) + kiek);
        }
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
            player.GetComponent<PlayerScore>().exp = PlayerPrefs.GetInt("Exp", 0);
        }


    }
    public void Delete()
    {
        PlayerPrefs.DeleteAll();
    }
}
