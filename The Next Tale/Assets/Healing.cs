using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    GameObject player;
    GameObject camera;
    public GameObject effect;
    public GameObject canvas;
    public bool InTrigger;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.FindGameObjectWithTag("HealingCanvas");
        camera = GameObject.FindGameObjectWithTag("CameraFolder");
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        canvas.transform.GetChild(2).gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            canvas.SetActive(true);
            canvas.SetActive(false);
            canvas.SetActive(true);
            CheckHP();
            player.GetComponent<PlayerController>().ON = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            camera.GetComponent<CameraFollow>().ON = false;
            InTrigger = true;
        }
    }
    public void CheckHP()
    {
        if (player.GetComponent<PlayerHealth>().currentHealth == player.GetComponent<PlayerHealth>().numberOfHearts)
        {
            canvas.transform.GetChild(0).gameObject.SetActive(true);
            canvas.transform.GetChild(1).gameObject.SetActive(false);
            canvas.transform.GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            canvas.transform.GetChild(0).gameObject.SetActive(false);
            canvas.transform.GetChild(1).gameObject.SetActive(true);
            canvas.transform.GetChild(2).gameObject.SetActive(false);
        }
    }
    public void HealUp()
    {
        if (player.GetComponent<PlayerScore>().currentScore > 2)
        {
            player.GetComponent<PlayerScore>().currentScore = player.GetComponent<PlayerScore>().currentScore - 3;
            player.GetComponent<PlayerHealth>().currentHealth++;
            Instantiate(effect, player.transform.position + new Vector3(0, 1), new Quaternion(0, 0, 0, 0));
            CheckHP();
        }
        else
        {
            canvas.transform.GetChild(0).gameObject.SetActive(false);
            canvas.transform.GetChild(1).gameObject.SetActive(false);
            canvas.transform.GetChild(2).gameObject.SetActive(true);
        }
    }
    public void TurnOff()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.GetComponent<PlayerController>().ON = true;
        camera.GetComponent<CameraFollow>().ON = true;
        canvas.SetActive(false);
        InTrigger = false;
    }
    void Update()
    {
        if (InTrigger)
        {
            Vector3 targetDir = player.transform.position - transform.position;
            targetDir.y = 0;
            float step = 2 * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            Debug.DrawRay(transform.position, newDir, Color.red);

            transform.rotation = Quaternion.LookRotation(newDir);

            Vector3 targetDir2 = this.transform.position - player.transform.position;
            targetDir2.y = 0;
            float step2 = 2 * Time.deltaTime;

            Vector3 newDir2 = Vector3.RotateTowards(player.transform.forward, targetDir2, step2, 0.0F);
            Debug.DrawRay(player.transform.position, newDir2, Color.red);
        }
    }
}
