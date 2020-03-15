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
        CreateAchievement("Level1", "From E to the Z", "Reach the end teleporter", 5);
        CreateAchievement("Level1", "Darkness away!", "Light up all 7 torches", 2);
        CreateAchievement("Level1", "Whoops", "Break open a barrel without jumping on it", 2);
        CreateAchievement("Level1", "Toss it in the treasury", "Find all 7 green gems", 2);
        CreateAchievement("Level1", "What's this?", "Find a secret in the level", 5);
        CreateAchievement("Level1", "Fear of flying", "Complete the level by jumping 5 or less times", 5);
        CreateAchievement("Level1", "Two party system", "Retrieve the key in under 10 seconds", 5);
        CreateAchievement("Level1", "AAAAAHHHHH", "Complete the level in under 25 seconds", 10);

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
    public void TurnOff()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.GetComponent<PlayerController>().ON = true;
        camera.GetComponent<CameraFollow>().ON = true;
        canvas.SetActive(false);
    }

}
