using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionPickUp : MonoBehaviour
{
    public string LevelName;
    public GameObject Item;
    GameObject player;
    
    public GameObject effect;
    public GameObject MissionEffect;
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.1f;
    public float frequency = 1f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        posOffset = transform.position;
        audioSource = GetComponent<AudioSource>();
        if (LevelName == "Level1")
        {
            if(Convert.ToBoolean(PlayerPrefs.GetInt("MLVL1", 0) == 1))
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                var Objektas = Instantiate(Item, transform.position, transform.rotation);
                Objektas.transform.parent = gameObject.transform;
                var efektas = Instantiate(MissionEffect, transform.position, transform.rotation);
                efektas.transform.parent = gameObject.transform;
            }
        }
        if (LevelName == "Level2")
        {
            if (Convert.ToBoolean(PlayerPrefs.GetInt("MLVL2", 0) == 1))
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                var Objektas = Instantiate(Item, transform.position, transform.rotation);
                Objektas.transform.parent = gameObject.transform;
                var efektas = Instantiate(MissionEffect, transform.position, transform.rotation);
                efektas.transform.parent = gameObject.transform;
            }
        }
        if (LevelName == "Level3")
        {
            if (Convert.ToBoolean(PlayerPrefs.GetInt("MLVL3", 0) == 1))
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                var Objektas = Instantiate(Item, transform.position, transform.rotation);
                Objektas.transform.parent = gameObject.transform;
                var efektas = Instantiate(MissionEffect, transform.position, transform.rotation);
                efektas.transform.parent = gameObject.transform;
            }
        }
        if (LevelName == "Level4")
        {
            if (Convert.ToBoolean(PlayerPrefs.GetInt("MLVL4", 0) == 1))
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                var Objektas = Instantiate(Item, transform.position, transform.rotation);
                Objektas.transform.parent = gameObject.transform;
                var efektas = Instantiate(MissionEffect, transform.position, transform.rotation);
                efektas.transform.parent = gameObject.transform;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, this.transform.position);
            Instantiate(effect, transform.position, transform.rotation);
            print("Veikia");
            gameObject.SetActive(false);
            player.GetComponent<LevelInventory>().MissionCounter++;
        }
    }
}
