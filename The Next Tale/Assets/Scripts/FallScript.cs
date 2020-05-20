using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    GameObject player;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (player.GetComponent<PlayerHealth>().currentHealth > 1)
            {
                player.GetComponent<PlayerController>().TeleportToLastSpawn();
            }
                 player.GetComponent<PlayerHealth>().TakeDamage(1);
            player.GetComponent<PlayerHealth>().invincibility = true;
            AudioSource.PlayClipAtPoint((AudioClip)Resources.Load("scream"), this.transform.position);
            StartCoroutine(ExecuteAfterTime(2));
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        player.GetComponent<PlayerHealth>().invincibility = false;
    }
}
