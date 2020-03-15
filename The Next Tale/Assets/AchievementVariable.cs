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
        
        if(1 == PlayerPrefs.GetInt(AchievementName, 0))
        {
            DoneImage.SetActive(true);
        }
    }
}
