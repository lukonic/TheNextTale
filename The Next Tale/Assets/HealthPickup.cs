using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    GameObject player;
    public GameObject effect;
    public float degreesPerSecond;
    public float amplitude;
    public float frequency;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        posOffset = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (player.GetComponent<PlayerHealth>().currentHealth < player.GetComponent<PlayerHealth>().numberOfHearts)
            {
                player.GetComponent<PlayerHealth>().currentHealth++;
                Instantiate(effect, transform.position, transform.rotation);
                print("Veikia");
                gameObject.SetActive(false);
            }
        }
    }
    void Update()
    {
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down with a Sin()
        tempPos = posOffset;
       tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
       transform.position = tempPos;


    }
}