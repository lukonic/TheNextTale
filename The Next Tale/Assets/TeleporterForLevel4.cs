using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterForLevel4 : MonoBehaviour
{
    public int x;
    public int y;
    public int z;
    GameObject player;
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.position = new Vector3(x, y, z);
            Instantiate(effect, player.transform.position, player.transform.rotation);
        }
    }
    
}
