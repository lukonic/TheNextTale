using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    GameObject UI;
    Button level2;
    GameObject player;
    GameObject camera;
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    // Start is called before the first frame update
    void Start()
    { 
        level2 = GameObject.Find("Level2_Select").GetComponent<Button>();
        player = GameObject.FindGameObjectWithTag("Player");
        UI = GameObject.FindGameObjectWithTag("LevelSelectUI");
        camera = GameObject.FindGameObjectWithTag("CameraFolder");
        UI.SetActive(false);
    }

    public void TurnOff()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.GetComponent<PlayerController>().ON = true;
        camera.GetComponent<CameraFollow>().ON = true;
        UI.SetActive(false);
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.GetComponent<Saving>().Save();
            player.GetComponent<PlayerController>().ON = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            camera.GetComponent<CameraFollow>().ON = false;
            UI.SetActive(true);
            player.GetComponent<Saving>().Save();
            //levelių atrakinimas
            if (player.GetComponent<PlayerScore>().exp < 20)
            {
                level2.interactable = false;
            }
        }
    }
}
