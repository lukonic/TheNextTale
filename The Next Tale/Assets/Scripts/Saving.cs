using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Saving : MonoBehaviour
{
    GameObject player;
    GameObject teleporter;
    bool Motionblur;
    bool Bloom;
    bool AutoExposure;
    bool DepthOfField;
    float volume;

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

       
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName != "MainHub")
        {
            //secrets
            for (int i = 0; i < player.GetComponent<LevelInventory>().counter; i++)
            {
                PlayerPrefs.SetInt(player.GetComponent<LevelInventory>().SecretArray[i], 1);
            }
            //gems
            PlayerPrefs.SetInt("Gems", player.GetComponent<PlayerScore>().gems + PlayerPrefs.GetInt("Gems", 0));
            print("AGEWJGIWEWG");
            //secrets amount
            PlayerPrefs.SetInt(teleporter.GetComponent<Teleporter>().LevelName, PlayerPrefs.GetInt(teleporter.GetComponent<Teleporter>().LevelName, 0) + player.GetComponent<LevelInventory>().counter);
        }
        else
        {

            //gems
            PlayerPrefs.SetInt("Gems", player.GetComponent<PlayerScore>().currentScore);
        }
    }
    public void SaveLevel1()
    {
        if((PlayerPrefs.GetInt("MLVL1", 0)) == 0)
        {
            if(player.GetComponent<LevelInventory>().MissionCounter >= 5)
            {
                ArDuotExp("MLVL1", 5);
                PlayerPrefs.SetInt("MLVL1", 1);
                
            }
        }
        ArDuotExp("Level1_Complete", 5);
        PlayerPrefs.SetInt("Level1_Complete", 1);
        
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
    public void SaveLevel2()
    {
        if ((PlayerPrefs.GetInt("MLVL2", 0)) == 0)
        {
            if (player.GetComponent<LevelInventory>().MissionCounter >= 10)
            {
                ArDuotExp("MLVL2", 5);
                PlayerPrefs.SetInt("MLVL2", 1);

            }
        }
        ArDuotExp("Level2_Complete", 5);
        PlayerPrefs.SetInt("Level2_Complete", 1);

        PlayerPrefs.SetInt("Level2_Complete", 1);
        if (player.GetComponent<LevelInventory>().DMGtaken == 0)
        {
            ArDuotExp("Level2_NoDMG", 5);
            PlayerPrefs.SetInt("Level2_NoDMG", 1);
        }
        if (player.GetComponent<LevelInventory>().TorchesLit == 15)
        {
            ArDuotExp("Level2_Torches", 5);
            PlayerPrefs.SetInt("Level2_Torches", 1);
        }
        if (player.GetComponent<LevelInventory>().Gems == 21)
        {
            ArDuotExp("Level2_Gems", 5);
            PlayerPrefs.SetInt("Level2_Gems", 1);
        }
        if (player.GetComponent<LevelInventory>().AllSecrets == true)
        {
            ArDuotExp("Level2_Secret", 5);
            PlayerPrefs.SetInt("Level2_Secret", 1);
        }
        if (player.GetComponent<LevelInventory>().KeysLeft >= 1)
        {
            ArDuotExp("Level2_2Keys", 5);
            PlayerPrefs.SetInt("Level2_2Keys", 1);
        }
        if (player.GetComponent<LevelInventory>().Level1Time < 85)
        {
            ArDuotExp("Level2_Race", 5);
            PlayerPrefs.SetInt("Level2_Race", 1);
        }

    }
    public void SaveLevel3()
    {
        if ((PlayerPrefs.GetInt("MLVL3", 0)) == 0)
        {
            if (player.GetComponent<LevelInventory>().MissionCounter >= 1)
            {
                ArDuotExp("MLVL3", 5);
                PlayerPrefs.SetInt("MLVL3", 1);

            }
        }
        ArDuotExp("Level3_Complete", 5);
        PlayerPrefs.SetInt("Level3_Complete", 1);

        PlayerPrefs.SetInt("Level3_Complete", 1);
        if (player.GetComponent<LevelInventory>().DMGtaken == 0)
        {
            ArDuotExp("Level3_NoDMG", 5);
            PlayerPrefs.SetInt("Level3_NoDMG", 1);
        }
        if (player.GetComponent<LevelInventory>().TorchesLit == 3)
        {
            ArDuotExp("Level3_Torches", 5);
            PlayerPrefs.SetInt("Level3_Torches", 1);
        }
        if (player.GetComponent<LevelInventory>().Gems == 19)
        {
            ArDuotExp("Level3_Gems", 5);
            PlayerPrefs.SetInt("Level3_Gems", 1);
        }
        if (player.GetComponent<LevelInventory>().AllSecrets == true)
        {
            ArDuotExp("Level3_Secret", 5);
            PlayerPrefs.SetInt("Level3_Secret", 1);
        }
        if (player.GetComponent<LevelInventory>().Level1Time < 110)
        {
            ArDuotExp("Level3_Race", 5);
            PlayerPrefs.SetInt("Level3_Race", 1);
        }

    }
    public void SaveLevel4()
    {
        if ((PlayerPrefs.GetInt("MLVL4", 0)) == 0)
        {
            if (player.GetComponent<LevelInventory>().MissionCounter >= 10)
            {
                ArDuotExp("MLVL4", 5);
                PlayerPrefs.SetInt("MLVL4", 1);

            }
        }
        ArDuotExp("Level4_Complete", 5);
        PlayerPrefs.SetInt("Level4_Complete", 1);

        PlayerPrefs.SetInt("Level4_Complete", 1);
        if (player.GetComponent<LevelInventory>().DMGtaken == 0)
        {
            ArDuotExp("Level4_NoDMG", 5);
            PlayerPrefs.SetInt("Level4_NoDMG", 1);
        }
        if (player.GetComponent<LevelInventory>().TorchesLit == 10)
        {
            ArDuotExp("Level4_Torches", 5);
            PlayerPrefs.SetInt("Level4_Torches", 1);
        }
        if (player.GetComponent<LevelInventory>().Gems == 14)
        {
            ArDuotExp("Level4_Gems", 5);
            PlayerPrefs.SetInt("Level4_Gems", 1);
        }
        if (player.GetComponent<LevelInventory>().AllSecrets == true)
        {
            ArDuotExp("Level4_Secret", 5);
            PlayerPrefs.SetInt("Level4_Secret", 1);
        }
        if (player.GetComponent<LevelInventory>().Level1Time < 150)
        {
            ArDuotExp("Level4_Race", 5);
            PlayerPrefs.SetInt("Level4_Race", 1);
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
    }
}
