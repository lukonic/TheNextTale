using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementVariable : MonoBehaviour
{
    public string AchievementName;
    public bool Done;
    public GameObject DoneImage;
    // Start is called before the first frame update
    void Start()
    {
        DoneImage = GameObject.Find("Image_Done");
        DoneImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Done)
        {

        }
    }
}
