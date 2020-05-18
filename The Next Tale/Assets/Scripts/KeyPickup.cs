using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    GameObject player;
    PlayerScore playerScore;
    GameObject teleporter;
    public GameObject effect;
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.1f;
    public float frequency = 1f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    private AudioSource audioSource;

    // Use this for initialization

    // Start is called before the first frame update
    void Start()
    {
        teleporter = GameObject.Find("Teleporter");
        player = GameObject.FindGameObjectWithTag("Player");
        playerScore = player.GetComponent<PlayerScore>();
        posOffset = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, this.transform.position);
            Instantiate(effect, transform.position, transform.rotation);
            playerScore.currentKeys++;
            player.GetComponent<LevelInventory>().KeysLeft++;
            print("Veikia");
            gameObject.SetActive(false);
            if(teleporter.GetComponent<Teleporter>().leveltimer < 10)
            {
                player.GetComponent<LevelInventory>().KeyInTime = 1;
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