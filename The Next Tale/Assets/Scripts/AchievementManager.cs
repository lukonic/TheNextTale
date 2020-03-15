using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    GameObject camera;
    public GameObject achievementPrefab;
    public Sprite[] Sprites;
    public GameObject canvas;
    private AchievementCategoryButton activeButton;
    public ScrollRect scrollRect;
    private bool first;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("CameraFolder");
        activeButton = GameObject.Find("Level1Button").GetComponent<AchievementCategoryButton>();
        CreateAchievement("Level1", "Complete the level", "Reach the end teleporter on Level 1", 5);
        CreateAchievement("Level1", "Complete", "This is description", 10);
        CreateAchievement("Level1", "Complete", "This is description", 10);
        CreateAchievement("Level1", "Complete", "This is description", 10);

        CreateAchievement("Level2", "Complete", "This is description", 10);
        foreach (GameObject achievementlist in GameObject.FindGameObjectsWithTag("AchievementList"))
        {
            achievementlist.SetActive(false);
        }
        
        activeButton.Click();
        canvas.SetActive(false);
    }

    public void CreateAchievement(string category, string title, string description, int points)
    {
        GameObject achievement = (GameObject)Instantiate(achievementPrefab);
        SetAchievementInfo(category, achievement, title, description, points);
    }
    public void SetAchievementInfo(string category, GameObject achievement, string title, string description, int points)
    {
        achievement.transform.SetParent(GameObject.Find(category).transform);
        achievement.transform.localScale = new Vector3(1, 1, 1);
        achievement.transform.GetChild(0).GetComponent<Text>().text = title;
        achievement.transform.GetChild(1).GetComponent<Text>().text = description;
        achievement.transform.GetChild(2).GetComponent<Text>().text = points.ToString();
    }
    public void ChangeCategory(GameObject button)
    {
        AchievementCategoryButton achievementbutton = button.GetComponent<AchievementCategoryButton>();
        scrollRect.content = achievementbutton.achievementList.GetComponent<RectTransform>();
        if (first == false)
        {
            activeButton = GameObject.Find("Level1Button").GetComponent<AchievementCategoryButton>();
            first = true;
        }

        achievementbutton.Click();
        activeButton.Click();
        activeButton = achievementbutton;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            canvas.SetActive(true);
            player.GetComponent<PlayerController>().ON = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            camera.GetComponent<CameraFollow>().ON = false;
        }
    }

}
