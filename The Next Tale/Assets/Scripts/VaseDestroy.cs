using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    public GameObject effect;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Instantiate(effect, transform.position, transform.rotation);
            print("Veikia");
            gameObject.SetActive(false);

        }
    }
}
