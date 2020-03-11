using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    public GameObject spawn;
    public GameObject effect;
    Animator m_Animator;
    private bool open;
    public string WhatBox;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        m_Animator = GetComponent<Animator>();
        open = false;
        if (PlayerPrefs.HasKey(WhatBox))
        {
            m_Animator.SetBool("Atidaryta", true);
            open = true;
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && open == false)
        {
            if (!PlayerPrefs.HasKey(WhatBox))
            {
                player.GetComponent<LevelInventory>().SecretArray[player.GetComponent<LevelInventory>().counter] = WhatBox;
                player.GetComponent<LevelInventory>().counter++;
                Instantiate(spawn, transform.position + new Vector3(0, 0.5f), transform.rotation);
                Instantiate(effect, transform.position + new Vector3(0, 1f), transform.rotation);
                m_Animator.SetBool("Atidaryta", true);
                open = true;
            }
        }
    }
}
