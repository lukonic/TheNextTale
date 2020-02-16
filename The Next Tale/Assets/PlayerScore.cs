using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    //Set up a variable to store how many you've collected
    private int startScore = 0;
    public int currentScore;
    public static int score; //Needed for NPC_dialogue
    public Text counter;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentScore = startScore;
        counter.text = "Score: 0";
    }



    private void Update()
    {
        counter.text = "Keys: " + currentScore.ToString();
    }
}
