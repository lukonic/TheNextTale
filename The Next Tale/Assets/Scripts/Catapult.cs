﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    GameObject player;
    public bool IsON;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        IsON = false;
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (IsON)
        { 
            GetComponent<Rigidbody>().mass = 75;
            AudioSource.PlayClipAtPoint(audioSource.clip, this.transform.position);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, -15);
        StartCoroutine(stoparm());
            IsON = false;
    }
    }

    IEnumerator stoparm()
    {
        yield return new WaitForSeconds(.3f);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 3);
        GetComponent<Rigidbody>().mass = 5;
    }
}
