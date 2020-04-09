using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    GameObject player;
    GameObject ragdollas;
    public GameObject mesh;
    public CameraFollow cameraMovement;
    GameObject rag;
    public GameObject blood;
    GameObject kraujas;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraMovement = GameObject.FindGameObjectWithTag("CameraFolder").GetComponent<CameraFollow>();
        mesh = GameObject.FindGameObjectWithTag("BaseMesh");
        ragdollas = GameObject.FindGameObjectWithTag("PlayerRagdoll");
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.other.gameObject == player && player.GetComponent<PlayerHealth>().invincibility != true)
        {
            player.GetComponent<PlayerHealth>().currentHealth = player.GetComponent<PlayerHealth>().currentHealth - 1;
            if (player.GetComponent<PlayerHealth>().currentHealth != 0)
            {
                // Stop the camera movement
                player.GetComponent<PlayerHealth>().invincibility = true;
                cameraMovement.enabled = false;
                rag = Instantiate(ragdollas, player.transform.position, player.transform.rotation ) ;
                rag.SetActive(true);
                kraujas = Instantiate(blood, rag.transform.position+ new Vector3(0,1,0), rag.transform.rotation);
                kraujas.transform.parent = rag.transform;
                // Turn on the cursor back after dying

                // Show the endgame buttons
                player.GetComponent<Rigidbody>().isKinematic = true;
                player.GetComponent<BoxCollider>().enabled = false;
                CapsuleCollider[] myColliders = gameObject.GetComponents<CapsuleCollider>();
                foreach (CapsuleCollider bc in myColliders) bc.enabled = false;
                mesh.SetActive(false);
                player.GetComponent<PlayerController>().enabled = false;
                player.GetComponent<Animator>().enabled = false;
                StartCoroutine(ExecuteAfterTime(2));
            }
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        player.GetComponent<PlayerController>().TeleportToLastSpawn();
        cameraMovement.enabled = true;
        ragdollas.transform.position = player.transform.position;
        rag.SetActive(false);
        // Turn on the cursor back after dying

        // Show the endgame buttons
        player.GetComponent<Rigidbody>().isKinematic = false;
        CapsuleCollider[] myColliders = gameObject.GetComponents<CapsuleCollider>();
        foreach (CapsuleCollider bc in myColliders) bc.enabled = true;
        mesh.SetActive(true);
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<PlayerHealth>().invincibility = false;
    }
}
