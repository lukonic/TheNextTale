using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    GameObject player;
    GameObject vyriai;
    PlayerScore playerScore;
    public GameObject effect;
    private bool atidarom = false;
    Animator m_Animator;
    private bool islausta = false;
    AudioClip clipas;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        vyriai = GameObject.FindGameObjectWithTag("Vyriai");
        playerScore = player.GetComponent<PlayerScore>();
        m_Animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && islausta == false)
        {
            if (playerScore.currentKeys > 0)
            {
                playerScore.currentKeys--;
                atidarom = true;
                islausta = true;
                clipas = GetComponent<AudioSource>().clip;
                AudioSource.PlayClipAtPoint(clipas, transform.position);
                StartCoroutine(ExecuteAfterTime(2.0f));
            }
            else
            {
                if (!atidarom)
                {
                    m_Animator.SetBool("neturi", true);
                    StartCoroutine(ExecuteAfterTime2(1f));
                }
            }

        }
        if(other.GetComponent<VaseDestroy>().TimeToDieStrong && other.tag == "barrel")
        {
            print("bam");
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<BoxCollider>().material.staticFriction = 1;
            this.GetComponent<BoxCollider>().material.dynamicFriction = 1;
            this.GetComponent<Animator>().enabled = false;
            Instantiate(effect, vyriai.transform.position, new Quaternion(90, 0, 0, 0));
            player.GetComponent<LevelInventory>().NoKey = 1;
            islausta = true;
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
        this.GetComponent<Animator>().enabled = false;
        Instantiate(effect, vyriai.transform.position, new Quaternion(90, 0, 0, 0));
        atidarom = false;
    }
    IEnumerator ExecuteAfterTime2(float time)
    {
        yield return new WaitForSeconds(time);
        m_Animator.SetBool("neturi", false);
    }
    void Update()
    {
        if(atidarom)
        {
            vyriai.transform.Rotate(- new Vector3(0f, Time.deltaTime * 30, 0f), Space.World);
        }
    }
}
