using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAble : MonoBehaviour
{
    public GameObject item;
    public GameObject player;
    public GameObject tempParent;
    public Transform guide;
    bool carrying;
    public float range = 2;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        item.GetComponent<Rigidbody>().useGravity = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (carrying == false && player.GetComponent<PlayerController>().Carrying == false)
        {
            if (Input.GetKeyDown(KeyCode.E) && (guide.transform.position - transform.position).sqrMagnitude < range * range)
            {
                pickup();
                carrying = true;
                player.GetComponent<PlayerController>().Carrying = true;
                player.GetComponent<BoxCollider>().enabled = true;
            }
        }
        else if (carrying == true && player.GetComponent<PlayerController>().Carrying == true)
        {
            pickup();
            if (Input.GetKeyDown(KeyCode.E))
            {
                drop();
                carrying = false;
                player.GetComponent<PlayerController>().Carrying = false;
                player.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
    void pickup()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Collider>().enabled = false;
        item.GetComponent<Rigidbody>().freezeRotation = true;
        item.layer = 2;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;
    }
    void drop()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Collider>().enabled = true;
        item.GetComponent<Rigidbody>().freezeRotation = false;
        item.GetComponent<Rigidbody>().Sleep();
        item.transform.parent = null;
        item.layer = 0;
        item.transform.position = guide.transform.position;
    }
}