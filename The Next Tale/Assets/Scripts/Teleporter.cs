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

    public string LevelName;

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
            secret.text = "SECRETS FOUND: " + player.GetComponent<PlayerScore>().secrets.ToString() + "/" + (Secrets - PlayerPrefs.GetInt(LevelName, 0)).ToString();
            TimeTaken.text = "TIME: " + leveltimer.ToString() ;
            Instantiate(effect, transform.position, transform.rotation);

            player.GetComponent<Saving>().Save();
            player.GetComponent<GameOverManager>().cameraMovement.enabled = false;
            player.SetActive(false);
            /*
                // Stop the camera movement
                player.GetComponent<GameOverManager>().cameraMovement.enabled = false;
                // Turn on the cursor back after dying
               

                // Show the endgame buttons
                player.GetComponent<Rigidbody>().isKinematic = true;
                player.GetComponent<BoxCollider>().enabled = false;
                CapsuleCollider[] myColliders = gameObject.GetComponents<CapsuleCollider>();
                foreach (CapsuleCollider bc in myColliders) bc.enabled = false;
                player.GetComponent<GameOverManager>().mesh.SetActive(false);
                player.GetComponent<PlayerController>().enabled = false;
                player.GetComponent<Animator>().enabled = false;
                */
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            

        }
    }


}
