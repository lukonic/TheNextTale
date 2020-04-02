using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedLimit : MonoBehaviour
{
    GameObject Player;
    public bool intrigger;
    public float maxSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == Player)
        {
            intrigger = true;
            Player.GetComponent<PlayerController>().tankas = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            intrigger = false;
            Player.GetComponent<PlayerController>().tankas = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (intrigger)
        {
            Player.transform.rotation = Quaternion.LookRotation(Player.GetComponent<Rigidbody>().velocity, Vector3.up);
            if (Player.GetComponent<Rigidbody>().velocity.magnitude > maxSpeed)
            {
                print("speed:" + Player.GetComponent<Rigidbody>().velocity.ToString());
                Player.GetComponent<Rigidbody>().velocity = Player.GetComponent<Rigidbody>().velocity.normalized * maxSpeed;
            }
        }
    }
}
