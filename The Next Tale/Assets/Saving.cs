using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Saving : MonoBehaviour
{
    GameObject player;

    public bool L1S1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    public void Save()
    {
        PlayerPrefs.SetInt("CurrentHealth", player.GetComponent<PlayerHealth>().currentHealth);
    }
    public void Load()
    {
        player.GetComponent<PlayerHealth>().currentHealth = PlayerPrefs.GetInt("CurrentHealth", 5);
    }
    public void Delete()
    {
        PlayerPrefs.DeleteAll();
    }
}
