using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSecret : MonoBehaviour
{
    GameObject player;
    PlayerScore playerScore;
    public GameObject effect;
    private bool pickuable;

    // Use this for initialization

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScore = player.GetComponent<PlayerScore>();
        pickuable = false;
        StartCoroutine(ExecuteAfterTime2(0.3f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (pickuable == true)
            {
                Instantiate(effect, transform.position, transform.rotation);
                playerScore.currentScore += 10;
                print("Veikia");
                gameObject.SetActive(false);
                playerScore.secrets++;
                player.GetComponent<LevelInventory>().secrets++;
            }

        }
    }
    IEnumerator ExecuteAfterTime2(float time)
    {
        yield return new WaitForSeconds(time);
        pickuable = true;
    }
}
