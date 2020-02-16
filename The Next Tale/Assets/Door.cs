using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    GameObject player;
    GameObject vyriai;
    PlayerScore playerScore;
    public GameObject effect;
    private bool atidarom;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        vyriai = GameObject.FindGameObjectWithTag("Vyriai");
        playerScore = player.GetComponent<PlayerScore>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (playerScore.currentKeys > 0)
            {
                playerScore.currentKeys--;
                atidarom = true;
                StartCoroutine(ExecuteAfterTime(2.1f));
                
            }

        }
    }
    // Update is called once per frame
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<BoxCollider>().material.staticFriction = 1;
        this.GetComponent<BoxCollider>().material.dynamicFriction = 1;
        Instantiate(effect, vyriai.transform.position, new Quaternion(90, 0, 0, 0));
        atidarom = false;
    }
    void Update()
    {
        if(atidarom)
        {
            vyriai.transform.Rotate(- new Vector3(0f, Time.deltaTime * 30, 0f), Space.World);
        }
    }
}
