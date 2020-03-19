using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAble : MonoBehaviour
{
    public GameObject item;
    public GameObject player;
    public GameObject tempParent;
    public GameObject Drop;
    public GameObject guide;
    bool carrying;
    public float range = 2;
    // Use this for initialization
    void Start()
    {
        item = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        tempParent = GameObject.FindGameObjectWithTag("Player");
        guide = GameObject.Find("Guide");
        item.GetComponent<Rigidbody>().useGravity = true;
        Drop = GameObject.FindGameObjectWithTag("Drop");
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
                Drop.SetActive(true);
                Drop.GetComponent<Drop>().Paimta = item;
                
            }
        }
        else if (carrying == true && player.GetComponent<PlayerController>().Carrying == true)
        {
            pickup();
            if (Input.GetKeyDown(KeyCode.E))
            {
                drop();
            }
        }
    }
    void pickup()
    {
        //player.GetComponent<Rigidbody>().Sleep();
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Collider>().enabled = false;
        item.GetComponent<Rigidbody>().freezeRotation = true;
        item.layer = 2;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;
    }
    public void drop()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Collider>().enabled = true;
        item.GetComponent<Rigidbody>().freezeRotation = false;
        item.GetComponent<Rigidbody>().Sleep();
        item.transform.parent = null;
        item.layer = 0;
        item.transform.position = guide.transform.position;
        carrying = false;
        player.GetComponent<PlayerController>().Carrying = false;
        player.GetComponent<BoxCollider>().enabled = false;
        Drop.GetComponent<Drop>().Paimta = null;
        Drop.SetActive(false);
        if (item.tag == "barrel")
        {
            item.GetComponent<VaseDestroy>().TimeToDie = true;
        }
        if (Input.GetButton("LeftShift"))
        {
            if (item.tag == "barrel")
            {
                item.GetComponent<VaseDestroy>().TimeToDie = true;
                item.GetComponent<VaseDestroy>().TimeToDieStrong = true;
                item.GetComponent<Rigidbody>().AddForce((player.GetComponent<PlayerController>().m_currentDirection + item.transform.forward * 20 + new Vector3(0, 2, 0)), ForceMode.Impulse);
            }
        }
    }
}