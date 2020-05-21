using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    GameObject camera;
    GameObject RealCanvas;
    public GameObject achievementPrefab;
    public Sprite[] Sprites;
    public GameObject canvas;
    private AchievementCategoryButton activeButton;
    public ScrollRect scrollRect;
    private bool first;
    private bool InTrigger;
    bool on;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("CameraFolder");
        activeButton = GameObject.Find("Level1Button").GetComponent<AchievementCategoryButton>();
        CreateAchievement("Level1", "Windmills", "Find all 5 Windmill cogs to make them work again", 5, "MLVL1");
        CreateAchievement("Level1", "From E to the Z", "Reach the end teleporter", 5, "Level1_Complete");
        CreateAchievement("Level1", "Darkness away!", "Light up all 7 torches", 5, "Level1_Torches");
        CreateAchievement("Level1", "Whoops", "Break open a barrel without jumping on it", 5, "Level1_Barrel_Jump");
        CreateAchievement("Level1", "Toss it in the treasury", "Find all 7 green gems", 5, "Level1_Gems");
        CreateAchievement("Level1", "What's this?", "Find a secret in the level", 5, "Level1_Secret");
        CreateAchievement("Level1", "OPEN UP", "Find a way to open the door without a key", 5, "Level1_NoKey");
        CreateAchievement("Level1", "Fear of flying", "Complete the level by jumping 4 or less times", 5, "Level1_Jumping");
        CreateAchievement("Level1", "Two party system", "Retrieve the key in under 10 seconds", 5, "Level1_Race_Key");
        CreateAchievement("Level1", "AAAAAHHHHH", "Complete the level in under 22 seconds", 5, "Level1_Race");

        CreateAchievement("Level2", "Farms", "Find all 10 Crop seeds to save the town from famine", 5, "MLVL2");
        CreateAchievement("Level2", "Done and done", "Reach the end teleporter", 5, "Level2_Complete");
        CreateAchievement("Level2", "Untouchable", "Finish the level without losing a single life", 5, "Level2_NoDMG");
        CreateAchievement("Level2", "It's bright as is!", "Light up all 15 torches", 5, "Level2_Torches");
        CreateAchievement("Level2", "D-O-S-H", "Find all 21 green gems", 5, "Level2_Gems");
        CreateAchievement("Level2", "Shiny!", "Find 2 secrets in the level", 5, "Level2_Secret");
        CreateAchievement("Level2", "Excess", "Finish the level with a key in your inventory", 5, "Level2_2Keys");
        CreateAchievement("Level2", "AAAAAHHHHH", "Complete the level in under 85 seconds", 5, "Level2_Race");

        CreateAchievement("Level3", "Sawblade", "Bring back the Sawblade for the lumberjack", 5, "MLVL3");
        CreateAchievement("Level3", "Out of here", "Reach the end teleporter", 5, "Level3_Complete");
        CreateAchievement("Level3", "Evasive", "Finish the level without losing a single life", 5, "Level3_NoDMG");
        CreateAchievement("Level3", "It burns!", "Light up all 3 torches", 5, "Level3_Torches");
        CreateAchievement("Level3", "Smashy", "Find all 19 green gems", 5, "Level3_Gems");
        CreateAchievement("Level3", "Who hides treasures?", "Find 2 secrets in the level", 5, "Level3_Secret");
        CreateAchievement("Level3", "AAAAAHHHHH", "Complete the level in under 110 seconds", 5, "Level3_Race");

        CreateAchievement("Level4", "Saplings", "Bring back 10 magical saplings to restore the foliage in town", 5, "MLVL4");
        CreateAchievement("Level4", "The deed is done", "Reach the end teleporter", 5, "Level4_Complete");
        CreateAchievement("Level4", "Not curious enough", "Finish the level without losing a single life", 5, "Level4_NoDMG");
        CreateAchievement("Level4", "Ignition!", "Light up 10 pots", 5, "Level4_Torches");
        CreateAchievement("Level4", "Green is good", "Find all 14 green gems", 5, "Level4_Gems");
        CreateAchievement("Level4", "Peekers advantage", "Find 2 secrets in the level", 5, "Level4_Secret");
        CreateAchievement("Level4", "AAAAAHHHHH", "Complete the level in under 150 seconds", 5, "Level4_Race");
        foreach (GameObject achievementlist in GameObject.FindGameObjectsWithTag("AchievementList"))
        {
            achievementlist.SetActive(false);
        }
        
        activeButton.Click();
        canvas.SetActive(false);
        RealCanvas = GameObject.Find("Canvas");
        RealCanvas.GetComponent<EscapeMenu>().ijungtasAchievements = false;
        on = false;
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
        if (Input.GetKeyDown(KeyCode.Escape) && on)
        {
            TurnOff();
        }
    }
    public void CreateAchievement(string category, string title, string description, int points, string name)
    {
        GameObject achievement = (GameObject)Instantiate(achievementPrefab);
        SetAchievementInfo(category, achievement, title, description, points, name);
    }
    public void SetAchievementInfo(string category, GameObject achievement, string title, string description, int points, string name)
    {
        achievement.transform.GetChild(4).gameObject.SetActive(false);
        achievement.transform.SetParent(GameObject.Find(category).transform);
        achievement.transform.localScale = new Vector3(1, 1, 1);
        achievement.transform.GetChild(0).GetComponent<Text>().text = title;
        achievement.transform.GetChild(1).GetComponent<Text>().text = description;
        achievement.transform.GetChild(2).GetComponent<Text>().text = points.ToString();
        if (1 == PlayerPrefs.GetInt(name, 0))
        {
            achievement.transform.GetChild(4).gameObject.SetActive(true);
        }
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
            InTrigger = true;
            on = true;
            RealCanvas.GetComponent<EscapeMenu>().ijungtasAchievements = true;
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
        on = false;
        RealCanvas.GetComponent<EscapeMenu>().ijungtasAchievements = false;
    }

}
