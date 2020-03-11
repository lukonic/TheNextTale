using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    GameObject UI;
    GameObject player;
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        UI = GameObject.FindGameObjectWithTag("LevelSelectUI");
        UI.SetActive(false);
    }

    public void TurnOff()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UI.SetActive(false);
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            UI.SetActive(true);
        }
    }
}
