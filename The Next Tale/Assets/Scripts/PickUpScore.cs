using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScore : MonoBehaviour
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
        StartCoroutine(ExecuteAfterTime2(0.5f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (pickuable == true)
            {
                Instantiate(effect, transform.position, transform.rotation);
                playerScore.currentScore++;
                print("Veikia");
                gameObject.SetActive(false);
                playerScore.gems++;
            }

        }
    }
    IEnumerator ExecuteAfterTime2(float time)
    {
        yield return new WaitForSeconds(time);
        pickuable = true;
    }
}
