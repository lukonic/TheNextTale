using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    bool ijungtas;
    public GameObject EscapeCanvas;
    // Start is called before the first frame update
    void Start()
    {
        EscapeCanvas = GameObject.Find("EscapeCanvas");
        ijungtas = false;
        EscapeCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ijungtas == false)
        {
            print("escape");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            ijungtas = true;
            
            EscapeCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        
        else if (Input.GetKeyDown(KeyCode.Escape) && ijungtas == true)
        {
            print("rip");
            ijungtas = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            EscapeCanvas.SetActive(false);
            Time.timeScale = 1;
        }
        
    }
    public void resume()
    {
        ijungtas = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        EscapeCanvas.SetActive(false);
        Time.timeScale = 1;
    }
}
