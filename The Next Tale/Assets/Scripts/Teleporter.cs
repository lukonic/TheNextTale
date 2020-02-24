using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{
    public Text levelcompleted;
    public Text gem;
    public Text secret;
    public Text TimeTaken;
    private GameObject player;
    public GameObject effect;
    public int Gems;
    public int Secrets;


     float leveltimer;
     bool updateTimer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        updateTimer = true;
        leveltimer = 0.0f;
    }

    void Update()
    {
        if (updateTimer)
            leveltimer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            updateTimer = false;
            levelcompleted.text = "LEVEL COMPLETED";
            gem.text = "GEMS FOUND: " + player.GetComponent<PlayerScore>().gems.ToString() + "/" + Gems.ToString();
            secret.text = "SECRETS FOUND: " + player.GetComponent<PlayerScore>().secrets.ToString() + "/" + Secrets.ToString();
            TimeTaken.text = "TIME: " + leveltimer.ToString() ;
            Instantiate(effect, transform.position, transform.rotation);
        }
    }


}
