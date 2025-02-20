﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLightUp : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    private ParticleSystem ps;
    private bool lit;
    AudioClip clipas;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lit = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (lit == false)
            {
                print("Veikia");
                transform.GetChild(0).gameObject.SetActive(true);
                ps = gameObject.GetComponent<ParticleSystem>();
                var emission = ps.emission;
                emission.enabled = true;
                player.GetComponent<PlayerController>().GetLastSpawn();
                player.GetComponent<LevelInventory>().TorchesLit++;
                lit = true;
                clipas = GetComponent<AudioSource>().clip;
                AudioSource.PlayClipAtPoint(clipas, transform.position);
            }
        }
    }
}
