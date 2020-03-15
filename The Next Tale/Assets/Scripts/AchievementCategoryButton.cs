using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementCategoryButton : MonoBehaviour
{
    public GameObject achievementList;
    private bool clicked;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Click()
    {
        if (!clicked)
        {
            clicked = true;
            achievementList.SetActive(true);
        }
        else
        {
            clicked = false;
            achievementList.SetActive(false);
        }
    }
}
