using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLightUp : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    private ParticleSystem ps;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            print("Veikia");
            transform.GetChild(0).gameObject.SetActive(true);
            ps = gameObject.GetComponent<ParticleSystem>();
            var emission = ps.emission;
            emission.enabled = true;
        }
    }
}
