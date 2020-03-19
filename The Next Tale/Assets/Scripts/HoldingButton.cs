using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingButton : MonoBehaviour
{
    GameObject player;
    GameObject box;
    public GameObject HookedTo;
    public Material[] material;
    Renderer rend;
    public bool Holding;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        box = GameObject.FindGameObjectWithTag("Box");
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    private void OnTriggerStay(Collider other)
    {

            HookedTo.GetComponent<Moving_Platform_Hold>().ON = true;
            rend.sharedMaterial = material[1];
            Holding = true;
        

    }
    private void OnTriggerExit(Collider other)
    {

            Holding = false;

    }

    private void FixedUpdate()
    {
        Holding = false;
        if (!Holding)
        {
            rend.sharedMaterial = material[0];
            HookedTo.GetComponent<Moving_Platform_Hold>().ON = false;
        }
    }
}
