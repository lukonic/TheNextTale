using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    GameObject UI;
    Button level2;
    Button level3;
    GameObject player;
    GameObject camera;
    GameObject RealCanvas;
    bool on;
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    // Start is called before the first frame update
    void Start()
    {
        RealCanvas = GameObject.Find("Canvas");
        level2 = GameObject.Find("Level2_Select").GetComponent<Button>();
        level3 = GameObject.Find("Level3_Select").GetComponent<Button>();
        player = GameObject.FindGameObjectWithTag("Player");
        UI = GameObject.FindGameObjectWithTag("LevelSelectUI");
        camera = GameObject.FindGameObjectWithTag("CameraFolder");
        UI.SetActive(false);
        RealCanvas.GetComponent<EscapeMenu>().ijungtasLevelSelect = false;
        on = false;
    }

    public void TurnOff()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.GetComponent<PlayerController>().ON = true;
        camera.GetComponent<CameraFollow>().ON = true;
        UI.SetActive(false);
        RealCanvas.GetComponent<EscapeMenu>().ijungtasLevelSelect = false;
        on = false;
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
            on = true;
            RealCanvas.GetComponent<EscapeMenu>().ijungtasLevelSelect = true;
            player.GetComponent<Saving>().Save();
            //levelių atrakinimas
            if (player.GetComponent<PlayerScore>().exp < 20)
            {
                //level2.interactable = false;
            }
            if (player.GetComponent<PlayerScore>().exp < 40)
            {
                //level3.interactable = false;
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && on)
        {
            TurnOff();
        }
    }
}
