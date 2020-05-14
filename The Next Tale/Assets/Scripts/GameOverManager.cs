using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
     GameObject player;
     GameObject ragdollas;
    GameObject Canvas;
    public GameObject mesh;
    public CameraFollow cameraMovement;
    bool dead;


    private void Start()
    {
        // Hide the cursor when playing
        Cursor.visible = false;
        dead = false;
        // This stops the camera movement after dying
        cameraMovement = GameObject.FindGameObjectWithTag("CameraFolder").GetComponent<CameraFollow>();
        GameObject.FindGameObjectWithTag("BaseMesh");

        player = GameObject.FindGameObjectWithTag("Player");
        ragdollas = GameObject.FindGameObjectWithTag("PlayerRagdoll");
        ragdollas.SetActive(false);
        Canvas = GameObject.FindGameObjectWithTag("DeadCanvas");
        Canvas.SetActive(false);
    }
    private void Update()
    {
        if (player.GetComponent<PlayerHealth>().currentHealth <= 0 && dead == false)
        {
            // Stop the camera movement
            cameraMovement.enabled = false;
                ragdollas.SetActive(true);
            // Turn on the cursor back after dying
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Show the endgame buttons
            player.GetComponent<Rigidbody>().isKinematic = true;
            player.GetComponent<BoxCollider>().enabled = false;
            CapsuleCollider[] myColliders = gameObject.GetComponents<CapsuleCollider>();
            foreach (CapsuleCollider bc in myColliders) bc.enabled = false;
            mesh.SetActive(false);
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
            dead = true;
            Canvas.SetActive(true);
        }
    }
}
